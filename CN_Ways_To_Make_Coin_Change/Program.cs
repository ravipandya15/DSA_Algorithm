using System;

namespace CN_Ways_To_Make_Coin_Change
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Ways_To_Make_Coin_Change");
        }

        public static long solve(int index, int target, int[] arr)
        {
            // base case
            if (index == 0)
            {
                if ((target % arr[0]) == 0)
                    return 1;
                else
                    return 0;
            }

            long notTake = solve(index - 1, target, arr);
            long take = 0;
            if (arr[index] <= target)
                take = solve(index, target - arr[index], arr);

            return notTake + take;
        }

        // Recursion
        // TC -> >> O(2^N) -> Exponential
        // SC -> >> O(N) -> if min. coin is of 1 then O(Target)
        public static long countWaysToMakeChange1(int[] denominations, int value)
        {
            int n = denominations.Length;
            return solve(n - 1, value, denominations);
        }

        public static long solve1(int index, int target, int[] arr, long[,] dp)
        {
            // base case
            if (index == 0)
            {
                if ((target % arr[0]) == 0)
                    return 1;
                else
                    return 0;
            }

            if (dp[index,target] != -1) return dp[index,target];

            long notTake = solve1(index - 1, target, arr, dp);
            long take = 0;
            if (arr[index] <= target)
                take = solve1(index, target - arr[index], arr, dp);

            return dp[index,target] = notTake + take;
        }

        // Memoization
        // TC -> >> O(n * value)
        // SC -> >> O(n * value) + O(N)
        public static long countWaysToMakeChange2(int[] denominations, int value)
        {
            int n = denominations.Length;
            long[,] dp = new long[n,value + 1];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= value; j++)
                {
                    dp[i, j] = -1;
                }
            }
            return solve1(n - 1, value, denominations, dp);
        }

        // Tabulation
        // TC -> >> O(n * value)
        // SC -> >> O(n * value)
        public static long countWaysToMakeChange3(int[] denominations, int value)
        {
            int n = denominations.Length;
            long[,] dp = new long[n,value + 1];

            // base case
            for (int T = 0; T <= value; T++)
            {
                if (T % denominations[0] == 0)
                {
                    dp[0,T] = 1;
                }
            }

            for (int index = 1; index < n; index++)
            {
                for (int T = 0; T <= value; T++)
                {
                    long notTake = dp[index - 1,T];
                    long take = 0;
                    if (denominations[index] <= T)
                        take = dp[index,T - denominations[index]];

                    dp[index,T] = notTake + take;
                }
            }

            return dp[n - 1,value];
        }

        // Space Optimization
        // TC -> >> O(n * value)
        // SC -> >> O(value)
        public static long countWaysToMakeChange4(int[] denominations, int value)
        {
            int n = denominations.Length;
            long[] prev = new long[value + 1];

            // base case
            for (int T = 0; T <= value; T++)
            {
                if (T % denominations[0] == 0)
                {
                    prev[T] = 1;
                }
            }

            for (int index = 1; index < n; index++)
            {
                long[] cur = new long[value + 1];
                for (int T = 0; T <= value; T++)
                {
                    long notTake = prev[T];
                    long take = 0;
                    if (denominations[index] <= T)
                        take = cur[T - denominations[index]];

                    cur[T] = notTake + take;
                }
            }

            return prev[value];
        }
    }
}
