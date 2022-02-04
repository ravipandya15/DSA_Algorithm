using System;

namespace CN_difference_of_subset_sums_is_Minimum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Partition_a_set_into_two_subsets_such_that_the_difference_of_subset_sums_is_Minimum");
        }

        // pre - requisist - Subset sum equal to k


        // Tabulation
        // TC -> O(N) + O(N * totalSum) + O(totalSum / 2)
        // SC -> O(N * totalSum) 
        public static int MinSubsetSumDifference1(int[] arr, int n)
        {
            int totalSum = 0;
            for (int i = 0; i < n; i++)
            {
                totalSum += arr[i];
            }
            int k = totalSum;

            bool[,] dp = new bool[n,k + 1];

            // base cases
            for (int i = 0; i < n; i++)
            {
                dp[i,0] = true;
            }

            if (arr[0] <= k) dp[0,arr[0]] = true;

            for (int index = 1; index < n; index++)
            {
                for (int target = 1; target <= k; target++)
                {
                    bool notTake = dp[index - 1,target];
                    bool take = false;
                    if (target >= arr[index])
                        take = dp[index - 1,target - arr[index]];

                    dp[index,target] = take || notTake;
                }
            }

            int Mini = (int)1e9;
            for (int s1 = 0; s1 <= totalSum / 2; s1++)
            {
                if (dp[n - 1,s1] == true)
                {
                    int s2 = k - s1;
                    Mini = Math.Min(Mini, Math.Abs(s2 - s1));
                }
            }

            return Mini;
        }

        // Space Optimization
        // TC -> O(N) + O(N * totalSum) + O(totalSum / 2)
        // SC -> O(totalSum)
        public static int MinSubsetSumDifference2(int[] arr, int n)
        {
            int totalSum = 0;
            for (int i = 0; i < n; i++)
            {
                totalSum += arr[i];
            }
            int k = totalSum;

            bool[] prev = new bool[k + 1];

            // base cases
            for (int i = 0; i < n; i++)
            {
                prev[0] = true;
            }

            if (arr[0] <= k) prev[arr[0]] = true;

            for (int index = 1; index < n; index++)
            {
                bool[] cur = new bool[k + 1];
                cur[0] = true;
                for (int target = 1; target <= k; target++)
                {
                    bool notTake = prev[target];
                    bool take = false;
                    if (target >= arr[index])
                        take = prev[target - arr[index]];

                    cur[target] = take || notTake;
                }
                prev = cur;
            }

            int Mini = (int)1e9;
            for (int s1 = 0; s1 <= totalSum / 2; s1++)
            {
                if (prev[s1] == true)
                {
                    int s2 = k - s1;
                    Mini = Math.Min(Mini, Math.Abs(s2 - s1));
                }
            }

            return Mini;
        }
    }
}
