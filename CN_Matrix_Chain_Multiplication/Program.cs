using System;

namespace CN_Matrix_Chain_Multiplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Matrix_Chain_Multiplication");
        }

        public static int solve(int i, int j, int[] arr)
        {
            // base case
            if (i == j)
            {
                return 0;
            }

            int mini = (int)1e9;
            for (int k = i; k < j; k++)
            {
                int steps = arr[i - 1] * arr[k] * arr[j] + solve(i, k, arr) + solve(k + 1, j, arr);
                if (steps < mini)
                {
                    mini = steps;
                }
            }

            return mini;
        }

        // Recursion
        // TC -> Exponential
        // SC -> ? ->  may be O(N)
        public static int matrixMultiplication1(int[] arr, int N)
        {
            return solve(1, N - 1, arr);
        }

        public static int solve1(int i, int j, int[] arr, int[,] dp)
        {
            // base case
            if (i == j)
            {
                return 0;
            }

            if (dp[i,j] != -1) return dp[i,j];

            int mini = (int)1e9;
            for (int k = i; k < j; k++)
            {
                int steps = arr[i - 1] * arr[k] * arr[j] + solve1(i, k, arr, dp) + solve1(k + 1, j, arr, dp);
                if (steps < mini)
                {
                    mini = steps;
                }
            }

            return dp[i,j] = mini;
        }

        // Memoization
        // TC -> O(N^3)
        // S -> O(N^2) + O(N)
        public static int matrixMultiplication2(int[] arr, int N)
        {
            int[,] dp = new int[N,N];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    dp[i, j] = -1;
                }
            }
            return solve1(1, N - 1, arr, dp);
        }

        // Tabulation
        // TC -> O(N^3)
        // S -> O(N^2)
        public static int matrixMultiplication3(int[] arr, int N)
        {
            int[,] dp = new int[N,N];

            // base case
            for (int i = 1; i < N; i++)
            {
                dp[i,i] = 0;
            }

            for (int i = N - 1; i >= 1; i--)
            {
                for (int j = i + 1; j < N; j++)
                {
                    int mini = (int)1e9;
                    for (int k = i; k < j; k++)
                    {
                        int steps = arr[i - 1] * arr[k] * arr[j] + dp[i,k] + dp[k + 1,j];
                        if (steps < mini)
                        {
                            mini = steps;
                        }
                    }

                    dp[i,j] = mini;
                }
            }

            return dp[1,N - 1];
        }
    }
}
