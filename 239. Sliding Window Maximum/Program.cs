using System;
using System.Collections.Generic;

namespace _239._Sliding_Window_Maximum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("239. Sliding Window Maximum");
            //int[] arr = { 1, 3, -1, -3, 5, 3, 6, 7 };
            //int k = 3;
            int[] arr = { 1, -1};
            int k = 1;

            var result = MaxSlidingWindow(arr, k);
            Console.ReadLine();
        }

        // TC -> O(N) + O(N) = O(N)
        // SC -> O(K) -> at max deque will store k element
        public static int[] MaxSlidingWindow(int[] nums, int k)
        {
            int n = nums.Length;
            int[] ans = new int[n - k + 1];
            LinkedList<int> deque = new LinkedList<int>();
            int ri = 0;

            for (int i = 0; i < n; i++)
            {
                while (deque.Count > 0 && deque.First.Value == i - k)
                    deque.RemoveFirst();

                while (deque.Count > 0 && nums[deque.Last.Value] < nums[i])
                    deque.RemoveLast();

                deque.AddLast(i);

                if (i >= k - 1)
                    ans[ri++] = nums[deque.First.Value];
            }
            return ans;
        }
    }
}
