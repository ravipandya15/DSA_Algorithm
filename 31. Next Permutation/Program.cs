using System;

namespace _31._Next_Permutation
{
    class Program
    {
        /*algorithm
        step 1 : linearly traverse from back and find number for which (a[i] > a[i + 1]) condition becomes true.
        step 2 : Again linearlt traverse from back and find a number (present at j index) for which a[j] > a[i]
        step 3 : swap a[i] and a[j]
        step 4 : reserse from (i + 1)th index to last index (n-1)
        */
        static void Main(string[] args)
        {
            Console.WriteLine("31. Next Permutation");
            int[] nums = new int[] { 1, 3, 5, 4, 2 };
            NextPermutation(nums);

            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write($"{nums[i]} ");
            }
            Console.ReadLine();
        }

        public static void NextPermutation(int[] nums)
        {
            if (nums == null || nums.Length <= 1)
            {
                return;
            }

            int i = nums.Length - 2;
            while (i >= 0 && nums[i] >= nums[i + 1])
            {
                i--;
            }
            if (i >= 0) // if i becomes -1 then we don't need to find j index
            {
                int j = nums.Length - 1;
                while (nums[j] <= nums[i])
                {
                    j--;
                }
                swap(nums, i, j);
            }
            reverse(nums, i + 1, nums.Length - 1);
        }

        public static void swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }

        public static void reverse(int[] nums, int i, int j)
        {
            while (i < j)
            {
                swap(nums, i++, j--);
            }
        }
    }
}
