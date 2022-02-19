using System;
using System.Collections.Generic;

namespace GFG_Sum_of_Minimum_and_Maximum_of_all_SubArrays_of_Size_K
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GFG_Sum_of_Minimum_and_Maximum_of_all_SubArrays_of_Size_K");

            int[] arr = { 2, 5, -1, 7, -3, -1, -2 };
            int k = 4;
            int ans = sumOfKSubArray(arr, k);

            Console.WriteLine($"result is {ans}");
        }

        public static int sumOfKSubArray(int[] arr, int k)
        {
            int n = arr.Length;
            LinkedList<int> maxi = new LinkedList<int>(); // -> store value in decreasing order
            LinkedList<int> mini = new LinkedList<int>(); // -> store value in increasing order

            // process 1st window of size k
            for (int i = 0; i < k; i++)
            {
                while (maxi.Count > 0 && arr[maxi.Last.Value] <= arr[i])
                    maxi.RemoveLast();

                while (mini.Count > 0 && arr[mini.Last.Value] >= arr[i])
                    mini.RemoveLast();

                maxi.AddLast(i);
                mini.AddLast(i);
            }

            int ans = arr[maxi.First.Value] + arr[mini.First.Value];

            // process for remaining elements
            for (int i = k; i < n; i++)
            {
                // remove out of index elements (indexs)
                while (maxi.Count > 0 && i - maxi.First.Value >= k)
                    maxi.RemoveFirst();

                while (mini.Count > 0 && i - mini.First.Value >= k)
                    mini.RemoveFirst();

                while (maxi.Count > 0 && arr[maxi.Last.Value] <= arr[i])
                    maxi.RemoveLast();

                while (mini.Count > 0 && arr[mini.Last.Value] >= arr[i])
                    mini.RemoveLast();

                maxi.AddLast(i);
                mini.AddLast(i);

                ans += arr[maxi.First.Value] + arr[mini.First.Value];
            }

            return ans;
        }
    }
}
