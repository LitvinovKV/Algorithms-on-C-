using System;
using System.Collections.Generic;
using System.Text;

namespace CS_Algorithms
{
    class Search_Algorithms
    {
        // Линейный поиск
        public static int? Linear_Search<T>(T[] array, T value) where T : IComparable
        {
            for (int i = 0; i < array.Length; i++)
                if (array[i].CompareTo(value) == 0)
                    return i;
            return null;
        }
    }
}
