using System;
using System.Collections.Generic;

namespace CN__Painter_s_Partition_Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Painter's Partition Problem");
            List<int> boards = new List<int>() { 2, 1, 5, 6, 2, 3 };
            int k = 2; // no. of painters
            Console.WriteLine($"Answer is {FindLargestMinDistance(boards, k)}");
            Console.ReadLine();
        }

        public static bool IsPossible(List<int> arr, int k, int mid)
        {
            int painterCount = 1;
            int currentTime = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                if (currentTime + arr[i] <= mid)
                {
                    currentTime += arr[i];
                }
                else
                {
                    painterCount++;
                    if (painterCount > k || arr[i] > mid)
                    {
                        return false;
                    }

                    currentTime = 0;
                    currentTime += arr[i];
                }
            }
            return true;
        }

        public static int FindLargestMinDistance(List<int> boards, int k)
        {
            int start = 0;
            int sum = 0;
            for (int i = 0; i < boards.Count;i++)
            {
                sum += boards[i];
            }
            int end = sum;

            int mid = start + (end - start) / 2;
            int ans = -1;

            while (start <= end)
            {
                if (IsPossible(boards, k, mid))
                {
                    ans = mid;
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
                mid = start + (end - start) / 2;
            }

            return ans;
        }
    }
}
