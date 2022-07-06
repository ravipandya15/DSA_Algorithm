using System;

namespace _452._Minimum_Number_of_Arrows_to_Burst_Balloons
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("452. Minimum Number of Arrows to Burst Balloons");
            //[[-2147483646,-2147483645],[2147483646,2147483647]]
            int[][] points = new int[][]
            {
                new int[] { -2147483646,-2147483645 },
                new int[] { 2147483646, 2147483647 }
            };

            int arrows = findMinArrowShots(points);
            Console.WriteLine("total arrows required are :", arrows);
        }

        public static int findMinArrowShots(int[][] points)
        {
            int n = points.Length;
            if (points.Length == 0) return 0;

            Array.Sort(points, (a, b) => b[1] - a[1]); // what if we compare based on starting index?
            int end = points[0][1];
            int arrows = 1;

            for (int i = 1; i < n; i++)
            {
                if (points[i][0] > end)
                {
                    arrows++;
                    end = points[i][1];
                }
            }

            return arrows;
        }
    }
}
