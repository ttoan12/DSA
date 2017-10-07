using System;
using System.Collections.Generic;

namespace Sort
{
    class ShellSort
    {
        // Using IComparable
        public static void Sort<T>(T[] list)
            where T : IComparable<T>
        {
            int length = list.Length;
            int space = length / 2; // distances of the index from the first to the second value

            while (space > 0)
            {
                for (int i = 0; i < length - space; i++)    // i = index of first value
                {
                    int j = i + space;                      // j = index of second value
                    if (list[i].CompareTo(list[j]) == 1)    // if first value > second value
                    {
                        Swap(ref list[i], ref list[j]);     // If values can be swapped, create a loop to compare with other value in [space] index(es) before
                        int pos = i;                        // create a return point for the index
                        while (i - space >= 0)              // Move back [space] index(es) if available to compare
                        {
                            i -= space; j = i + space;
                            if (list[i].CompareTo(list[j]) == 1)
                                Swap(ref list[i], ref list[j]);     // If values still can be swapped, continue the loop
                            else break;                             // If not, break the current loop
                        }
                        i = pos;                            // Restore the index to the return point
                    }
                }
                space = space / 2;                          // reduce the distance to continue/stop the loop
            }
        }

        // Using Comparer
        public static void Sort<T>(Comparer<T> cmp, T[] list)
        {
            int length = list.Length;
            int space = length / 2; // distances of the index from the first to the second value

            while (space > 0)
            {
                for (int i = 0; i < length - space; i++)    // i = index of first value
                {
                    int j = i + space;                      // j = index of second value
                    if (cmp.Compare(list[i], list[j]) == 1)    // if first value > second value
                    {
                        Swap(ref list[i], ref list[j]);     // If values can be swapped, create a loop to compare with other value in [space] index(es) before
                        int pos = i;                        // create a return point for the index
                        while (i - space >= 0)              // Move back [space] index(es) if available to compare
                        {
                            i -= space; j = i + space;
                            if (cmp.Compare(list[i], list[j]) == 1)
                                Swap(ref list[i], ref list[j]);     // If values still can be swapped, continue the loop
                            else break;                             // If not, break the current loop
                        }
                        i = pos;                            // Restore the index to the return point
                    }
                }
                space = space / 2;                          // reduce the distance to continue/stop the loop
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
