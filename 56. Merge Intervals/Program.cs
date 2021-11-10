using System;
using System.Collections.Generic;
using System.Linq;

namespace _56._Merge_Intervals
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("56. Merge Intervals");
            int[][] intervals = new int[8][]
            {
                new int[] {1, 3},
                new int[] {2, 6},
                new int[] {8, 10},
                new int[] {8, 9},
                new int[] {9, 11},
                new int[] {15, 18},
                new int[] {2, 4},
                new int[] {16, 17},
            };
            int[][] mergedList = Merge(intervals);
            Console.ReadLine();
        }

        public static int[][] Merge(int[][] intervals)
        {
            List<int[]> mergedList = new List<int[]>();
            if (intervals == null || intervals.Length == 0)
            {
                return intervals;
            }
            intervals = intervals.OrderBy(x => x[0]).ThenBy(x => x[1]).ToArray();
            int[] tempItem = intervals[0];
            foreach (var item in intervals)
            {
                if (item[0] <= tempItem[1])
                {
                    tempItem[1] = Math.Max(item[1], tempItem[1]);
                }
                else
                {
                    mergedList.Add(new int[] { tempItem[0], tempItem[1]});
                    tempItem = item;
                }
            }
            mergedList.Add(new int[] { tempItem[0], tempItem[1] });
            return mergedList.ToArray();
        }
    }
}
