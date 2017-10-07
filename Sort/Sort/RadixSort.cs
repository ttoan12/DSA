using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sort
{
    class RadixSort
    {
        public static void Sort(int[] list, int pow = 0)
        {
            List<List<int>> digits = new List<List<int>>();   // Create a list for digits from 0 to 9
            for (int i = 0; i < 10; i++)
                digits.Add(new List<int>());

            bool unsorted = false;                              // Makes sure that all the elements are not divisible anymore
            
            for (int i = 0; i < list.Length; i++)
            {
                int digit = list[i] / (int)Math.Pow(10, pow);   // Gets number of the element when div by (10^pow)
                if (digit > 0) unsorted = true;
                while (digit >= 10) digit = digit % 10;         // Gets the leftover digit (the right-most digit)
                digits[digit].Add(list[i]);                     // Add that element to the list
            }

            int listIndex = 0;
            for (int i = 0; i < 10; i++)
            {
                foreach (int j in digits[i])
                {
                    list[listIndex] = j;
                    listIndex++;
                }
            }

            if (unsorted)                                       // If some elements are still divisible, Call recursion
                Sort(list, pow + 1);
        }

        public static void Sort(char[] list, int length = 0)
        {
            List<List<char>> digits = new List<List<char>>();
            for (int i = 0; i < 26; i++)
                digits.Add(new List<char>());
            
            for (int i = 0; i < list.Length; i++)
            {
                int digit = (list[i] - 'a');
                digits[digit].Add(list[i]);
            }

            int listIndex = 0;
            for (int i = 0; i < 26; i++)
            {
                foreach (char j in digits[i])
                {
                    list[listIndex] = j;
                    listIndex++;
                }
            }
        }
        
        public static void Sort(string[] list, int substring = 0)
        {
            List<List<string>> digits = new List<List<string>>();
            for (int i = 0; i < 27; i++)
                digits.Add(new List<string>());

            // Get the max length of strings
            int max = 0;
            for (int i = 0; i < list.Length; i++)
                if (list[i].Length > max)
                    max = list[i].Length;

            int length = max - substring; // the current sorting index
            
            
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i].Length >= length)
                {
                    char c = list[i].ToLower().Substring(length-1, 1).ToCharArray()[0]; // Gets the char at current sorting index of lowered string
                    int digit = (c - 'a' +1);   // Makes sure the digit of the first alphabetic character is 1
                    if (digit < 0 || digit > 27) digit = 0; // If the digit of character is not an alphabetic character, change it to 0
                    digits[digit].Add(list[i]); // Add current string to the list
                }
                else
                {
                    digits[0].Add(list[i]); // If no char at current sorting index, set the digit to 0
                }
            }

            // Sort the array
            int listIndex = 0;
            for (int i = 0; i < 27; i++)
            {
                foreach (string j in digits[i])
                {
                    list[listIndex] = j;
                    listIndex++;
                }
            }

            // Call recursion
            if (substring < max - 1)
             Sort(list, substring + 1);
        }

    }
}
