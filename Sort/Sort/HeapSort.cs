using System;
using System.Collections.Generic;

namespace Sort
{
    class HeapSort
    {
        // Using IComparable
        public static void Sort<T>(T[] list, int sorted = 0)
            where T : IComparable<T>
        {
            int length = list.Length - sorted;
            if (length > 1)
            {
                for (int i = (length / 2); i >= 1; i--)
                {
                    int left, pos1, pos2, largest;
                    left = i - 1;
                    pos1 = i * 2 - 1;
                    pos2 = i * 2;
                    largest = pos1;

                    //Compare
                    if (pos2 < length)
                        if (list[pos1].CompareTo(list[pos2]) < 1)
                            largest = pos2;

                    //Replace the largest
                    if (list[left].CompareTo(list[largest]) < 1)
                        Swap(ref list[left], ref list[largest]);

                }
                Swap(ref list[0], ref list[length - 1]);
                Sort(list, sorted + 1);
            }
        }

        // Using Comparer
        public static void Sort<T>(Comparer<T> cmp, T[] list, int sorted = 0)
        {
            int length = list.Length - sorted;
            if (length > 1)
            {
                for (int i = (length / 2); i >= 1; i--)
                {
                    int left, pos1, pos2, largest;
                    left = i - 1;
                    pos1 = i * 2 - 1;
                    pos2 = i * 2;
                    largest = pos1;

                    //Compare
                    if (pos2 < length)
                        if (cmp.Compare(list[pos1], list[pos2]) < 1)
                            largest = pos2;

                    //Replace the largest
                    if (cmp.Compare(list[left], list[largest]) < 1)
                        Swap(ref list[left], ref list[largest]);

                }
                Swap(ref list[0], ref list[length - 1]);
                Sort(cmp, list, sorted + 1);
            }
        }


        private static void Swap<T>(ref T t1, ref T t2)
        {
            var temp = t1;
            t1 = t2;
            t2 = temp;
        }
    }
}
