using System;

namespace _4._Median_of_Two_Sorted_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            // Leetcode Hard problem
            Console.WriteLine("4. Median of Two Sorted Arrays");
            int[] num1 = { 7, 12, 14, 15 };
            int[] num2 = { 1, 2, 3, 4, 9, 11 };

            //int[] num1 = { 7, 12, 14, 15, 16 };
            //int[] num2 = { 1, 2, 3, 4, 9, 11 };
            Console.WriteLine($"Median is {FindMedianSortedArrays(num1, num2)}");
            Console.ReadLine();
        }

        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (nums2.Length < nums1.Length)
                return FindMedianSortedArrays(nums2, nums1); // 1st array will always be sorter

            int n1 = nums1.Length;
            int n2 = nums2.Length;

            int low = 0;
            int high = n1;

            while (low <= high)
            {
                int cut1 = (low + high) >> 1;
                int cut2 = (n1 + n2 + 1) / 2 - cut1;

                int left1 = cut1 == 0 ? Int32.MinValue : nums1[cut1 - 1];
                int left2 = cut2 == 0 ? Int32.MinValue : nums2[cut2 - 1];

                int right1 = cut1 == n1 ? Int32.MaxValue : nums1[cut1];
                int right2 = cut2 == n2 ? Int32.MaxValue : nums2[cut2];

                if (left1 <= right2 && left2 <= right1)
                {
                    // correct partition
                    if ((n1 + n2) % 2 == 0)
                    {
                        // even length 
                        return (Math.Max(left1, left2) + Math.Min(right1, right2)) / 2.0;
                    }
                    else
                    {
                        // odd length
                        return Math.Max(left1, left2);
                    }
                }
                else if (left1 > right2)
                {
                    high = cut1 - 1;
                }
                else
                {
                    low = cut1 + 1;
                }
            }
            return 0.0;
        }
    }
}
