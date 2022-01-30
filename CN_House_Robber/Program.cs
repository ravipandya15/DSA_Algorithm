using System;
using System.Collections.Generic;

namespace CN_House_Robber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_House_Robber");
        }

        // space optimization
        // TC -> O(N)
        // SC -> O(1)
        public static long MaximumNonAdjacentSum4(List<int> nums)
        {
            // Write your code here.
            int n = nums.Count;
            long prev2 = 0;
            long prev = nums[0];

            for (int i = 1; i < n; i++)
            {
                long pick = nums[i];
                if (i - 2 >= 0) pick += prev2;

                long not_pick = prev;

                long curi = Math.Max(pick, not_pick);

                prev2 = prev;
                prev = curi;
            }

            return prev;
        }

        public static long houseRobber(int[] valueInHouse)
        {
            // Write your code here.
            int n = valueInHouse.Length;
            if (n == 1) return valueInHouse[0];

            List<int> arr1 = new List<int>();
            List<int> arr2 = new List<int>();


            for (int i = 0; i < n; i++)
            {
                if (i != 0) arr1.Add(valueInHouse[i]);
                if (i != n - 1) arr2.Add(valueInHouse[i]);
            }

            return Math.Max(MaximumNonAdjacentSum4(arr1), MaximumNonAdjacentSum4(arr2));
        }
    }
}
