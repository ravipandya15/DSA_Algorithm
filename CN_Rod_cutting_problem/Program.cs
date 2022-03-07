using System;

namespace CN_Rod_cutting_problem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Rod_cutting_problem");
        }

        public static int solve(int index, int n, int[] price)
        {
            // base case
            if (index == 0)
            {// as rodLength is 1
                return price[0] * n;
            }

            int notTake = 0 + solve(index - 1, n, price);
            int take = Int32.MinValue;
            int rodLength = index + 1;
            if (rodLength <= n)
            {
                take = price[index] + solve(index, n - rodLength, price);
            }

            return Math.Max(notTake, take);
        }

        // Recursion
        // TC -> exponential
        // SC -> O(w)
        public static int cutRod1(int[] price, int n)
        {
            return solve(n - 1, n, price);
        }

        public static int solve1(int index, int n, int[] price, int[,] dp)
        {
            // base case
            if (index == 0)
            {// as rodLength is 1
                return price[0] * n;
            }

            if (dp[index,n] != -1) return dp[index,n];

            int notTake = 0 + solve1(index - 1, n, price, dp);
            int take = Int32.MinValue;
            int rodLength = index + 1;
            if (rodLength <= n)
            {
                take = price[index] + solve1(index, n - rodLength, price, dp);
            }

            return dp[index,n] = Math.Max(notTake, take);
        }

        // Memoization
        // TC -> O(N * n)
        // SC -> O(N * n) + O(N)
        public static int cutRod2(int[] price, int n)
        {
            int[,] dp = new int[n,n + 1];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    dp[i, j] = -1;
                }
            }

            return solve1(n - 1, n, price, dp);
        }

        // Tabulation
        // TC -> O(N * n)
        // SC -> O(N * n)
        public static int cutRod3(int[] price, int n)
        {
            int[,] dp = new int[n,n + 1];

            // base case
            for (int N = 0; N <= n; N++)
            {
                dp[0,N] = price[0] * N;
            }

            for (int index = 1; index < n; index++)
            {
                for (int N = 0; N <= n; N++)
                {
                    int notTake = 0 + dp[index - 1,N];
                    int take = Int32.MinValue;
                    int rodLength = index + 1;
                    if (rodLength <= N)
                    {
                        take = price[index] + dp[index,N - rodLength];
                    }

                    dp[index,N] = Math.Max(notTake, take);
                }
            }

            return dp[n - 1,n];
        }

        // Space optimization
        // TC -> O(N * n)
        // SC -> O(n)
        public static int cutRod4(int[] price, int n)
        {
            int[] prev = new int[n + 1];

            // base case
            for (int N = 0; N <= n; N++)
            {
                prev[N] = price[0] * N;
            }

            for (int index = 1; index < n; index++)
            {
                int[] cur = new int[n + 1];
                for (int N = 0; N <= n; N++)
                {
                    int notTake = 0 + prev[N];
                    int take = Int32.MinValue;
                    int rodLength = index + 1;
                    if (rodLength <= N)
                    {
                        take = price[index] + cur[N - rodLength];
                    }

                    cur[N] = Math.Max(notTake, take);
                }
                prev = cur;
            }

            return prev[n];
        }

        // Single Array Space optimized
        // TC -> O(N * n)
        // SC -> O(n)
        public static int cutRod5(int[] price, int n)
        {
            int[] prev = new int[n + 1];

            // base case
            for (int N = 0; N <= n; N++)
            {
                prev[N] = price[0] * N;
            }

            for (int index = 1; index < n; index++)
            {
                for (int N = 0; N <= n; N++)
                {
                    int notTake = 0 + prev[N];
                    int take = Int32.MinValue;
                    int rodLength = index + 1;
                    if (rodLength <= N)
                    {
                        take = price[index] + prev[N - rodLength];
                    }

                    prev[N] = Math.Max(notTake, take);
                }
            }

            return prev[n];
        }
    }
}
