using System;
using System.Collections.Generic;
using System.Text;

namespace _557._Reverse_Words_in_a_String_III
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("557. Reverse Words in a String III");
            string str = "Let's take LeetCode contest";
            Console.WriteLine($"reverse string is {ReverseWords(str)}");
            Console.ReadLine();
        }

        public static string Reverse(char[] arr)
        {
            int s = 0;
            int e = arr.Length - 1;
            while (s <= e)
            {
                // swap;
                char ch = arr[s];
                arr[s] = arr[e];
                arr[e] = ch;
                s++;
                e--;
            }
            return arr.ToString();
        }

        public static string ReverseWords(string s)
        {
            string[] splitArray = s.Split(" ");
            int n = splitArray.Length;
            string str = "";
            for (int i = 0; i < n; i++)
            {
                str += Reverse(splitArray[i].ToCharArray());
                if (i != n - 1) str += " ";
            }
            return str;
        }
    }
}
