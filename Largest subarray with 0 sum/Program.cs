using System;
using System.Collections.Generic;

namespace Largest_subarray_with_0_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Largest subarray with 0 sum");
            int[] nums = new int[] { 1, -1, 3, 2, -2, -8, 1, 7, 10, 23 };
            Console.WriteLine($"Answer is {LargestSetWithSumZero(nums)}");
            Console.ReadLine();
        }

        // returns length of larget sub array with sum 0
        // TC -> O(NLogN) -> logN due to dictionary (HashMap)
        // space complexity -> O(N)
        public static int LargestSetWithSumZero(int[] nums)
        {
            int maxi = 0;
            int sum = 0;
            Dictionary<int, int> hashMap = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if (sum == 0)
                {
                    maxi = i + 1;
                }
                else
                {
                    if (hashMap.TryGetValue(sum, out int temp)) // will get index in temp
                    {
                        maxi = Math.Max(maxi, i - temp);
                    }
                    else
                    {
                        hashMap.Add(sum, i);
                    }
                }
            }

            return maxi;
        }
    }
}
