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
    }
}
