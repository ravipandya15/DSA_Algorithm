using System;
using System.Linq;

namespace Search_Insert_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1 };
            int target = 0;
            int answer = FindInsertPosition(nums, target);
            Console.WriteLine($"Answer is {answer}");
            Console.ReadLine();
        }

        public static int FindInsertPosition(int[] nums, int target)
        {
            int result = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] >= target)
                {
                    result = i;
                    return result;
                }
            }

            if (result == -1)
            {
                return nums.Length;
            }
            return result;
        }
    }
}
