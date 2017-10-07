using System;
using System.Collections.Generic;

namespace Sort
{
    class MergeSort
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
                int middle = (right + left) / 2;

                // Call Recursion
                Sort(list, left, middle);
                Sort(list, middle + 1, right);

                // Merge
                Merge(list, left, middle, right);
            }
        }
        private static void Merge<T>(T[] list, int left, int middle, int right)
            where T : IComparable<T>
        {
            int a = left;                   // First index of Left part
            int b = middle + 1;             // First index of Right part
            int length = right - left + 1;  // Length of merging index
            T[] temp = new T[length];
            int i = 0;                      // Index of temp array

            while (a <= middle && b <= right)           // While Left and Right part are within its bounds
            {
                if (list[a].CompareTo(list[b]) != 1)
                {
                    temp[i] = list[a]; i++; a++;
                }
                else
                {
                    temp[i] = list[b]; i++; b++;
                }
            }
            while (a <= middle)                         // While only Left part is within its bounds
            {
                temp[i] = list[a]; i++; a++;
            }
            while (b <= right)                          // While only Right part is within its bounds
            {
                temp[i] = list[b]; i++; b++;
            }

            for (int j = 0; j < length; j++)            // Transfer value from temp array back to the main array
            {
                list[left + j] = temp[j];
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
                int middle = (right + left) / 2;

                // Call Recursion
                Sort(cmp, list, left, middle);
                Sort(cmp, list, middle + 1, right);

                // Merge
                Merge(cmp, list, left, middle, right);
            }
        }
        private static void Merge<T>(Comparer<T> cmp, T[] list, int left, int middle, int right)
        {
            int a = left;                   // First index of Left part
            int b = middle + 1;             // First index of Right part
            int length = right - left + 1;  // Length of merging index
            T[] temp = new T[length];
            int i = 0;                      // Index of temp array

            while (a <= middle && b <= right)           // While Left and Right part are within its bounds
            {
                if (cmp.Compare(list[a], list[b]) != 1)
                {
                    temp[i] = list[a]; i++; a++;
                }
                else
                {
                    temp[i] = list[b]; i++; b++;
                }
            }
            while (a <= middle)                         // While only Left part is within its bounds
            {
                temp[i] = list[a]; i++; a++;
            }
            while (b <= right)                          // While only Right part is within its bounds
            {
                temp[i] = list[b]; i++; b++;
            }

            for (int j = 0; j < length; j++)            // Transfer value from temp array back to the main array
            {
                list[left + j] = temp[j];
            }
        }
    }
}
