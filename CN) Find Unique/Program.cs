using System;

namespace CN__Find_Unique
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Find Unique");
            int[] arr = { 3, 2, 1, 2, 3 };
            Console.WriteLine($"Answer is {FindUnique(arr)}");
            Console.ReadLine();
        }

        // TC -> O(N)
        // SC -> O(1)
        public static int FindUnique(int[] arr)
        {
            int ans = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                ans = ans ^ arr[i];
            }
            return ans;
        }
    }
}
