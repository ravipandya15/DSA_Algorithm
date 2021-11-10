using System;

namespace _88._Merge_Sorted_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("88. Merge Sorted Array");
            int[] nums1 = new int[] { 0 };
            int[] nums2 = new int[] { 1 };
            int m = 0, n = 1;
            Merge(nums1, m, nums2, n);
            Console.ReadLine();
        }

        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            for (int i = m; i < m + n; i++)
            {
                nums1[i] = nums2[i - m];
            }

            Array.Sort(nums1);
        }
    }
}
