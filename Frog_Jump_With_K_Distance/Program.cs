using System;

namespace Frog_Jump_With_K_Distance
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Frog_Jump_With_K_Distance");
        }

        public static int solve1(int index, int[] heights, int k)
        {
            // base case
            if (index == 0) return 0;

            // int left = solve1(index - 1, heights) + Math.Abs(heights[index] - heights[index - 1]);
            // int right = Int32.MaxValue;
            // if (index > 1) right = solve1(index - 2, heights) + Math.Abs(heights[index] - heights[index - 2]);

            int MinSteps = Int32.MaxValue;
            for (int j = 1; j <= k; j++)
            {
                if (index - j >= 0)
                {
                    int jump = solve1(index - j, heights, k) + Math.Abs(heights[index] - heights[index - j]);
                    MinSteps = Math.Min(MinSteps, jump);
                }
            }

            return MinSteps;
        }

        // recursion
        public static int frogJump1(int n, int[] heights, int k)
        {
            return solve1(n - 1, heights, k);
        }

        public static int solve(int index, int[] heights, int[] dp, int k)
        {
            // base case
            if (index == 0) return 0;

            if (dp[index] != -1) return dp[index];

            int MinSteps = Int32.MaxValue;
            for (int j = 1; j <= k; j++)
            {
                if (index - j >= 0)
                {
                    int jump = solve1(index - j, heights, k) + Math.Abs(heights[index] - heights[index - j]);
                    MinSteps = Math.Min(MinSteps, jump);
                }
            }

            return dp[index] = MinSteps;
        }

        // memoization
        // TC -> O(N)
        // SC -> O(N) + O(N)
        public static int frogJump2(int n, int[] heights, int k)
        {
            int[] dp = new int[n + 1];
            Array.Fill(dp, -1);
            return solve(n - 1, heights, dp, k);
        }

        //tabulation
        // TC -> O(N)
        // SC -> O(N)
        public static int frogJump3(int n, int[] heights, int k)
        {
            int[] dp = new int[n];
            Array.Fill(dp, -1);
            dp[0] = 0;

            for (int i = 1; i < n; i++)
            {
                int MinSteps = Int32.MaxValue;
                for (int j = 1; j <= k; j++)
                {
                    if (i - j >= 0)
                    {
                        int jump = dp[i - j] + Math.Abs(heights[i] - heights[i - j]);
                        MinSteps = Math.Min(MinSteps, jump);
                    }
                }

                dp[i] = MinSteps;
            }
            return dp[n - 1];
        }
    }
}
