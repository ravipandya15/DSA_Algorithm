using System;

namespace Permutation_of_string
{
    class Program
    {
        public static void permute(string str, int l, int r)
        {
            if (l == r)
            {
                Console.WriteLine(str);
            }
            else
            {
                for (int i = l; i <= r; i++)
                {
                    str = swap(str, l, i);
                    permute(str, l + 1, r);
                    str = swap(str, l, i);
                }
            }
        }

        public static string swap(string s, int l, int r)
        {
            char[] inputArray = s.ToCharArray();
            char temp = inputArray[l];
            inputArray[l] = inputArray[r];
            inputArray[r] = temp;

            return new string(inputArray);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Write a program to print all permutations of a given string");
            string inputString = Console.ReadLine();
            Console.WriteLine("After permutations of all string...");
            permute(inputString, 0, inputString.Length - 1);
            Console.ReadLine();
        }
    }
}
