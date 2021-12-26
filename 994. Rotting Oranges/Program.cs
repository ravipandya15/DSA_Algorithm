using System;
using System.Collections.Generic;

namespace _994._Rotting_Oranges
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("994. Rotting Oranges");
            Console.ReadLine();
        }

        public static int OrangesRotting(int[][] grid)
        {
            if (grid == null || grid.Length == 0) return 0;
            int m = grid.Length;
            int n = grid[0].Length;
            int time = 0, totalOranges = 0, rottenOranges = 0;
            Queue<int[]> q = new Queue<int[]>();

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] != 0) totalOranges++;
                    if (grid[i][j] == 2) q.Enqueue(new int[] { i, j });
                }
            }

            if (totalOranges == 0) return 0;

            int[] dx = { 0, 0, 1, -1 };
            int[] dy = { 1, -1, 0, 0 };

            while (q.Count > 0)
            {
                int k = q.Count;
                rottenOranges += k;
                while (k > 0)
                {
                    int[] point = q.Peek();
                    q.Dequeue();
                    for (int i = 0; i < 4; i++)
                    {
                        int x = point[0], y = point[1];
                        int nx = x + dx[i], ny = y + dy[i];
                        if (nx < 0 || nx >= m || ny < 0 || ny >= n || grid[nx][ny] != 1) continue;
                        grid[nx][ny] = 2;
                        q.Enqueue(new int[] { nx, ny });
                    }
                    k--;
                }
                if (q.Count > 0) time++;
            }

            return (totalOranges == rottenOranges) ? time : -1;
        }
    }
}
