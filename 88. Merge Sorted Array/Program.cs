using System;

namespace _88._Merge_Sorted_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("88. Merge Sorted Array");
            int[] nums1 = new int[] { 1, 3, 7, 0, 0, 0 };
            int[] nums2 = new int[] { 2, 4, 5 };
            int m = 3, n = 3;
            Merge(nums1, m, nums2, n);
            Console.ReadLine();
        }

        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int i = m - 1, j = n - 1, k = m + n - 1;
            while (i >= 0 && j >= 0)
            {
                if (nums1[i] < nums2[j])
                    nums1[k--] = nums2[j--];
                else
                    nums1[k--] = nums1[i--];
            }

            while (j >= 0)
                nums1[k--] = nums2[j--];
        }

        public static void Merge1(int[] nums1, int m, int[] nums2, int n)
        {
            for (int i = m; i < m + n; i++)
            {
                nums1[i] = nums2[i - m];
            }

            Array.Sort(nums1);
        }

        public static void Merge2(int[] nums1, int m, int[] nums2, int n)
        {
            int[] result = new int[m + n];
            int i = 0, j = 0, k = 0;
            while (i < m && j < n)
            {
                if (nums1[i] < nums2[j])
                    result[k++] = nums1[i++];
                else
                    result[k++] = nums2[j++];
            }

            while (i < m) // check if any element is remaining in 1st array
            {
                result[k++] = nums1[i++];
            }

            while (j < n) // check if any element is remaining in 2nd array
            {
                result[k++] = nums2[j++];
            }
        }
    }
}
