using System;

namespace CN_Number_Of_Subsets
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Number_Of_Subsets");
        }

        public static int solve(int index, int target, int[] arr)
        {
            // base cases
            if (target == 0) return 1;
            if (index == 0)
            {
                if (arr[index] == target) return 1;
                else return 0;
            }

            // explore possiblities of that index
            int notTake = solve(index - 1, target, arr);
            int take = 0;
            if (target >= arr[index])
                take = solve(index - 1, target - arr[index], arr);

            return notTake + take;
        }

        // Recursion
        // TC -> O(2^n)
        // SC -> O(N)
        public static int findWays1(int[] num, int tar)
        {
            return solve(num.Length - 1, tar, num);
        }

        public static int solve1(int index, int target, int[] arr, int[,] dp)
        {
            // base cases
            if (target == 0) return 1;
            if (index == 0)
            {
                if (arr[index] == target) return 1;
                else return 0;
            }

            if (dp[index, target] != -1) return dp[index, target];

            // explore possiblities of that index
            int notTake = solve1(index - 1, target, arr, dp);
            int take = 0;
            if (target >= arr[index])
                take = solve1(index - 1, target - arr[index], arr, dp);

            return dp[index, target] = notTake + take;
        }

        // Memoization
        // TC -> O(N * target)
        // SC -> O(N) + O(N * target)
        public static int findWays2(int[] num, int tar)
        {
            int[,] dp = new int[num.Length, tar + 1];
            for (int i = 0; i < num.Length; i++)
            {
                for (int j = 0; j <= tar; j++)
                {
                    dp[i, j] = -1;
                }
            }

            return solve1(num.Length - 1, tar, num, dp);
        }

        // Tabulation
        // TC -> O(N * target)
        // SC -> O(N * target) 
        public static int findWays3(int[] num, int tar)
        {
            int n = num.Length;
            int[,] dp = new int[n, tar + 1];

            // base cases
            for (int i = 0; i < n; i++)
            {
                dp[i, 0] = 1;
            }

            if (num[0] <= tar) dp[0, num[0]] = 1;

            for (int index = 1; index < n; index++)
            {
                for (int target = 1; target <= tar; target++) // target = 0 will also work -> video ma 0 thi karyu chhe ne DP 14 ma 1 thi karyu tu
                {
                    int notTake = dp[index - 1, target];
                    int take = 0;
                    if (target >= num[index])
                        take = dp[index - 1, target - num[index]];

                    dp[index, target] = take + notTake;
                }
            }
            return dp[n - 1, tar];
        }

        // Space optimization
        // TC -> O(N * target)
        // SC -> O(target) 
        public static int findWays4(int[] num, int tar)
        {
            int n = num.Length;
            int[] prev = new int[tar + 1];

            // base cases
            prev[0] = 1;

            if (num[0] <= tar) prev[num[0]] = 1;

            for (int index = 1; index < n; index++)
            {
                int[] cur = new int[tar + 1];
                cur[0] = 1;
                for (int target = 1; target <= tar; target++) // target = 0 will also work -> video ma 0 thi karyu chhe ne DP 14 ma 1 thi karyu tu
                {
                    int notTake = prev[target];
                    int take = 0;
                    if (target >= num[index])
                        take = prev[target - num[index]];

                    cur[target] = take + notTake;
                }
                prev = cur;
            }
            return prev[tar];
        }
    }
}
