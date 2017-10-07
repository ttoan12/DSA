using System;
using System.Collections.Generic;

namespace Sort
{
    class ShakerSort
    {
        // Using IComparable
        public static void Sort<T>(T[] list)
            where T : IComparable<T>
        {
            int length = list.Length - 1;
            int left = 0;
            int right = 0;

            while (left + right < length)
            {
                bool swapped = false;
                if (left < right)
                {
                    for (int i = length - right; i > left; i--)
                        if (list[i].CompareTo(list[i - 1]) == -1)
                        {
                            Swap(ref list[i], ref list[i - 1]);
                            swapped = true;
                        }
                    left++;
                }
                else
                {
                    for (int i = left; i < length - right; i++)
                        if (list[i].CompareTo(list[i + 1]) == 1)
                        {
                            Swap(ref list[i], ref list[i + 1]);
                            swapped = true;
                        }
                    right++;
                }
                if (!swapped) break;
            }
        }

        // Using Comparer
        public static void Sort<T>(Comparer<T> cmp, T[] list)
        {
            int length = list.Length - 1;
            int left = 0;
            int right = 0;

            while (left + right < length)
            {
                bool swapped = false;
                if (left < right)
                {
                    for (int i = length - right; i > left; i--)
                        if (cmp.Compare(list[i], list[i - 1]) == -1)
                        {
                            Swap(ref list[i], ref list[i - 1]);
                            swapped = true;
                        }
                    left++;
                }
                else
                {
                    for (int i = left; i < length - right; i++)
                        if (cmp.Compare(list[i], list[i + 1]) == 1)
                        {
                            Swap(ref list[i], ref list[i + 1]);
                            swapped = true;
                        }
                    right++;
                }
                if (!swapped) break;
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
