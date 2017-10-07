using System;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        { // TESTING AREA
            //int[] a = { 24, 32, 15, 61, 29, 5, 15, 34, 56, 13, 32, 37 };
            //char[] a = { 'a', 'z', 'd', 'b', 'c', 't', 'q', 'g' };
            //string[] a = { "toan", "thong", "tai", "trinh", "pho" };
            int[] a = Random(15);
            Output(a);

            RadixSort.Sort(a);

            Console.WriteLine();
            Output(a);
            
        }

        static void Output<T>(T[] a)
        {
            foreach (var i in a)
                Console.Write("{0} ", i);
            Console.WriteLine();
        }

        static int[] Random(int length)
        {
            Random random = new Random();
            int[] a = new int[length];
            for (int i = 0; i < length; i++)
                a[i] = random.Next(1, 100);
            return a;
        }
    }
}
