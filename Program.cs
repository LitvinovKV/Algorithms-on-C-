using System;
using System.Collections;

namespace CS_Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 5, 2, 4, 6, 1, 3, 5 };

            //Console.WriteLine(Linear_Search(array, 4));

            Sort_Algorithms.Selection_Sort(array);
            foreach (int value in array)
                Console.Write(value);

            Console.ReadKey();
        }

        
    }
}
