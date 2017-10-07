using System;
using System.Collections.Generic;

namespace Sort
{
    class SelectionSort
    {
        // Using IComparable
        public static void Sort<T>(T[] list)
            where T : IComparable<T>
        {
            int length = list.Length - 1;
            for (int i = 0; i < length; i++)
            {
                int min = i;
                for (int j = i + 1; j <= length; j++)
                {
                    if (list[j].CompareTo(list[min]) == -1) min = j;
                }
                if (min != i)
                    Swap(ref list[i], ref list[min]);
            }
        }

        // Using Comparer
        public static void Sort<T>(Comparer<T> cmp, T[] list)
        {
            int length = list.Length - 1;
            for (int i = 0; i < length; i++)
            {
                int min = i;
                for (int j = i + 1; j <= length; j++)
                {
                    if (cmp.Compare(list[j], list[min]) == -1) min = j;
                }
                if (min != i)
                    Swap(ref list[i], ref list[min]);
            }
        }


        private static void Swap<T>(ref T a, ref T b)
        {
            var temp = a;
            a = b;
            b = temp;
        }
    }
}
