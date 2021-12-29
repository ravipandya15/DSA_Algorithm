using System;

namespace _136._Single_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("136._Single_Number");
            int[] arr = { 2, 1, 1 };
            Console.WriteLine($"answer is {SingleNumber(arr)}");
            Console.ReadLine();
        }

        public static int SingleNumber(int[] nums)
        {
            int result = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                result = result ^ nums[i];
            }
            return result;
        }
    }
}
