using System;

namespace _26._Remove_Duplicates_from_Sorted_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("26. Remove Duplicates from Sorted Array");
            int[] nums = new int[] { 1, 1, 2, 2, 2, 3, 3 };
            Console.WriteLine($"Answer is {RemoveDuplicates(nums)}");
            Console.ReadLine();
        }
        // apprach 1 
        // using sorted set
        // TC -> O(NLogN) + O(N)
        // SC -> O(N)

        // TC -> O(N)
        // SC -> O(1)
        // 2 pointer approach
        public static int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0)
                return 0;

            int i = 0;
            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[j] != nums[i])
                {
                    i++;
                    nums[i] = nums[j];
                }
            }

            return i + 1;
        }
    }
}
