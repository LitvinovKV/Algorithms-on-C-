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
        
        // Бинарный поиск
        public static int? Binary_Search<T>(T[] array, T value, int lengthArray, int startIndexArray = 0) where T : IComparable
        {
            int middleIndex = (lengthArray - startIndexArray) / 2 + startIndexArray;
            if (lengthArray - startIndexArray >= 0)
            {
                sbyte equals = Convert.ToSByte(value.CompareTo(array[middleIndex]));
                int? result = null;
                if (equals == 0)
                    result = middleIndex;
                else if (equals > 0)
                    result = Binary_Search(array, value, lengthArray, middleIndex + 1);
                else
                    result = Binary_Search(array, value, middleIndex - 1, startIndexArray);
                return result;
            }
            else
                return null;
        }
    }
}
