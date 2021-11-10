using System;

namespace _48._Rotate_Image
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("48. Rotate Image");
            int[][] matrix = new int[3][]
            {
                new int[] {1,2,3},
                new int[] {4,5,6},
                new int[] { 7, 8, 9 }
            };
            Rotate(matrix);
            Console.ReadLine();
        }

        // time complexity => O(N ^ 2)
        // space complexity => O(1)
        public static void Rotate(int[][] matrix)
        {
            // step 1 => Transpose Matrix
            for (int i =0; i < matrix.Length; i++)
            {
                for (int j = i; j < matrix.Length; j++) // j < matrix[0].Length -> will also work
                {
                    int temp = 0;
                    temp = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = temp;
                }
            }

            // step 2 -> rotate every row
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix.Length/2; j++)
                {
                    int temp = 0;
                    temp = matrix[i][j];
                    matrix[i][j] = matrix[i][matrix.Length - 1 - j];
                    matrix[i][matrix.Length - 1 - j] = temp;
                }
            }
        }
        //public static void Rotate(int[][] matrix)
        //{
        //    int size = matrix.Length - 1;
        //    int[][] duplicate = matrix.Clone() as int[][];
        //    for (int i = 0; i < matrix.Length; i++)
        //    {
        //        for (int j = 0; j < matrix.Length; j++)
        //        {
        //            duplicate[i][j] = matrix[size - j][i];
        //        }
        //    }
        //}
    }
}
