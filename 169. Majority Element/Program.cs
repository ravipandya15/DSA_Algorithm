using System;

namespace _169._Majority_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("169. Majority Element");
            int[] nums = new int[] { 7, 7, 5, 7, 1, 5, 7, 5, 5, 7, 7, 5, 5, 5, 5 };
            Console.WriteLine($"answer is {MajorityElement(nums)}");
            Console.ReadLine();
        }

        // Moore's Voting alrorithm
        // time complexity -> O(N)
        // space complexity -> O(1)
        public static int MajorityElement(int[] nums)
        {
            int count = 0;
            int el = 0;
            for(int i = 0; i < nums.Length; i++)
            {
                if (count == 0)
                {
                    el = nums[i];
                }
                if (el == nums[i]) // if (nums[i] == el)
                {
                    count++;
                }
                else
                {
                    count--;
                }
            }
            return el;
        }
    }
}
