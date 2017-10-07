using System;
using System.Collections.Generic;

namespace Sort
{
    class QuickSort
    {
        // Using IComparable
        public static void Sort<T>(T[] list)
            where T : IComparable<T>
        {
            Sort(list, 0, list.Length - 1);
        }
        public static void Sort<T>(T[] list, int left, int right)
            where T : IComparable<T>
        {
            if (left < right)
            {
                int lo, hi, pivot;
                lo = left; hi = right; pivot = left; // pivot = left | right

                while (lo < hi)
                {
                    while (list[lo].CompareTo(list[pivot]) == -1) lo++;
                    while (list[hi].CompareTo(list[pivot]) == 1) hi--;

                    if (lo < hi)
                    {
                        if (list[lo].CompareTo(list[hi]) == 0) lo++; // Avoid duplicate values
                        Swap(ref list[lo], ref list[hi]);
                    }
                }
                pivot = lo;

                //Call Recursion
                Sort(list, left, pivot - 1);
                Sort(list, pivot + 1, right);
            }
        }

        // Using Comparer
        public static void Sort<T>(Comparer<T> cmp, T[] list)
        {
            Sort(cmp, list, 0, list.Length - 1);
        }
        public static void Sort<T>(Comparer<T> cmp, T[] list, int left, int right)
        {
            if (left < right)
            {
                int lo, hi, pivot;
                lo = left; hi = right; pivot = left; // pivot = left | right

                while (lo < hi)
                {
                    while (cmp.Compare(list[lo], list[pivot]) == -1) lo++;
                    while (cmp.Compare(list[hi], list[pivot]) == 1) hi--;

                    if (lo < hi)
                    {
                        if (cmp.Compare(list[lo], list[hi]) == 0) lo++; // Avoid duplicate values
                        Swap(ref list[lo], ref list[hi]);
                    }
                }
                pivot = lo;

                //Call Recursion
                Sort(cmp, list, left, pivot - 1);
                Sort(cmp, list, pivot + 1, right);
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
