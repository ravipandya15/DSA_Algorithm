using System;

namespace Frog_Jump
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_ Frog Jump");
        }

        public static int solve1(int index, int[] heights)
        {
            // base case
            if (index == 0) return 0;

            int left = solve1(index - 1, heights) + Math.Abs(heights[index] - heights[index - 1]);
            int right = Int32.MaxValue;
            if (index > 1) right = solve1(index - 2, heights) + Math.Abs(heights[index] - heights[index - 2]);

            return Math.Min(left, right);
        }

        // recursion
        public static int frogJump1(int n, int[] heights)
        {
            return solve1(n - 1, heights);
        }

        public static int solve(int index, int[] heights, int[] dp)
        {
            // base case
            if (index == 0) return 0;

            if (dp[index] != -1) return dp[index];

            int left = solve(index - 1, heights, dp) + Math.Abs(heights[index] - heights[index - 1]);
            int right = Int32.MaxValue;
            if (index > 1) right = solve(index - 2, heights, dp) + Math.Abs(heights[index] - heights[index - 2]);

            return dp[index] = Math.Min(left, right);
        }

        // memoization
        // TC -> O(N)
        // SC -> O(N) + O(N)
        public static int frogJump2(int n, int[] heights)
        {
            int[] dp = new int[n + 1];
            Array.Fill(dp, -1);
            return solve(n - 1, heights, dp);
        }

        //tabulation
        // TC -> O(N)
        // SC -> O(N)
        public static int frogJump3(int n, int[] heights)
        {
            int[] dp = new int[n];
            Array.Fill(dp, -1);
            dp[0] = 0;

            for (int i = 1; i < n; i++)
            {
                int left = dp[i - 1] + Math.Abs(heights[i] - heights[i - 1]);
                int right = Int32.MaxValue;
                if (i > 1) right = dp[i - 2] + Math.Abs(heights[i] - heights[i - 2]);

                dp[i] = Math.Min(left, right);
            }
            return dp[n - 1];
        }

        // space optimazation
        public static int frogJump4(int n, int[] heights)
        {

            int prev = 0, prev2 = 0;

            for (int i = 1; i < n; i++)
            {
                int left = prev + Math.Abs(heights[i] - heights[i - 1]);
                int right = Int32.MaxValue;
                if (i > 1) right = prev2 + Math.Abs(heights[i] - heights[i - 2]);

                int curi = Math.Min(left, right);
                prev2 = prev;
                prev = curi;
            }
            return prev;
        }
    }
}
