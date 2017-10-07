using System;
using System.Collections.Generic;

namespace Sort
{
    class InsertionSort
    {
        // Using IComparable
        public static void Sort<T>(T[] list)
            where T : IComparable<T>
        {
            for (int sorted = 0; sorted < list.Length - 1; sorted++)
            {
                int i = sorted;
                while (list[i].CompareTo(list[i + 1]) == 1)
                {
                    Swap(ref list[i], ref list[i + 1]);
                    if (i > 0) i--;
                }
            }
        }

        // Using Comparer
        public static void Sort<T>(Comparer<T> cmp, T[] list)
        {
            for (int sorted = 0; sorted < list.Length - 1; sorted++)
            {
                int i = sorted;
                while (cmp.Compare(list[i], list[i + 1]) == 1)
                {
                    Swap(ref list[i], ref list[i + 1]);
                    if (i > 0) i--;
                }
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
