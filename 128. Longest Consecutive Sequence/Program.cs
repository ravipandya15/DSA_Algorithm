using System;
using System.Collections.Generic;

namespace _128._Longest_Consecutive_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("128. Longest Consecutive Sequence");
            //int[] nums = new int[] { 102, 4, 100, 1, 101, 3, 2 };
            int[] nums = new int[] { 5, 4, 3, 2, 1 };
            Console.WriteLine($"Answer is {LongestConsecutive(nums)}");
            Console.ReadLine();
        }

        // Time complexity -> O(N) + O(N) + O(N)
        // space complexity -> O(N)
        public static int LongestConsecutive(int[] nums)
        {
            SortedSet<int> sortedSet = new SortedSet<int>();
            foreach (int num in nums)
            {
                sortedSet.Add(num);
            }

            int longestStreak = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (!sortedSet.Contains(nums[i] - 1))
                {
                    int currentStreak = 1;
                    int currentVale = nums[i];

                    while (sortedSet.Contains(currentVale + 1))
                    {
                        currentStreak++;
                        currentVale++;
                    }

                    longestStreak = Math.Max(longestStreak, currentStreak);
                }
            }

            return longestStreak;
        }
    }
}

