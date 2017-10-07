using System;
using System.Collections.Generic;

namespace Sort
{
    class InterchangeSort
    {
        // Using IComparable
        public static void Sort<T>(T[] list)
            where T : IComparable<T>
        {
            int length = list.Length;
            for (int i = 0; i < length - 1; i++)
                for (int j = i + 1; j < length; j++)
                {
                    if (list[i].CompareTo(list[j]) == 1)
                        Swap(ref list[i], ref list[j]);
                }
        }

        // Using Comparer
        public static void Sort<T>(Comparer<T> cmp, T[] list)
        {
            int length = list.Length;
            for (int i = 0; i < length - 1; i++)
                for (int j = i + 1; j < length; j++)
                {
                    if (cmp.Compare(list[i], list[j]) == 1)
                        Swap(ref list[i], ref list[j]);
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
