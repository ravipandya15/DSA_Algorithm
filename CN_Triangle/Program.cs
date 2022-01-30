using System;

namespace CN_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Triangle");
        }

        public static int solve(int i, int j, int[,] triangle, int n)
        {
            // base case
            if (i == n - 1)
                return triangle[n - 1,j];

            int d = triangle[i,j] + solve(i + 1, j, triangle, n);
            int dg = triangle[i,j] + solve(i + 1, j + 1, triangle, n);

            return Math.Min(d, dg);
        }

        // Recursion
        // TC -> O(2^(n*(n+1)/2))
        // SC -> O(N)
        public static int minimumPathSum1(int[,] triangle, int n)
        {
            return solve(0, 0, triangle, n);
        }

        public static int solve1(int i, int j, int[,] triangle, int n, int[,] dp)
        {
            // base case
            if (i == n - 1)
                return triangle[n - 1,j];

            if (dp[i,j] != -1) return dp[i,j];

            int d = triangle[i,j] + solve1(i + 1, j, triangle, n, dp);
            int dg = triangle[i,j] + solve1(i + 1, j + 1, triangle, n, dp);

            return dp[i,j] = Math.Min(d, dg);
        }

        // Memoization
        // TC -> O(N*N)
        // SC -> O(N) + O(N*N)
        public static int minimumPathSum2(int[,] triangle, int n)
        {
            int[,] dp = new int[n,n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dp[i, j] = -1;
                }
            }

            return solve1(0, 0, triangle, n, dp);

        }

        // Tabulation
        // TC -> O(N*N)
        // SC -> O(N*N)
        public static int minimumPathSum3(int[,] triangle, int n)
        {
            int[,] dp = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dp[i, j] = 0;
                }
            }
            // In Tabulation do reverse of Recursion
            // Recursion O -> n-1
            // Tabulation n-1 to 0
            // base case
            for (int j = 0; j < n; j++)
                dp[n - 1,j] = triangle[n - 1,j];


            for (int i = n - 2; i >= 0; i--)
            {
                for (int j = i; j >= 0; j--)
                {
                    int d = triangle[i,j] + dp[i + 1,j];
                    int dg = triangle[i,j] + dp[i + 1,j + 1];

                    dp[i,j] = Math.Min(d, dg);
                }
            }

            return dp[0,0];
        }

        // Space Optimization
        // TC -> O(N*N)
        // SC -> O(N)
        public static int minimumPathSum4(int[,] triangle, int n)
        {
            int[] front = new int[n];

            // base case
            for (int j = 0; j < n; j++)
                front[j] = triangle[n - 1,j];


            for (int i = n - 2; i >= 0; i--)
            {
                int[] cur = new int[n];
                for (int j = i; j >= 0; j--)
                {
                    int d = triangle[i,j] + front[j];
                    int dg = triangle[i,j] + front[j + 1];

                    cur[j] = Math.Min(d, dg);
                }
                front = cur;
            }

            return front[0];
        }
    }
}
