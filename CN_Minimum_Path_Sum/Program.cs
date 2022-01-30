using System;

namespace CN_Minimum_Path_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Minimum_Path_Sum");
        }

        public static int solve(int i, int j, int[,] grid)
        {
            // base case
            if (i == 0 && j == 0) return grid[i,j];
            if (i < 0 || j < 0) return (int)1e9;

            int up = grid[i,j] + solve(i - 1, j, grid);
            int left = grid[i,j] + solve(i, j - 1, grid);

            return Math.Min(up, left);
        }

        // Recursion
        // TC -> O(2^(N*M))
        // SC -> O(N-1 + M-1)
        public static int MinSumPath1(int[,] grid)
        {
            int n = grid.GetLength(0);
            int m = grid.GetLength(1);
            return solve(n - 1, m - 1, grid);
        }

        public static int solve1(int i, int j, int[,] grid, int[,] dp)
        {
            // base case
            if (i == 0 && j == 0) return grid[i,j];
            if (i < 0 || j < 0) return (int)1e9;

            if (dp[i,j] != -1) return dp[i,j];

            int up = grid[i,j] + solve1(i - 1, j, grid, dp);
            int left = grid[i,j] + solve1(i, j - 1, grid, dp);

            return dp[i,j] = Math.Min(up, left);
        }

        // Memoization
        // TC -> O(N*M)
        // SC -> O(N*M) + O(N-1 + M-1)
        public static int MinSumPath2(int[,] grid)
        {
            int n = grid.GetLength(0);
            int m = grid.GetLength(1);
            int[,] dp = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    dp[i, j] = -1;
                }
            }

            return solve1(n - 1, m - 1, grid, dp);
        }

        // Tabulation
        // TC -> O(N*M)
        // SC -> O(N*M)
        public static int MinSumPath3(int[,] grid)
        {
            int n = grid.GetLength(0);
            int m = grid.GetLength(1);
            int[,] dp = new int[n,m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i == 0 && j == 0) dp[i,j] = grid[i,j];
                    else
                    {
                        int up = grid[i,j];
                        if (i > 0) up += dp[i - 1,j];
                        else up += (int)1e9;

                        int left = grid[i,j];
                        if (j > 0) left += dp[i,j - 1];
                        else left += (int)1e9;

                        dp[i,j] = Math.Min(up, left);
                    }


                }
            }
            return dp[n - 1,m - 1];
        }

        // Space optimization
        // TC -> O(N*M)
        // SC -> O(M)
        public static int MinSumPath4(int[,] grid)
        {
            int n = grid.GetLength(0);
            int m = grid.GetLength(1);
            int[] prev = new int[m];

            for (int i = 0; i < n; i++)
            {
                int[] temp = new int[m];
                for (int j = 0; j < m; j++)
                {
                    if (i == 0 && j == 0) temp[j] = grid[i,j];
                    else
                    {
                        int up = grid[i,j];
                        if (i > 0) up += prev[j];
                        else up += (int)1e9;

                        int left = grid[i,j];
                        if (j > 0) left += temp[j - 1];
                        else left += (int)1e9;

                        temp[j] = Math.Min(up, left);
                    }
                }
                prev = temp; // IMP
            }
            return prev[m - 1];
        }

    }
}
