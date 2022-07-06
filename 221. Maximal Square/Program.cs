using System;
using System.Collections.Generic;

namespace _221._Maximal_Square
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("221. Maximal Square");
            char[][] heights = new char[][] { 
                new char[] { '1', '0', '1', '0', '0' }, 
                new char[] { '1', '0', '1', '1', '1' }, 
                new char[] { '1', '1', '1', '1', '1' },
                new char[] { '1', '0', '0', '1', '0' } };

            int ans = maximalSquare(heights);
            Console.WriteLine($"maximum ans is {ans}");
        }

        // TC -> O(N * M)
        // SC -> O(N * M)
        public static int maximalSquare(char[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;
            int[,] dp = new int[m,n];

            int size = 0;

            for (int i = 0; i < m; i++)
            {
                dp[i,0] = matrix[i][0] - '0';
                size = Math.Max(size, dp[i,0]);
            }
            for (int j = 0; j < n; j++)
            {
                dp[0,j] = matrix[0][j] - '0';
                size = Math.Max(size, dp[0,j]);
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (matrix[i][j] == '1')
                    {
                        dp[i,j] = Math.Min(dp[i - 1,j - 1], Math.Min(dp[i,j - 1], dp[i - 1,j])) + 1;
                    }
                    else dp[i,j] = 0;
                    size = Math.Max(size, dp[i,j]);
                }
            }

            return size * size;

        }

        // TC -> O(N * M)
        // SC -> O(M)
        public int maximalSquare_1(char[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;
            int[] prev = new int[n];

            int size = 0;

            for (int i = 1; i < m; i++)
            {
                int[] cur = new int[n];
                for (int j = 1; j < n; j++)
                {
                    if (i == 0 || j == 0 || matrix[i][j] == '0')
                    {
                        cur[j] = Math.Min(prev[j - 1], Math.Min(cur[j - 1], prev[j])) + 1;
                    }
                    else cur[j] = matrix[i][j] - '0';
                    size = Math.Max(size, cur[j]);
                }
                prev = cur;
            }

            return size * size;
        }
    }
}
