using System;

namespace _41._First_Missing_Positive
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] arr = { -5 };
            Console.WriteLine($"first missing number is {firstMissingPositive(arr)}");
        }

        public static int firstMissingPositive(int[] nums)
        {
            // Ans will always in range of [1, n+1] where n is length of array
            int n = nums.Length;
            // change negative value to 0
            for (int i = 0; i < n; i++)
            {
                if (nums[i] < 0) nums[i] = 0;
            }

            // which ever value is covered, change the val - 1 position to -ve number
            for (int i = 0; i < n; i++)
            {
                int val = Math.Abs(nums[i]);
                if (val - 1 >= 0 && val - 1 < n)
                {
                    if (nums[val - 1] > 0)
                    {
                        nums[val - 1] *= -1;
                    }
                    else if (nums[val - 1] == 0)
                    {
                        nums[val - 1] = -(n + 1);
                    }
                }
            }

            for (int i = 1; i <= n; i++)
            {
                if (nums[i - 1] >= 0) return i;
            }
            return n + 1;
        }
    }
}
