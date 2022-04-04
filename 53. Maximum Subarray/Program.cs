using System;

namespace _53._Maximum_Subarray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("53. Maximum Subarray");
            //int[] nums = new int[] { 5, 4, -1, 7, 8 };
            int[] nums = new int[] { -5, -4, -3, -2, -1 };
            Console.WriteLine($"result is {MaxSubArray(nums)}");
            Console.ReadLine();
        }

        // kadane's algorithm
        // used to find maximum sum of sub array(continues (containing min 1 number)) from the array.
        public static int MaxSubArray(int[] nums)
        {
            int max = nums[0];
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if (sum > max) { max = sum; }
                if (sum < 0)
                {
                    sum = 0;
                }
            }
            return max;
        }

        // O(N ^ 3)
        public static int MaxSubArray1(int[] nums)
        {
            int max = nums[0];
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i; j < nums.Length; j++)
                {
                    sum = 0;
                    for (int k = i; k <= j; k++)
                    {
                        sum += nums[k];
                    }
                    if (sum > max) { max = sum; }
                }
            }
            return max;
        }

        // O (N ^ 2)
        public static int MaxSubArray2(int[] nums)
        {
            int max = nums[0];
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum = 0;
                for (int j = i; j < nums.Length; j++)
                {
                    sum += nums[j];
                    if (sum > max)
                    {
                        max = sum;
                    }
                }
            }

            return max;
        }
    }
}
