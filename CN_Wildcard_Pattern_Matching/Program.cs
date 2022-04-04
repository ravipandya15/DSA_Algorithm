using System;

namespace CN_Wildcard_Pattern_Matching
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Wildcard_Pattern_Matching");
        }

        public static bool solve(int i, int j, string pattern, string text)
        {
            // base case
            if (i < 0 && j < 0) return true;
            if (i < 0 && j >= 0) return false;
            if (j < 0 && i >= 0)
            {
                for (int ii = 0; ii <= i; ii++)
                {
                    if (pattern[ii] != '*')
                    {
                        return false;
                    }
                }
                return true;
            }

            if ((pattern[i] == text[j]) || (pattern[i] == '?'))
            {
                return solve(i - 1, j - 1, pattern, text);
            }
            else if ((pattern[i] == '*'))
            {
                return solve(i - 1, j, pattern, text) | solve(i, j - 1, pattern, text);
            }
            else
            {
                return false;
            }
        }

        // Recursion
        // TC -> Exponential
        // SC -> O(N + M) -> Auxilary Stack space
        public static bool wildcardMatching_1(string pattern, string text)
        {
            int n = pattern.Length;
            int m = text.Length;
            return solve(n - 1, m - 1, pattern, text);
        }

        public static bool solve_1(int i, int j, string pattern, string text)
        {
            // base case
            if (i == 0 && j == 0) return true;
            if (i == 0 && j > 0) return false;
            if (j == 0 && i > 0)
            {
                for (int ii = 1; ii <= i; ii++)
                {
                    if (pattern[ii - 1] != '*')
                    {
                        return false;
                    }
                }
                return true;
            }

            if ((pattern[i-1] == text[j-1]) || (pattern[i-1] == '?'))
            {
                return solve_1(i - 1, j - 1, pattern, text);
            }
            else if ((pattern[i-1] == '*'))
            {
                return solve_1(i - 1, j, pattern, text) | solve_1(i, j - 1, pattern, text);
            }
            else
            {
                return false;
            }
        }

        // Recursion (1 based indexing)
        // TC -> Exponential
        // SC -> O(N + M)
        public static bool wildcardMatching_2(string pattern, string text)
        {
            int n = pattern.Length;
            int m = text.Length;
            return solve_1(n, m, pattern, text);
        }

        public static int solve_2(int i, int j, string pattern, string text, int[,] dp)
        {
            // base case
            if (i == 0 && j == 0) return 1;
            if (i == 0 && j > 0) return 0;
            if (j == 0 && i > 0)
            {
                for (int ii = 1; ii <= i; ii++)
                {
                    if (pattern[ii - 1] != '*')
                    {
                        return 0;
                    }
                }
                return 1;
            }

            if (dp[i,j] != -1) return dp[i,j];

            if ((pattern[i-1] == text[j-1]) || (pattern[i-1] == '?'))
            {
                return dp[i,j] = solve_2(i - 1, j - 1, pattern, text, dp);
            }
            else if ((pattern[i-1] == '*'))
            {
                return dp[i,j] = solve_2(i - 1, j, pattern, text, dp) | solve_2(i, j - 1, pattern, text, dp);
            }
            else
            {
                return 0;
            }
        }

        // Memoization
        // TC -> O(N * M)
        // SC ->  O(N * M) + O(N + M)
        public static bool wildcardMatching_3(string pattern, string text)
        {
            int n = pattern.Length;
            int m = text.Length;
            int[,] dp = new int[n + 1,m + 1];
            for (int i = 0; i < n + 1; i++)
            {
                for (int j = 0; j < m + 1; j++)
                {
                    dp[i,j] = -1;
                }
            }
            return solve_2(n, m, pattern, text, dp) == 1 ? true : false;
        }

        // Tabulation
        // TC -> O(N * M)
        // SC -> O(N * M)
        public static bool wildcardMatching_4(string pattern, string text)
        {
            int n = pattern.Length;
            int m = text.Length;
            bool[,] dp = new bool[n + 1,m + 1];

            // base case
            dp[0,0] = true;
            for (int j = 1; j <= m; j++) dp[0,j] = false;
            for (int i = 1; i <= n; i++)
            {
                bool flag = true;
                for (int ii = 1; ii <= i; ii++)
                {
                    if (pattern[ii - 1] != '*')
                    {
                        flag = false;
                        break;
                    }
                }
                dp[i,0] = flag;
            }


            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    if ((pattern[i-1] == text[j-1]) || (pattern[i-1] == '?'))
                    {
                        dp[i,j] = dp[i - 1,j - 1];
                    }
                    else if ((pattern[i-1] == '*'))
                    {
                        dp[i,j] = dp[i - 1,j] | dp[i,j - 1];
                    }
                    else
                    {
                        dp[i,j] = false;
                    }
                }
            }

            return dp[n,m];
        }

        // Space optimization
        // TC -> O(N * M)
        // SC -> O(M)
        public static bool wildcardMatching_5(string pattern, string text)
        {
            int n = pattern.Length;
            int m = text.Length;
            bool[] prev = new bool[m + 1];

            // base case
            prev[0] = true;
            for (int j = 1; j <= m; j++) prev[j] = false;

            for (int i = 1; i <= n; i++)
            {
                bool[] cur = new bool[m + 1];
                bool flag = true;
                for (int ii = 1; ii <= i; ii++)
                {
                    if (pattern[ii - 1] != '*')
                    {
                        flag = false;
                        break;
                    }
                }
                cur[0] = flag;

                for (int j = 1; j <= m; j++)
                {
                    if ((pattern[i-1] == text[j-1]) || (pattern[i-1] == '?'))
                    {
                        cur[j] = prev[j - 1];
                    }
                    else if ((pattern[i-1] == '*'))
                    {
                        cur[j] = prev[j] | cur[j - 1];
                    }
                    else
                    {
                        cur[j] = false;
                    }
                }
                prev = cur;
            }

            return prev[m];
        }
    }
}
