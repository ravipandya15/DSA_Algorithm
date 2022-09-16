using System;

namespace _1155._Number_of_Dice_Rolls_With_Target_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int count = numRollsToTarget(1, 6, 3);
            Console.WriteLine($"ans is {count}");
        }

        public static long solve(int n, int k, int target, long[,] dp)
        {
            int mod = (int)1e9 + 7;
            // base case
            if (n == 0 && target == 0) return 1;
            if (n == 0 || target == 0) return 0;

            if (dp[n, target] != -1) return dp[n, target];

            long count = 0;
            for (int i = 1; i <= k; i++)
            {
                if (target - i >= 0) count = count + solve(n - 1, k, target - i, dp) % mod;
            }
            return dp[n, target] = count % mod;
        }

        // memoization
        // TC -> O(N * target * k)
        // SC -> O(N * target) + O(N * target) - Auxilary stack space
        public int numRollsToTarget(int n, int k, int target)
        {
            long[,] dp = new long[n + 1, target + 1];

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= target; j++)
                {
                    dp[i, j] = -1;
                }
            }
            return (int)solve(n, k, target, dp);
        }

        //tabulation
        // TC -> O(N * target * k)
        // SC -> O(N * target)
        public int numRollsToTarget_1(int n, int k, int target)
        {
            int mod = (int)1e9 + 7;
            long[,] dp = new long[n + 1, target + 1];

            // base case
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= target; j++)
                {
                    if (i == j) dp[i, j] = 1;
                }
            }

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= target; j++)
                {
                    if (i == 0 || j == 0) continue;
                    long count = 0;
                    for (int l = 1; l <= k; l++)
                    {
                        if (j - l >= 0) count = count + dp[i - 1, j - l] % mod;
                    }
                    dp[i, j] = count % mod;
                }
            }
            return (int)dp[n, target];
        }
    }
}
