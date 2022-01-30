using System;

namespace CN_Ninja_And_His_Friends
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Ninja_And_His_Friends");
        }

        public static int solve(int i, int j1, int j2, int n, int m, int[,] grid)
        {
            // base cases
            // 1. out of bound case
            if (j1 < 0 || j1 >= m || j2 < 0 || j2 >= m)
                return (int)-1e8;
            // 2. distination
            if (i == n - 1)
            {
                if (j1 == j2) return grid[i,j1];
                else return grid[i,j1] + grid[i,j2];
            }

            // expolore all paths Alica and Bob can go together
            int maxi = (int)-1e8;
            for (int dj1 = -1; dj1 <= +1; dj1++)
            {
                for (int dj2 = -1; dj2 <= +1; dj2++)
                {
                    int value = 0;
                    if (j1 == j2) value = grid[i,j1];
                    else value = grid[i,j1] + grid[i,j2];
                    value += solve(i + 1, j1 + dj1, j2 + dj2, n, m, grid);
                    maxi = Math.Max(maxi, value);
                }
            }

            return maxi;
        }

        // Recursion
        // TC => O(3^n + 3^n)
        // SC -> O(N)
        public static int maximumChocolates1(int n, int m, int[,] grid)
        {
            return solve(0, 0, m - 1, n, m, grid);
        }

        public static int solve1(int i, int j1, int j2, int n, int m, int[,] grid, int[,,] dp)
        {
            // base cases
            // 1. out of bound case
            if (j1 < 0 || j1 >= m || j2 < 0 || j2 >= m)
                return (int)-1e8;
            // 2. distination
            if (i == n - 1)
            {
                if (j1 == j2) return grid[i,j1];
                else return grid[i,j1] + grid[i,j2];
            }

            if (dp[i,j1,j2] != -1) return dp[i,j1,j2];

            // expolore all paths Alica and Bob can go together
            int maxi = (int)-1e8;
            for (int dj1 = -1; dj1 <= +1; dj1++)
            {
                for (int dj2 = -1; dj2 <= +1; dj2++)
                {
                    int value = 0;
                    if (j1 == j2) value = grid[i,j1];
                    else value = grid[i,j1] + grid[i,j2];
                    value += solve1(i + 1, j1 + dj1, j2 + dj2, n, m, grid, dp);
                    maxi = Math.Max(maxi, value);
                }
            }

            return dp[i,j1,j2] = maxi;
        }

        // memoization
        // TC => O(N * M * M)  *  9
        // SC -> O(N * M * M) + O(N)
        public static int maximumChocolates2(int n, int m, int[,] grid)
        {
            int[,,] dp = new int[n,m,m];
            for (int i = 0; i < n; i++)
            {
                for (int j1 = 0; j1 < m; j1++)
                {
                    for (int j2 = 0; j2 < m; j2++)
                    {
                        dp[i,j1,j2] = -1;
                    }
                }
            }

            return solve1(0, 0, m - 1, n, m, grid, dp);
        }

        // Tabulation
        // TC => O(N * M * M)  *  9
        // SC -> O(N * M * M)
        public static int maximumChocolates3(int n, int m, int[,] grid)
        {
            int[,,] dp = new int[n,m,m];

            // base case
            for (int j1 = 0; j1 < m; j1++)
            {
                for (int j2 = 0; j2 < m; j2++)
                {
                    if (j1 == j2) dp[n - 1,j1,j2] = grid[n - 1,j1];
                    else dp[n - 1,j1,j2] = grid[n - 1,j1] + grid[n - 1,j2];
                }
            }

            // express every state im terms of foor loop
            for (int i = n - 2; i >= 0; i--)
            {
                for (int j1 = 0; j1 < m; j1++)
                {
                    for (int j2 = 0; j2 < m; j2++)
                    {
                        int maxi = (int)-1e8;
                        for (int dj1 = -1; dj1 <= +1; dj1++)
                        {
                            for (int dj2 = -1; dj2 <= +1; dj2++)
                            {
                                int value = 0;
                                if (j1 == j2) value = grid[i,j1];
                                else value = grid[i,j1] + grid[i,j2];
                                if (j1 + dj1 >= 0 && j1 + dj1 < m && j2 + dj2 >= 0 && j2 + dj2 < m)
                                    value += dp[i + 1,j1 + dj1,j2 + dj2];
                                else
                                    value += (int)-1e8;
                                maxi = Math.Max(maxi, value);
                            }
                        }
                        dp[i,j1,j2] = maxi;
                    }
                }
            }

            return dp[0,0,m - 1];
        }

        // space optimization
        // TC => O(N * M * M)  *  9
        // SC -> O(M * M)
        public static int maximumChocolates4(int n, int m, int[,] grid)
        {
            int[,] front = new int[m,m];

            // base case
            for (int j1 = 0; j1 < m; j1++)
            {
                for (int j2 = 0; j2 < m; j2++)
                {
                    if (j1 == j2) front[j1,j2] = grid[n - 1,j1];
                    else front[j1,j2] = grid[n - 1,j1] + grid[n - 1,j2];
                }
            }

            // express every state im terms of foor loop
            for (int i = n - 2; i >= 0; i--)
            {
                int[,] cur = new int[m,m];
                for (int j1 = 0; j1 < m; j1++)
                {
                    for (int j2 = 0; j2 < m; j2++)
                    {
                        int maxi = (int)-1e8;
                        for (int dj1 = -1; dj1 <= +1; dj1++)
                        {
                            for (int dj2 = -1; dj2 <= +1; dj2++)
                            {
                                int value = 0;
                                if (j1 == j2) value = grid[i,j1];
                                else value = grid[i,j1] + grid[i,j2];
                                if (j1 + dj1 >= 0 && j1 + dj1 < m && j2 + dj2 >= 0 && j2 + dj2 < m)
                                    value += front[j1 + dj1,j2 + dj2];
                                else
                                    value += (int)-1e8;
                                maxi = Math.Max(maxi, value);
                            }
                        }
                        cur[j1,j2] = maxi;
                    }
                }
                front = cur;
            }

            return front[0,m - 1];
        }
    }
}
