using System;
using System.Collections.Generic;
using System.Text;

namespace CS_Algorithms
{
    class Sort_Algorithms
    {
        // Сортировка вставкой
        public static void Insertion_Sort<T>(T[] array) where T : IComparable
        {
            for (int i = 1; i < array.Length; i++)
            {
                T key = array[i];
                int j = i - 1;
                while (j >= 0 && array[j].CompareTo(key) > 0)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = key;
            }
        }

        // Сортировка выбором
        public static void Selection_Sort<T>(T[] array) where T : IComparable
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int k = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j].CompareTo(array[k]) < 0)
                        k = j;
                }
                if (k != i)
                {
                    T value = array[k];
                    array[k] = array[i];
                    array[i] = value;
                }
            }
        }
        
        // Сортировка слиянием
        public static void Megre_Sort<T>(T[] array, int startIndexArray, int sizeArray) where T : IComparable
        {
            if ((startIndexArray + 1) < sizeArray)
            {
                int q = (startIndexArray + sizeArray) / 2;
                Megre_Sort(array, startIndexArray, q);
                Megre_Sort(array, q, sizeArray);
                Merge(array, startIndexArray, q, sizeArray);
            }
        }

        private static void Merge<T>(T[] array, int p, int q, int r) where T : IComparable
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
            for (int i = p; i < r; i++)
            {
                // Если левый счетчик вышел за пределы левого массива или 
                // (число в правом массиве меньше чем в левом и правый счетчик не вышел за границы правого массива)
                if (leftI == leftArray.Length || (rightI < rightArray.Length && leftArray[leftI].CompareTo(rightArray[rightI]) > 0))
                {
                    array[i] = rightArray[rightI];
                    rightI++;
                }
                else
                {
                    array[i] = leftArray[leftI];
                    leftI++;
                }
            }
        }
        
        // Пузырьковая сортировка
        public static void Bubble_Sort<T>(T[] array) where T : IComparable
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = array.Length - 1; j >= i + 1; j--)
                {
                    if (array[j].CompareTo(array[j - 1]) < 0)
                    {
                        T temp = array[j];
                        array[j] = array[j - 1];
                        array[j - 1] = temp;
                    }
                }
            }
        }
    }
}
