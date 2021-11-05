using System;

namespace _1920._Build_Array_from_Permutation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1920. Build Array from Permutation in constant time O(1)");
            int[] nums = new int[] { 0, 2, 1, 5, 3, 4 };
            Console.WriteLine($"Ans is {BuildArray(nums)}");
            Console.ReadLine();
        }

        public static int[] BuildArray(int[] nums)
        {
            int[] ans = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                ans[i] = nums[nums[i]];
            }
            return ans;
        }
    }
}
