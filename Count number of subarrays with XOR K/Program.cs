using System;
using System.Collections.Generic;

namespace Count_number_of_subarrays_with_XOR_K
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Count number of subarrays with given Xor K");
            int[] nums = new int[] { 4, 2, 2, 6, 4 };
            int B = 6;
            Console.WriteLine($"Answer is {SubArrayWithGivenXORK(nums, 6)}");
            Console.ReadLine();
        }

        // find total number of sub arrays with have xor equals to b -> hear 6
        public static int SubArrayWithGivenXORK(int[] nums, int B)
        {
            int count = 0;
            int xor = 0;
            Dictionary<int, int> hashMap = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                xor = xor ^ nums[i];

                if (xor == B)
                    count++;

                if (hashMap.TryGetValue(xor ^ B, out int temp))
                    count += temp;

                if (hashMap.TryGetValue(xor, out int temp2))
                    hashMap[xor] = temp2 + 1;
                else
                    hashMap.Add(xor, 1);
            }
            return count;
        }
    }
}
