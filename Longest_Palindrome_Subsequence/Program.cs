using System;

namespace Longest_Palindrome_Subsequence
{
    class Program
    {
        public static int lps(string str, int i, int j, int[,] dp)
        {
            if (i > j)
            {
                return 0;
            }
            if (dp[i,j] != 0)
            {
                return dp[i, j];
            }
            if (i == j)
            {
                dp[i, j] = 1;
            }
            else if (str[i] == str[j])
            {
                dp[i, j] = 2 + lps(str, i + 1, j - 1, dp);
            }
            else
            {
                dp[i, j] = Math.Max(lps(str, i + 1, j, dp), lps(str, i, j -1, dp));
            }
            return dp[i, j];
        }
        public static int LongestPalindromeSubseq(string s)
        {
            int[,] dp = new int[s.Length,s.Length];
            return lps(s, 0, s.Length - 1, dp);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Lontest Palindrom subsequence");
            while(true)
            {
                Console.WriteLine("Enter a string");
                string str = Console.ReadLine();
                Console.WriteLine($"longest Palindrom subsequence of {str} is {LongestPalindromeSubseq(str)}");
            }
        }
    }
}
