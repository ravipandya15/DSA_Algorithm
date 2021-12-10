using System;
using System.Collections.Generic;

namespace _442._Find_All_Duplicates_in_an_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("442. Find All Duplicates in an Array");
            int[] nums = { 4, 3, 2, 7, 8, 2, 3, 1 };
            var result = FindDuplicates(nums);
            Console.ReadLine();
        }

        public static IList<int> FindDuplicates(int[] nums)
        {
            IList<int> result = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[Math.Abs(nums[i]) - 1] < 0)
                    result.Add(Math.Abs(nums[i]));
                else
                    nums[Math.Abs(nums[i]) - 1] = -nums[Math.Abs(nums[i]) - 1];
            }
            return result;
        }
    }
}
