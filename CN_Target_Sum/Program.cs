using System;

namespace CN_Target_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Target_Sum");
        }

        // same problem S1 - S2 = D
        //just copy that tabulation functiona and remove mod

        // Tabulation
        // TC -> O(N * target)
        // SC -> O(N * target) 
        public static int findWays3(int[] num, int tar)
        {
            int n = num.Length;
            int[,] dp = new int[n, tar + 1];

            // base cases
            if (num[0] == 0) dp[0, 0] = 2;
            else dp[0, 0] = 1;

            if (num[0] != 0 && num[0] <= tar) dp[0, num[0]] = 1;

            for (int index = 1; index < n; index++)
            {
                for (int target = 0; target <= tar; target++) // target = 0 will also work -> video ma 0 thi karyu chhe ne DP 14 ma 1 thi karyu tu
                {
                    int notTake = dp[index - 1, target];
                    int take = 0;
                    if (target >= num[index])
                        take = dp[index - 1, target - num[index]];

                    dp[index, target] = (take + notTake);
                }
            }
            return dp[n - 1, tar];
        }

        public static int countPartitions2(int n, int d, int[] arr)
        {
            int totalSum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                totalSum += arr[i];
            }

            if (totalSum - d < 0 || (totalSum - d) % 2 == 1) return 0;
            return findWays3(arr, (totalSum - d) / 2);
        }

        static int targetSum(int n, int target, int[] arr)
        {
            return countPartitions2(n, target, arr);
        }
    }
}
