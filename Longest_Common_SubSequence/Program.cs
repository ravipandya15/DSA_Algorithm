using System;

namespace Longest_Common_SubSequence
{
    class Program
    {
        // using dynamic programming
        // default value of int is 0. so no need to set 0 as default value.
        public static int LongestCommonSubsequence(string text1, string text2)
        {
            int m = text1.Length;
            int n = text2.Length;
            int[,] DP = new int[m + 1, n + 1];
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (text1[i-1] == text2[j-1])
                    {
                        DP[i, j] = DP[i - 1, j - 1] + 1; 
                    }
                    else
                    {
                        DP[i, j] = Math.Max(DP[i - 1, j], DP[i, j - 1]);
                    }
                }
            }
            return DP[m, n];
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Longest Common subsequence");
            while(true)
            {
                string s1 = Console.ReadLine();
                string s2 = Console.ReadLine();
                Console.WriteLine($"answer is {LongestCommonSubsequence(s1, s2)}");
            }
        }
    }
}
