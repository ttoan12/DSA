using System;
using System.Collections.Generic;

namespace Sort
{
    class RandomQuickSort
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
            if (right > left)
            {
                int random = new Random().Next(left, right);        // Randomly select an index for pivot
                Swap(ref list[left], ref list[random]);             // Swap pivot with the first element
                int pivotIndex = left;
                int storeIndex = pivotIndex + 1;                    // Create an index for swapped elements to find the correct index for pivot
                for (int i = storeIndex; i <= right; i++)
                {
                    if (list[i].CompareTo(list[pivotIndex]) != 1)  // If element[i] <= pivot, swap it with store Index
                    {
                        Swap(ref list[i], ref list[storeIndex]);
                        storeIndex++;
                    }
                }
                Swap(ref list[pivotIndex], ref list[storeIndex - 1]);   // Swap pivot with the last stored index (correct index of pivot)
                pivotIndex = storeIndex - 1;                            // Current index of Pivot

                //Call Recursion
                Sort(list, left, pivotIndex - 1);   // Sort the left side of Pivot
                Sort(list, pivotIndex + 1, right);  // Sort the right side of Pivot
            }
        }

        // Using Comparer
        public static void Sort<T>(Comparer<T> cmp, T[] list)
        {
            Sort(cmp, list, 0, list.Length - 1);
        }
        public static void Sort<T>(Comparer<T> cmp, T[] list, int left, int right)
        {
            if (right > left)
            {
                int random = new Random().Next(left, right);        // Randomly select an index for pivot
                Swap(ref list[left], ref list[random]);             // Swap pivot with the first element
                int pivotIndex = left;
                int storeIndex = pivotIndex + 1;                    // Create an index for swapped elements to find the correct index for pivot
                for (int i = storeIndex; i <= right; i++)
                {
                    if (cmp.Compare(list[i], list[pivotIndex]) != 1)  // If element[i] <= pivot, swap it with store Index
                    {
                        Swap(ref list[i], ref list[storeIndex]);
                        storeIndex++;
                    }
                }
                Swap(ref list[pivotIndex], ref list[storeIndex - 1]);   // Swap pivot with the last stored index (correct index of pivot)
                pivotIndex = storeIndex - 1;                            // Current index of Pivot

                //Call Recursion
                Sort(cmp, list, left, pivotIndex - 1);   // Sort the left side of Pivot
                Sort(cmp, list, pivotIndex + 1, right);  // Sort the right side of Pivot
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
