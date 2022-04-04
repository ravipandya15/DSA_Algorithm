using System;

namespace _643._Maximum_Average_Subarray_I
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("643. Maximum Average Subarray I");
            int[] arr = { -1 };
            int k = 1;
            double ans = FindMaxAverage(arr, k);
        }

        public static double FindMaxAverage(int[] nums, int k)
        {
            int n = nums.Length;
            double sum = 0;
            double maxi = Double.MinValue;
            int i = 0, j = 0;
            while (j < n)
            {
                sum += nums[j];
                if (j - i + 1 < k)
                {
                    j++;
                }
                else if (j - i + 1 == k)
                {
                    maxi = Math.Max(maxi, sum);
                    sum = sum - nums[i];
                    i++;
                    j++;
                }
            }

            return maxi / k;
        }
    }
}
