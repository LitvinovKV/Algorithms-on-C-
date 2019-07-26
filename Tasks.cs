using System;
using System.Collections.Generic;
using System.Text;

namespace CS_Algorithms
{
    class Tasks
    {
        // Алгоритм, который в заданном множестве S ищет два элемента сумма которых равна заданному числу X
        // Ограничения: максимальное время работы алгоритма O(nlgn) при условии, что массив заранее отсортирован
        public static (int?, int?) fintTwoValue(int[] array, int x)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int firstValue = array[i];
                int secondValue = x - firstValue;
                if (Search_Algorithms.Binary_Search(array, secondValue, array.Length) != null)
                    return (firstValue, secondValue);
            }
            return (null, null);
        }

        // Алгоритм для определения количества инверсий, содержащихся в произвольном массиве из n элементов.
        // Если i < j и A[i] > A[j], то пара (i, j) называется Инверсией.
        // Ограничения: Наихудшее время работы алгоритма = O(nlgn). Необходимо модифицировать алгоритм сортировки слиянием.
        // Сортировка слиянием
        public static int Find_Invecrsion<T>(T[] array, int startIndexArray, int sizeArray, int countInversion) where T : IComparable
        {
            if ((startIndexArray + 1) < sizeArray)
            {
                int q = (startIndexArray + sizeArray) / 2;
                countInversion = Find_Invecrsion(array, startIndexArray, q, countInversion);
                countInversion = Find_Invecrsion(array, q, sizeArray, countInversion);
                countInversion += Merge(array, startIndexArray, q, sizeArray);
            }
            return countInversion;
        }

        private static int Merge<T>(T[] array, int p, int q, int r) where T : IComparable
        {
            T[] leftArray = new T[q - p];
            T[] rightArray = new T[r - q];
            // Формируем левый подмассив
            for (int i = 0; i < q - p; i++)
                leftArray[i] = array[i + p];
            // Формируем правый подмассив
            for (int i = 0; i < r - q; i++)
                rightArray[i] = array[i + q];
            // Счетчики подмассивов для слияния в целостный массив
            int leftI = 0, rightI = 0;
            // Общий счетчик подсчета инверский при слиянии и кол-во элементов, который пришли из правого массива (=> слева элемент больше)
            int countInversion = 0, countRights = 0;
            for (int i = p; i < r; i++)
            {
                // Если левый счетчик вышел за пределы левого массива или 
                // (число в правом массиве меньше чем в левом и правый счетчик не вышел за границы правого массива)
                if (leftI == leftArray.Length || (rightI < rightArray.Length && leftArray[leftI].CompareTo(rightArray[rightI]) > 0))
                {
                    array[i] = rightArray[rightI];
                    rightI++;
                    countRights++;
                }
                else
                {
                    array[i] = leftArray[leftI];
                    leftI++;
                    countInversion += countRights;
                }
            }
            return countInversion;
        }
        
        // Алгоритм для нахождения подмассива с максимальной суммой элементов подмассива.
        // Алгоритм базируется на метода "разделяй и властвуй". Верхрняя граница работы алгоритма O(nlgn)
        public static (int, int, int) Find_Maximum_SubArray(int[] array, int startIndex, int countElements)
        {
            // Базовый случай, массив состоит из одного элемента и этот элемент является подмассивом с максимальной суммой
            if (countElements - 1 == startIndex)
                return (startIndex, countElements, array[startIndex]);
            else
            {
                int mid = (startIndex + countElements) / 2;
                (int, int, int) left = Find_Maximum_SubArray(array, startIndex, mid);
                (int, int, int) right = Find_Maximum_SubArray(array, mid, countElements);
                (int, int, int) middle = Find_Maximum_Middle_SubArray(array, startIndex, mid, countElements);

                // Если найденный левый подмассив больше остальных, то вернуть его
                if (left.Item3 > right.Item3 && left.Item3 > middle.Item3)
                    return (left.Item1, left.Item2, left.Item3);
                // Если найденный правый подмассив больше остальных, то вернуть его
                else if (right.Item3 > left.Item3 && right.Item3 > middle.Item3)
                    return (right.Item1, right.Item2, right.Item3);
                // Иначе вернуть центральный подмассив
                else
                    return (middle.Item1, middle.Item2, middle.Item3);
            }
        }

        // Вспомогательный метод, для нахождения максимального подмассива у пересечения
        private static (int, int, int) Find_Maximum_Middle_SubArray(int[] array, int startIndex, int midIndex, int countElements)
        {
            // Найти максимальный подмассив слева от пересечения (array[i...mid - 1])
            double leftSum = Double.NegativeInfinity;
            int sum = 0, startIndexSubArray = 0;
            for (int i = midIndex - 1; i >= startIndex; i--)
            {
                sum += array[i];
                if (sum > leftSum)
                {
                    leftSum = sum;
                    startIndexSubArray = i;
                }
            }

            // Найти максимальный подмассив справа от пересечения (array[mid...j])
            double rightSum = Double.NegativeInfinity;
            sum = 0;
            int endIndexSubArray = 0;
            for (int j = midIndex; j < countElements; j++)
            {
                sum += array[j];
                if (sum > rightSum)
                {
                    rightSum = sum;
                    endIndexSubArray = j;
                }
            }
            // Вернуть подмассив (левая граница подмассива, правая граница подмассива, сумма найденных сумм подмассивов)
            return (startIndexSubArray, endIndexSubArray, Convert.ToInt32(leftSum + rightSum));
        }

        // Алгоритм для нахождения подмассива с максимальной суммой элементов подмассива.
        // Алгоритм просто перебирает все возможные варианты связок элементов. Верхняя граница работы алгоритма O(n^2)
        public static (int, int, int) Long_Find_Maximum_SubArray(int[] array, int startIndex, int countElements)
        {
            int resultSum = array[0];
            int leftIndex = 0, rightIndex = 0;
            for (int i = startIndex; i < countElements; i++)
            {
                leftIndex = i;
                int sum = array[i];
                for (int j = i + 1; j < countElements; j++)
                {
                    sum += array[j];
                    if (sum > resultSum)
                    {
                        resultSum = sum;
                        rightIndex = j;
                    }
                }
            }
            return (leftIndex, rightIndex, resultSum);
        }
    }
}
