using System;
using System.Text;

namespace CN_Longest_Palindromic_Subsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Longest_Palindromic_Subsequence");
        }

        public static int longestPalindromeSubsequence(string s)
        {
            char[] ch = s.ToCharArray();
            Array.Reverse(ch);
            return lcs4(s, new string(ch));
        }

        // Tabulation
        // TC -> O(N * M)
        // SC -> O(N * M)
        public static int lcs4(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            int[,] dp = new int[n + 1, m + 1];

            // base case
            for (int j = 0; j <= m; j++) dp[0, j] = 0;

            for (int i = 0; i <= n; i++) dp[i, 0] = 0;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    if (s[i - 1] == t[j - 1])
                    {
                        dp[i, j] = 1 + dp[i - 1, j - 1];
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }
            return dp[n, m];
        }
    }
}
