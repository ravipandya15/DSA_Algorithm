using System;
using System.Collections.Generic;

namespace _60._Permutation_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("60. Permutation Sequence");
            int n = 4, k = 17;
            Console.WriteLine($"{k}th permutation is {GetPermutation(n, k)}");
            Console.ReadLine();
        }

        public static string GetPermutation(int n, int k)
        {
            int fact = 1;
            List<int> numbers = new List<int>();
            // find factorial of n-1 number
            for (int i = 1; i < n; i++)
            {
                fact = fact * i;
                numbers.Add(i);
            }
            numbers.Add(n);
            k = k - 1; // as we are using 0th based indexing
            string ans = "";

            while (true)
            {
                ans = ans + numbers[k/fact];
                numbers.RemoveAt(k/fact);
                if (numbers.Count == 0)
                    break;

                k = k % fact;
                fact = fact / numbers.Count;
            }

            return ans;
        }
    }
}
