using System;

namespace Print_Longest_Common_SubSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Print_Longest_Common_SubSequence");
            string s = "abcde";
            string t = "bdgek";
            printLongestCommonSubsequence(s, t);
        }

        // Taken from LCS Program

        // Tabulation
        // TC -> O(N * M)
        // SC -> O(N * M)

        public static void printLongestCommonSubsequence(string s, string t)
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
            int len = dp[n, m];

            char[] ans = new char[len];
            for (int i = 0; i < len; i++)
            {
                ans[i] = '$';
            }

            int i1 = n, j1 = m;
            int index = len - 1;

            while (i1 > 0 && j1 > 0)
            {
                if (s[i1 - 1] == t[j1 - 1])
                {
                    ans[index] = s[i1 - 1];
                    index--;
                    i1--;
                    j1--;
                }
                else if (dp[i1 - 1,j1] > dp[i1,j1 - 1])
                {
                    i1--;
                }
                else
                {
                    j1--;
                }
            }

            Console.WriteLine(new string(ans));
        }
    }
}
