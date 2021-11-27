using System;

namespace _485._Max_Consecutive_Ones
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("485. Max Consecutive Ones");
            Console.ReadLine();
        }

        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            int count = 0;
            int max = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    count++;
                }
                else
                {
                    // it means it's 0. then make count to 0.
                    count = 0;
                }
                max = Math.Max(max, count);
            }
            return max;
        }
    }
}
