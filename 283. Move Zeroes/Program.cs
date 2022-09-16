using System;

namespace _283._Move_Zeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("283. Move Zeroes");
            int[] arr = { 2, 9, 0, 5, 4, 0, 10, 0, 0, 0, 3, 8, 0, 1, 0, 0, 6 };
            MoveZeroes(arr);
            Console.ReadLine();
        }

        public static void MoveZeroes(int[] nums)
        {
            // we also need to maintain relative order of the non - zero elements in nums 
            int i = 0;
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] != 0)
                {
                    // swap
                    int temp = nums[i];
                    nums[i] = nums[j];
                    nums[j] = temp;
                    i++;
                }
            }
        }
    }
}
