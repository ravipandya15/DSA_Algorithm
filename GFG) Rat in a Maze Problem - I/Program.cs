using System;
using System.Collections.Generic;

namespace GFG__Rat_in_a_Maze_Problem___I
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GFG) Rat in a Maze Problem - I ");
            int[][] m = new int[][]
            {
                new int[] {1,0,0,0 },
                new int[] {1,1,0,1 },
                new int[] {1,1,0,0 },
                new int[] {0,1,1,1 },
            };
            var result = FindPath(m, 4);
            Console.ReadLine();
        }

        // approach - 2
        public static IList<string> FindPath(int[][] m, int n)
        {
            IList<string> ans = new List<string>();
            int[,] visited = new int[n, n];
            string move = "";
            int[] di = { 1, 0, 0, -1 };
            int[] dj = { 0, -1, 1, 0 };
            if (m[0][0] == 1) Solve(0, 0, m, visited, di, dj, move, n, ans);
            return ans;
        }

        public static void Solve(int i, int j, int[][] m, int[,] visited, int[] di, int[] dj,
                                string move, int n, IList<string> ans)
        {
            // base condition
            if (i == n - 1 && j == n - 1)
            {
                ans.Add(new string(move));
                //ans.Add(move); //this will also work
                return;
            }

            string dir = "DLRU";
            for (int ind = 0; ind < 4; ind++) // loop for 4 direction
            {
                int nexti = i + di[ind];
                int nextj = j + dj[ind];
                if (nexti >= 0 && nexti < n && nextj >= 0 && nextj < n // check for all boundry cases
                    && m[nexti][nextj] == 1 && visited[nexti, nextj] != 1)
                {
                    visited[i, j] = 1;
                    Solve(nexti, nextj, m, visited, di, dj, move + dir[ind], n, ans);
                    visited[i, j] = 0;
                }
            }
        }

        //approach -1 
        public static IList<string> FindPath1(int[][] m, int n)
        {
            IList<string> ans = new List<string>();
            int[,] visited = new int[n, n];
            string move = "";
            if (m[0][0] == 1) Solve1(0, 0, m, visited, move, n, ans);
            return ans;
        }

        //approach -1 
        public static void Solve1(int i, int j, int[][] m, int[,] visited, string move, int n, IList<string> ans)
        {
            // base condition
            if (i == n - 1 && j == n - 1)
            {
                ans.Add(new string(move));
                return;
            }

            // lexicographical order -> DLRU
            // down
            if (i + 1 < n && m[i + 1][j] == 1 && visited[i + 1, j] != 1)
            {
                visited[i, j] = 1;
                Solve1(i + 1, j, m, visited, move + 'D', n, ans);
                visited[i, j] = 0;
            }

            // left
            if (j - 1 >= 0 && m[i][j - 1] == 1 && visited[i, j - 1] != 1)
            {
                visited[i, j] = 1;
                Solve1(i, j - 1, m, visited, move + 'L', n, ans);
                visited[i, j] = 0;
            }

            // right
            if (j + 1 < n && m[i][j + 1] == 1 && visited[i, j + 1] != 1)
            {
                visited[i, j] = 1;
                Solve1(i, j + 1, m, visited, move + 'R', n, ans);
                visited[i, j] = 0;
            }

            // up
            if (i - 1 >= 0 && m[i - 1][j] == 1 && visited[i - 1, j] != 1)
            {
                visited[i, j] = 1;
                Solve1(i - 1, j, m, visited, move + 'U', n, ans);
                visited[i, j] = 0;
            }
        }
    }
}
