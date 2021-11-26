using System;

namespace _189._Rotate_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("189. Rotate Array");
            int[] nums = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            int k = 3;
            Rotate(nums, k);

            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write($"{nums[i]} ");
            }
            Console.ReadLine();
        }

        public static void Rotate(int[] nums, int k)
        {
            k = k % nums.Length;

            reverse(nums, 0, nums.Length - 1);
            reverse(nums, 0, k - 1);
            reverse(nums, k, nums.Length - 1);
        }

        public static void reverse(int[] nums, int start, int end)
        {
            while (start < end)
            {
                int temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
                start++;
                end--;
            }
        }
    }
}
