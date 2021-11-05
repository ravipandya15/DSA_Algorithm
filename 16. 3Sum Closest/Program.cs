using System;

namespace _16._3Sum_Closest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("16. 3Sum Closest");
            int[] nums = new int[] { 0, 0, 0 };
            int target = 1;
            Console.WriteLine($"Result is {ThreeSumClosest(nums, target)}");
            Console.ReadLine();
        }

        public static int ThreeSumClosest(int[] nums, int target)
        {
            int result = nums[0] + nums[1] + nums[nums.Length - 1];
            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 2; i++)
            {
                int start = i + 1, end = nums.Length - 1;
                while (start < end)
                {
                    int sum = nums[i] + nums[start] + nums[end];
                    if (sum > target)
                    {
                        end--;
                    }
                    else
                    {
                        start++;
                    }

                    if (Math.Abs(sum - target) < Math.Abs(result - target))
                    {
                        result = sum;
                    }
                }
            }

            return result;
        }
    }
}
