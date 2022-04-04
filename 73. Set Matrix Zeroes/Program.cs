using System;

namespace _73._Set_Matrix_Zeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("73. Set Matrix Zeroes");
            int[][] matrix =
            {
                new int[] {0,1,2,0},
                new int[] {3,4,5,2},
                new int[] { 1, 3, 1, 5 }
            };
            SetZeroes(matrix);
            Console.WriteLine($"result is ");
            //SetZeroes(matrix);
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    Console.Write($"{matrix[i][j]} ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
        // not correct as you need to set row and col array to some value other than 0 and
        // then mark appropriate value to 0.
        // Solution - Not best
        // time complexity = O(M*N)
        // space complexity = O(M + N)
        public static void SetZeroes(int[][] matrix)
        {
            int[] row = new int[matrix.Length];
            int[] col = new int[matrix[0].Length];
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        row[i] = -1;
                        col[j] = -1;
                    }
                }
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    if (row[i] == -1 || col[j] == -1)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }
        }

        // best solution
        // time complexity = O(M * N)
        // space complexity = O(1)
        public static void SetZeroes1(int[][] matrix)
        {
            int col = 1;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i][0] == 0) col = 0;

                for (int j = 1; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        matrix[i][0] = matrix[0][j] = 0;
                    }
                }
            }

            for (int i = matrix.Length - 1; i >= 0; i--)
            {
                for (int j = matrix[0].Length - 1; j >= 1; j--)
                {
                    if (matrix[i][0] == 0 || matrix[0][j] == 0)
                    {
                        matrix[i][j] = 0;
                    }
                }
                if (col == 0) matrix[i][0] = 0;
            }
        }
    }
}
