using System;

namespace CN_Partition_Equal_Subset_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Partition_Equal_Subset_Sum");
        }

        // Tabulation
        // TC -> O(N * target)
        // SC -> O(N) + O(N * target) 
        public static bool subsetSumToK(int n, int k, int[] arr)
        {
            bool[,] dp = new bool[n, k + 1];

            // base cases
            for (int i = 0; i < n; i++)
            {
                dp[i, 0] = true;
            }

            dp[0, arr[0]] = true;

            for (int index = 1; index < n; index++)
            {
                for (int target = 1; target <= k; target++)
                {
                    bool notTake = dp[index - 1, target];
                    bool take = false;
                    if (target >= arr[index])
                        take = dp[index - 1, target - arr[index]];

                    dp[index, target] = take || notTake;
                }
            }
            return dp[n - 1, k];
        }

        // same code as SubsetSum equal to K
        public static bool canPartition(int[] arr, int n)
        {
            int totalSum = 0;
            for (int i = 0; i < n; i++)
            {
                totalSum += arr[i];
            }

            if (totalSum % 2 != 0) return false;
            int k = totalSum / 2;
            return subsetSumToK(n, k, arr);
        }
    }
}
