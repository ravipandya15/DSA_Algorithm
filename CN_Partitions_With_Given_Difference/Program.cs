using System;

namespace CN_Partitions_With_Given_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Partitions_With_Given_Difference");
        }

        public static int solve1(int index, int target, int[] arr, int[,] dp, int mod)
        {
            // base cases
            if (index == 0)
            {
                if (target == 0 && arr[0] == 0) return 2;
                if (target == 0 || target == arr[0]) return 1;
                else return 0;
            }

            if (dp[index,target] != -1) return dp[index,target];

            // explore possiblities of that index
            int notTake = solve1(index - 1, target, arr, dp, mod);
            int take = 0;
            if (target >= arr[index])
                take = solve1(index - 1, target - arr[index], arr, dp, mod);

            return dp[index,target] = (notTake + take) % mod;
        }


        public static int findWays2(int[] num, int tar, int mod)
        {
            int[,] dp = new int[num.Length,tar + 1];
            for (int i = 0; i < num.Length; i++)
            {
                for (int j = 0; j <= tar; j++)
                {
                    dp[i, j] = -1;
                }
            }

            return solve1(num.Length - 1, tar, num, dp, mod);
        }

        // Memoization
        // TC -> O(N * target)
        // SC -> O(N) + O(N * target)
        public static int countPartitions1(int n, int d, int[] arr)
        {
            int mod = (int)(1e9 + 7);
            int totalSum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                totalSum += arr[i];
            }

            if (totalSum - d < 0 || (totalSum - d) % 2 == 1) return 0;
            return findWays2(arr, (totalSum - d) / 2, mod);
        }

        // Tabulation
        // TC -> O(N * target)
        // SC -> O(N * target) 
        public static int findWays3(int[] num, int tar, int mod)
        {
            int n = num.Length;
            int[,] dp = new int[n,tar + 1];

            // base cases
            if (num[0] == 0) dp[0,0] = 2;
            else dp[0,0] = 1;

            if (num[0] != 0 && num[0] <= tar) dp[0,num[0]] = 1;

            for (int index = 1; index < n; index++)
            {
                for (int target = 0; target <= tar; target++) // target = 0 will also work -> video ma 0 thi karyu chhe ne DP 14 ma 1 thi karyu tu
                {
                    int notTake = dp[index - 1,target];
                    int take = 0;
                    if (target >= num[index])
                        take = dp[index - 1,target - num[index]];

                    dp[index,target] = (take + notTake) % mod;
                }
            }
            return dp[n - 1,tar];
        }

        public static int countPartitions2(int n, int d, int[] arr)
        {
            int mod = (int)1e9 + 7;
            int totalSum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                totalSum += arr[i];
            }

            if (totalSum - d < 0 || (totalSum - d) % 2 == 1) return 0;
            return findWays3(arr, (totalSum - d) / 2, mod);
        }
    }
}
