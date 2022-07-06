using System;

namespace Jump_Game_II_45
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Jump_Game_II_45");

            // [2,3,1,1,4]
            //[2,3,0,1,4]
            int[] nums = new int[] { 2,3,1,1,4 };
            int ans = jump_2(nums);
            Console.WriteLine($"ans is {ans}");
        }

        public static int jump_2(int[] nums)
        {
            int n = nums.Length;
            int[] dp = new int[n];
            dp[n-1] = 0;

            for (int index = n - 2; index >= 0; index--)
            {
                int jumps = 1000;
                for (int i = 1; i <= nums[index]; i++)
                {
                    if (index + i <= n)
                    {
                        jumps = Math.Min(jumps, dp[index + i] + 1);
                    }
                }

                dp[index] = jumps;
            }

            return dp[0];
        }
    }
}
