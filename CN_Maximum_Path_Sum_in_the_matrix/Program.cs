using System;

namespace CN_Maximum_Path_Sum_in_the_matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Maximum_Path_Sum_in_the_matrix");
        }

        public static int solve(int i, int j, int[,] matrix)
        {
            // base cases
            if (j < 0 || j >= matrix.GetLength(1)) return (int)-1e8;
            if (i == 0) return matrix[0,j];

            int u = matrix[i,j] + solve(i - 1, j, matrix);
            int ld = matrix[i,j] + solve(i - 1, j - 1, matrix);
            int rd = matrix[i,j] + solve(i - 1, j + 1, matrix);

            return Math.Max(u, Math.Max(ld, rd));
        }

        // Recursion
        // TC -> O(3^(N))
        // SC -> O(N)
        public static int getMaxPathSum1(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int maxi = (int)-1e8;
            for (int j = 0; j < m; j++)
            {
                maxi = Math.Max(maxi, solve(n - 1, j, matrix));
            }

            return maxi;
        }

        public static int solve1(int i, int j, int[,] matrix, int[,] dp)
        {
            // base cases
            if (j < 0 || j >= matrix.GetLength(1)) return (int)-1e8;
            if (i == 0) return matrix[0,j];

            if (dp[i,j] != -1) return dp[i,j];

            int u = matrix[i,j] + solve1(i - 1, j, matrix, dp);
            int ld = matrix[i,j] + solve1(i - 1, j - 1, matrix, dp);
            int rd = matrix[i,j] + solve1(i - 1, j + 1, matrix, dp);

            return dp[i,j] = Math.Max(u, Math.Max(ld, rd));
        }

        // Memoization
        // TC -> O(N * M)
        // SC -> O(N) + O(N * M)
        public static int getMaxPathSum2(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[,] dp = new int[n,m];

            for (int i =0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    dp[i, j] = -1;
                }
            }

            int maxi = (int)-1e8;
            for (int j = 0; j < m; j++)
            {
                maxi = Math.Max(maxi, solve1(n - 1, j, matrix, dp));
            }

            return maxi;
        }

        // Tabulation
        // TC -> O(N * M)
        // SC -> O(N) + O(N * M)
        public static int getMaxPathSum3(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[,] dp = new int[n,m];

            // base case
            for (int i = 0; i < m; i++)
            {
                dp[0,i] = matrix[0,i];
            }

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int u = matrix[i,j] + dp[i - 1,j];
                    int ld = matrix[i,j];
                    if (j - 1 >= 0) ld += dp[i - 1,j - 1];
                    else ld += (int)-1e8;
                    int rd = matrix[i,j];
                    if (j + 1 < m) rd += dp[i - 1,j + 1];
                    else rd += (int)-1e8;

                    dp[i,j] = Math.Max(u, Math.Max(ld, rd));
                }
            }

            int maxi = (int)-1e8;
            for (int j = 0; j < m; j++)
            {
                maxi = Math.Max(maxi, dp[n - 1,j]);
            }

            return maxi;
        }

        // Space Optimization
        // TC -> O(N * M)
        // SC -> O(N) + O(N * M)
        public static int getMaxPathSum4(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[] prev = new int[m];

            // base case
            for (int i = 0; i < m; i++)
            {
                prev[i] = matrix[0,i];
            }

            for (int i = 1; i < n; i++)
            {
                int[] cur = new int[m];
                for (int j = 0; j < m; j++)
                {
                    int u = matrix[i,j] + prev[j];
                    int ld = matrix[i,j];
                    if (j - 1 >= 0) ld += prev[j - 1];
                    else ld += (int)-1e8;
                    int rd = matrix[i,j];
                    if (j + 1 < m) rd += prev[j + 1];
                    else rd += (int)-1e8;

                    cur[j] = Math.Max(u, Math.Max(ld, rd));
                }
                // IMP
                prev = cur;
            }

            int maxi = (int)-1e8;
            for (int j = 0; j < m; j++)
            {
                maxi = Math.Max(maxi, prev[j]);
            }

            return maxi;
        }
    }
}
