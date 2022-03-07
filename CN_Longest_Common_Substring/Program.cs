using System;

namespace CN_Longest_Common_Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Longest_Common_Substring");
        }

        // Tabulation
        // TC -> O(N * M)
        // SC -> O(N * M)
        public static int lcs1(String s, String t)
        {
            int n = s.Length;
            int m = t.Length;

            int[,] dp = new int[n + 1, m + 1];

            // base case
            for (int i = 0; i <= n; i++)
            {
                dp[i, 0] = 0;
            }

            for (int j = 0; j <= m; j++)
            {
                dp[0, j] = 0;
            }

            int maxi = 0;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    if (s[i - 1] == t[j - 1])
                    {
                        dp[i, j] = 1 + dp[i - 1, j - 1];
                        maxi = Math.Max(maxi, dp[i, j]);
                    }
                    else
                    {
                        dp[i, j] = 0;
                    }
                }
            }

            return maxi;
        }

        // Space optimization
        // TC -> O(N * M)
        // SC -> O(M)
        public static int lcs2(String s, String t)
        {
            int n = s.Length;
            int m = t.Length;

            int[] prev = new int[m + 1];

            // base case not require as default value is 0

            int maxi = 0;
            for (int i = 1; i <= n; i++)
            {
                int[] cur = new int[m + 1];
                for (int j = 1; j <= m; j++)
                {
                    if (s[i - 1] == t[j - 1])
                    {
                        cur[j] = 1 + prev[j - 1];
                        maxi = Math.Max(maxi, cur[j]);
                    }
                    else
                    {
                        cur[j] = 0;
                    }
                }
                prev = cur;
            }

            return maxi;
        }
    }
}
