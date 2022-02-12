using System;

namespace CN_0_1_Knapsack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_0_1_Knapsack");
        }

        public static int solve(int index, int W, int[] wt, int[] val)
        {
            // base case
            if (index == 0)
            {
                if (wt[0] <= W) return val[0];
                else return 0;
            }

            int notTake = 0 + solve(index - 1, W, wt, val);
            int take = Int32.MinValue;
            if (wt[index] <= W) take = val[index] + solve(index - 1, W - wt[index], wt, val);

            return Math.Max(notTake, take);
        }

        // Recursion
        // TC -> O(2^N)
        // SC -> O(N)
        static int knapsack1(int[] weight, int[] value, int n, int maxWeight)
        {
            return solve(n - 1, maxWeight, weight, value);
        }

        public static int solve1(int index, int W, int[] wt, int[] val, int[,] dp)
        {
            // base case
            if (index == 0)
            {
                if (wt[0] <= W) return val[0];
                else return 0;
            }

            if (dp[index, W] != -1) return dp[index, W];

            int notTake = 0 + solve1(index - 1, W, wt, val, dp);
            int take = Int32.MinValue;
            if (wt[index] <= W) take = val[index] + solve1(index - 1, W - wt[index], wt, val, dp);

            return dp[index, W] = Math.Max(notTake, take);
        }

        // Memoization
        // TC -> O(N * W) -> N is size of weight and value array size and W is maxWeight
        // SC -> O(N * W) + O(N)
        static int knapsack2(int[] weight, int[] value, int n, int maxWeight)
        {
            int[,] dp = new int[n, maxWeight + 1];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= maxWeight; j++)
                {
                    dp[i, j] = -1;
                }
            }
            return solve1(n - 1, maxWeight, weight, value, dp);
        }

        // Tabulation
        // TC -> O(N * W) -> N is size of weight and value array size and W is maxWeight
        // SC -> O(N * W)
        static int knapsack3(int[] wt, int[] val, int n, int maxWeight)
        {
            int[,] dp = new int[n, maxWeight + 1];

            // base case
            for (int W = wt[0]; W <= maxWeight; W++) dp[0, W] = val[0];

            for (int index = 1; index < n; index++)
            {
                for (int W = 0; W <= maxWeight; W++)
                {
                    int notTake = 0 + dp[index - 1, W];
                    int take = Int32.MinValue;
                    if (wt[index] <= W) take = val[index] + dp[index - 1, W - wt[index]];

                    dp[index, W] = Math.Max(notTake, take);
                }
            }
            return dp[n - 1, maxWeight];

        }

        // Space Optimization
        // TC -> O(N * W) -> N is size of weight and value array size and W is maxWeight
        // SC -> O(W)
        static int knapsack4(int[] wt, int[] val, int n, int maxWeight)
        {
            int[] prev = new int[maxWeight + 1];

            // base case
            for (int W = wt[0]; W <= maxWeight; W++) prev[W] = val[0];

            for (int index = 1; index < n; index++)
            {
                int[] cur = new int[maxWeight + 1];
                for (int W = 0; W <= maxWeight; W++)
                {
                    int notTake = 0 + prev[W];
                    int take = Int32.MinValue;
                    if (wt[index] <= W) take = val[index] + prev[W - wt[index]];

                    cur[W] = Math.Max(notTake, take);
                }
                prev = cur;
            }
            return prev[maxWeight];
        }

        // SIngle Array Space Optimized Approach
        static int knapsack5(int[] wt, int[] val, int n, int maxWeight)
        {
            int[] prev = new int[maxWeight + 1];

            // base case
            for (int W = wt[0]; W <= maxWeight; W++) prev[W] = val[0];

            for (int index = 1; index < n; index++)
            {
                for (int W = maxWeight; W >= 0; W--)
                {
                    int notTake = 0 + prev[W];
                    int take = Int32.MinValue;
                    if (wt[index] <= W) take = val[index] + prev[W - wt[index]];

                    prev[W] = Math.Max(notTake, take);
                }
            }
            return prev[maxWeight];
        }
    }
}
