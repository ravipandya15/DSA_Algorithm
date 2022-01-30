using System;
using System.Collections.Generic;
using System.Linq;

namespace CN_Maximum_sum_of_non_adjacent_elements
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Maximum_sum_of_non_adjacent_elements");
            int[] arr = new int[] { 2, 1, 4, 9 };
            Console.WriteLine($"ans is {MaximumNonAdjacentSum4(arr.ToList())}");
        }

        public static int solve(int index, List<int> nums)
        {
            if (index == 0)
            {
                return nums[index];
            }
            if (index < 0)
            {
                return 0;
            }

            // pick
            int pick = nums[index] + solve(index - 2, nums);
            // non pick 
            int not_pick = solve(index - 1, nums);

            return Math.Max(pick, not_pick);
        }

        // Recursion
        // TC -> O(2^n)
        // SC -> O(N)
        public static int MaximumNonAdjacentSum1(List<int> nums)
        {
            // Write your code here.
            int n = nums.Count;
            return solve(n - 1, nums);
        }

        public static int solve1(int index, List<int> nums, int[] dp)
        {
            if (index == 0) return nums[index];
            if (index < 0) return 0;

            if (dp[index] != -1) return dp[index];

            // pick
            int pick = nums[index] + solve1(index - 2, nums, dp);
            // non pick 
            int not_pick = solve1(index - 1, nums, dp);

            return dp[index] = Math.Max(pick, not_pick);
        }

        // Memoization
        // TC -> O(N)
        // SC -> O(N) + O(N)
        public static int MaximumNonAdjacentSum2(List<int> nums)
        {
            // Write your code here.
            int n = nums.Count;
            int[] dp = new int[n];
            Array.Fill(dp, -1);
            return solve1(n - 1, nums, dp);
        }

        // tabulation
        // TC -> O(N)
        // SC -> O(N)
        public static int MaximumNonAdjacentSum3(List<int> nums)
        {
            // Write your code here.
            int n = nums.Count;
            int[] dp = new int[n];
            Array.Fill(dp, -1);
            dp[0] = nums[0];

            for (int i = 1; i < n; i++)
            {
                int pick = nums[i];
                if (i - 2 >= 0) pick += dp[i - 2];

                int not_pick = dp[i - 1];

                dp[i] = Math.Max(pick, not_pick);
            }

            return dp[n - 1];
        }

        // space optimization
        // TC -> O(N)
        // SC -> O(1)
        public static int MaximumNonAdjacentSum4(List<int> nums)
        {
            // Write your code here.
            int n = nums.Count;
            int prev2 = 0;
            int prev = nums[0];

            for (int i = 1; i < n; i++)
            {
                int pick = nums[i];
                if (i - 2 >= 0) pick += prev2;

                int not_pick = prev;

                int curi = Math.Max(pick, not_pick);

                prev2 = prev;
                prev = curi;
            }

            return prev;
        }
    }
}
