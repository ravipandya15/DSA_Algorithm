using System;
using System.Collections.Generic;

namespace CN_Maze_obstacles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Maze obstacles");
        }

        // IMP
        // Since the answer can be large, print it modulo 10^9 + 7.

        public static int solve(int i, int j, int mod, List<List<int>> mat)
        {
            // base case
            if (i >= 0 && j >= 0 && mat[i][j] == -1) return 0;
            if (i == 0 && j == 0) return 1;
            if (i < 0 || j < 0) return 0;

            int up = solve(i - 1, j, mod, mat);
            int left = solve(i, j - 1, mod, mat);
            return (up + left) % mod;
        }

        //Recursion
        // TC -> O(2^(m*n))
        // SC -> O(m-1 + n-1)
        static int mazeObstacles1(int n, int m, List<List<int>> mat)
        {
            int mod = (int)(1e9 + 7);
            return solve(n - 1, m - 1, mod, mat);
        }

        public static int solve1(int i, int j, int mod, List<List<int>> mat, int[,] dp)
        {
            // base case
            if (i >= 0 && j >= 0 && mat[i][j] == -1) return 0;
            if (i == 0 && j == 0) return 1;
            if (i < 0 || j < 0) return 0;

            if (dp[i, j] != -1) return dp[i, j];

            int up = solve1(i - 1, j, mod, mat, dp);
            int left = solve1(i, j - 1, mod, mat, dp);
            return dp[i, j] = (up + left) % mod;
        }

        // memoization
        // TC -> O(M * N)
        // SC -> O(M-1 + N-1) + O(M * N)
        static int mazeObstacles2(int n, int m, List<List<int>> mat)
        {
            int mod = (int)(1e9 + 7);
            int[,] dp = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    dp[i, j] = -1;
                }
            }
            return solve1(n - 1, m - 1, mod, mat, dp);
        }

        // Tabulation
        // TC -> O(M * N)
        // SC -> O(M * N)
        static int mazeObstacles3(int n, int m, List<List<int>> mat)
        {
            int mod = (int)(1e9 + 7);
            int[,] dp = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (mat[i][j] == -1)
                    {
                        dp[i, j] = 0;
                        continue;
                    }
                    if (i == 0 && j == 0)
                    {
                        dp[i, j] = 1;
                        continue;
                    }

                    int up = 0;
                    int left = 0;
                    if (i > 0)
                    {
                        up = dp[i - 1, j];
                    }
                    if (j > 0)
                    {
                        left = dp[i, j - 1];
                    }

                    dp[i, j] = (up + left) % mod;
                }
            }

            return dp[n - 1, m - 1];
        }

        // Space optimization
        // TC -> O(M * N)
        // SC -> O(N) -> no. of columns
        static int mazeObstacles4(int n, int m, List<List<int>> mat)
        {
            int mod = (int)(1e9 + 7);
            int[] prev = new int[m];

            for (int i = 0; i < n; i++)
            {
                int[] cur = new int[m];
                for (int j = 0; j < m; j++)
                {
                    if (mat[i][j] == -1)
                    {
                        cur[j] = 0;
                        continue;
                    }
                    if (i == 0 && j == 0)
                    {
                        cur[j] = 1;
                        continue;
                    }

                    int up = 0;
                    int left = 0;
                    if (i > 0)
                    {
                        up = prev[j];
                    }
                    if (j > 0)
                    {
                        left = cur[j - 1];
                    }

                    cur[j] = (up + left) % mod;
                }

                prev = cur;
            }

            return prev[m - 1];
        }
    }
}
