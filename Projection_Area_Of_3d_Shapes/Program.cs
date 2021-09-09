using System;

namespace Projection_Area_Of_3d_Shapes
{
    class Program
    {
        public static int ProjectionArea(int[][] grid)
        {
            int n = grid.Length;
            int ans = 0;
            for (int i = 0; i < n; i++)
            {
                int rowMax = 0, colMax = 0;
                for (int j = 0; j< n; j++)
                {
                    if (grid[i][j] > 0)
                    {
                        ans++;
                    }
                    rowMax = Math.Max(rowMax, grid[i][j]);
                    colMax = Math.Max(colMax, grid[j][i]);
                }
                ans += rowMax + colMax;
            }
            return ans;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Projection Area of 3D Shapes");
            int[][] grid = new int[3][];
            grid[0] = new int[] { 2, 2, 2 };
            grid[1] = new int[] { 2 ,1, 2 };
            grid[2] = new int[] { 2 ,2 ,2 };
            Console.WriteLine($"answer is {ProjectionArea(grid)}");
        }
    }
}
