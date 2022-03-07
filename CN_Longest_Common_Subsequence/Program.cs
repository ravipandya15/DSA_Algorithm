using System;

namespace CN_Longest_Common_Subsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Longest_Common_Subsequence");
        }

        public static int solve_1(int i, int j, char[] s, char[] t)
        {
            // base case
            if (i < 0 || j < 0) return 0;

            // match
            if (s[i] == t[j])
            {
                return 1 + solve_1(i - 1, j - 1, s, t);
            }
            else
            {// not matchW
                return Math.Max(solve_1(i - 1, j, s, t), solve_1(i, j - 1, s, t));
            }
        }

        // Recursion
        // TC -> O(2^N * 2^M)
        public static int lcs1(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            return solve_1(n - 1, m - 1, s.ToCharArray(), t.ToCharArray());
        }

        public static int solve(int i, int j, char[] s, char[] t)
        {
            // base case
            if (i == 0 || j == 0) return 0;

            // match
            if (s[i - 1] == t[j - 1])
            {
                return 1 + solve(i - 1, j - 1, s, t);
            }
            else
            {// not match
                return Math.Max(solve(i - 1, j, s, t), solve(i, j - 1, s, t));
            }
        }

        // Recursion
        // TC -> O(2^N * 2^M)
        public static int lcs2(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            return solve(n, m, s.ToCharArray(), t.ToCharArray());
        }

        public static int solve(int i, int j, char[] s, char[] t, int[,] dp)
        {
            // base case
            if (i == 0 || j == 0) return 0;

            if (dp[i,j] != -1) return dp[i,j];

            // match
            if (s[i - 1] == t[j - 1])
            {
                return dp[i,j] = 1 + solve(i - 1, j - 1, s, t, dp);
            }
            else
            {// not match
                return dp[i,j] = Math.Max(solve(i - 1, j, s, t, dp), solve(i, j - 1, s, t, dp));
            }
        }

        // Memoization
        // TC -> O(N * M)
        // SC -> O(N * M) + O(N + M)
        public static int lcs3(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            int[,] dp = new int[n + 1,m + 1];

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= m; j++)
                {
                    dp[i, j] = -1;
                }
            }

            return solve(n, m, s.ToCharArray(), t.ToCharArray(), dp);
        }

        // Tabulation
        // TC -> O(N * M)
        // SC -> O(N * M)
        public static int lcs4(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            int[,] dp = new int[n + 1,m + 1];

            // base case
            for (int j = 0; j <= m; j++) dp[0,j] = 0;

            for (int i = 0; i <= n; i++) dp[i,0] = 0;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    if (s[i - 1] == t[j - 1])
                    {
                        dp[i,j] = 1 + dp[i - 1,j - 1];
                    }
                    else
                    {
                        dp[i,j] = Math.Max(dp[i - 1,j], dp[i,j - 1]);
                    }
                }
            }
            return dp[n,m];
        }

        // Space optimization
        // TC -> O(N * M)
        // SC -> O(N * M)
        public static int lcs5(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            int[] prev = new int[m + 1];

            // base case
            for (int j = 0; j <= m; j++) prev[j] = 0;

            for (int i = 0; i <= n; i++) prev[0] = 0;

            for (int i = 1; i <= n; i++)
            {
                int[] cur = new int[m + 1];
                for (int j = 1; j <= m; j++)
                {
                    if (s[i - 1] == t[j - 1])
                    {
                        cur[j] = 1 + prev[j - 1];
                    }
                    else
                    {
                        cur[j] = Math.Max(prev[j], cur[j - 1]);
                    }
                }
                prev = cur;
            }
            return prev[m];
        }
    }
}
