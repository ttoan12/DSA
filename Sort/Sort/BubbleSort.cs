using System;
using System.Collections.Generic;

namespace Sort
{
    class BubbleSort
    {
        // Using IComparable
        public static void Sort<T>(T[] list, int sorted = 0)
            where T : IComparable<T>
        {
            int length = list.Length - sorted - 1;
            if (length > 0)
            {
                bool swapped = false;
                for (int i = 0; i < length; i++)
                {
                    int j = i + 1;
                    if (list[i].CompareTo(list[j]) == 1)
                    {
                        Swap(ref list[i], ref list[j]);
                        swapped = true;
                    }
                }
                if (swapped)
                    Sort(list, sorted + 1);
            }
        }

        // Using Comparer
        public static void Sort<T>(Comparer<T> cmp, T[] list, int sorted = 0)
        {
            int length = list.Length - sorted - 1;
            if (length > 0)
            {
                bool swapped = false;
                for (int i = 0; i < length; i++)
                {
                    int j = i + 1;
                    if (cmp.Compare(list[i], list[j]) == 1)
                    {
                        Swap(ref list[i], ref list[j]);
                        swapped = true;
                    }
                }
                if (swapped)
                    Sort(cmp, list, sorted + 1);
            }
        }


        private static void Swap<T>(ref T a, ref T b)
        {
            var c = a;
            a = b;
            b = c;
        }
    }
}
