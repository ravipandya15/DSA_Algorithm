using System;

namespace Longest_Palindrom_SubString
{
    class Program
    {
        public static string LongestPalindrome(string str)
        {
            int startIndex = 0, endIndex = 0;
            int maxResultLength = 0;
            for (int i = 0; i < str.Length; i++)
            {
                int length1 = ExpandArroundCenter(str, i , i);
                int length2 = ExpandArroundCenter(str, i, i + 1);
                int maxLength = Math.Max(length1, length2);
                maxResultLength = Math.Max(maxResultLength, maxLength);
                if (maxLength > endIndex - startIndex)
                {
                    startIndex = i - (maxLength - 1) / 2;
                    endIndex = i + (maxLength) / 2;
                }
            }
            return str.Substring(startIndex, maxResultLength);
        }

        public static int ExpandArroundCenter(string str, int left, int right)
        {
            while(left >= 0 && right < str.Length && str[left] == str[right])
            {
                left--;
                right++;
            }
            return right - left - 1;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Longest Common Palindrome");
            while(true)
            {
                Console.WriteLine("Enter a string");
                string str = Console.ReadLine();
                Console.WriteLine($"Answer is {LongestPalindrome(str)}");
            }
        }
    }
}
