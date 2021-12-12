using System;
using System.Collections.Generic;

namespace CN__Aggressive_Cows
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN__Aggressive_Cows");
            List<int> stalls = new List<int>() { 4, 2, 1, 3, 6 };
            int k = 2;
            Console.WriteLine($"answer is {AggressiveCows(stalls, k)}");
            Console.ReadLine();
        }

        public static bool IsPossible(List<int> stalls, int k, int mid)
        {
            int cowCount = 1;
            int lastPos = stalls[0];

            for (int i = 0; i < stalls.Count; i++)
            {
                if (stalls[i] - lastPos >= mid)
                {
                    cowCount++;
                    if (cowCount == k)
                    {
                        return true;
                    }
                    lastPos = stalls[i];
                }
            }
            return false;
        }

        public static int AggressiveCows(List<int> stalls, int k)
        {
            stalls.Sort();
            int start = 0;
            int maxi = -1;
            for (int i = 0; i < stalls.Count; i++)
            {
                maxi = Math.Max(maxi, stalls[i]);
            }
            int end = maxi;
            int ans = -1;
            int mid = start + (end - start) / 2;
            while (start <= end)
            {
                if (IsPossible(stalls, k, mid))
                {
                    ans = mid;
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
                mid = start + (end - start) / 2;
            }
            return ans;
        }
    }
}
