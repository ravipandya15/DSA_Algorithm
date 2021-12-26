using System;

namespace _1752._Check_if_Array_Is_Sorted_and_Rotated
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1752. Check if Array Is Sorted and Rotated");
            int[] arr = { 3, 4, 5, 1, 2 };
            Console.ReadLine();
        }

        public static bool Check(int[] nums)
        {
            int n = nums.Length;
            int count = 0;
            for (int i = 1; i < n; i++)
            {
                if (nums[i - 1] > nums[i])
                    count++;
            }

            // check last element
            if (nums[n - 1] > nums[0])
                count++;

            // count must be <=1
            return count <= 1;
        }
    }
}
