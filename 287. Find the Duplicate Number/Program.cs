using System;

namespace _287._Find_the_Duplicate_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("287. Find the Duplicate Number");
            int[] nums = new int[] { 2, 5, 9, 6, 9, 3, 8, 9, 7, 1 };
            Console.WriteLine($"Result is {FindDuplicate(nums)}");
            Console.ReadLine();
        }

        // time complexity -> O(N)
        // space complexity -> O(1)
        public static int FindDuplicate(int[] nums)
        {
            int slow = nums[0];
            int fast = nums[0];

            do
            {
                slow = nums[slow];
                fast = nums[nums[fast]];
            } while (slow != fast);

            fast = nums[0];
            while (slow != fast)
            {
                slow = nums[slow];
                fast = nums[fast];
            }

            return slow;
        }
    }
}
