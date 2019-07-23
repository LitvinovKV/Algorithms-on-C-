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
    }
}
