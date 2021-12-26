using System;

namespace _240._Search_a_2D_Matrix_II
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("240. Search a 2D Matrix II");
            Console.ReadLine();
        }

        // starting element is top right element
        public bool SearchMatrix(int[][] matrix, int target)
        {
            int row = matrix.Length;
            int col = matrix[0].Length;

            int rowIndex = 0;
            int colIndex = col - 1;

            while (rowIndex < row && colIndex >= 0)
            {
                if (matrix[rowIndex][colIndex] == target)
                    return true;

                if (matrix[rowIndex][colIndex] < target)
                    rowIndex++;

                else
                    colIndex--;
            }
            return false;
        }

        // starting element is bottom left element
        public bool SearchMatrix1(int[][] matrix, int target)
        {
            int row = matrix.Length;
            int col = matrix[0].Length;

            int rowIndex = row - 1;
            int colIndex = 0;

            while (rowIndex >= 0 && colIndex < col)
            {
                if (matrix[rowIndex][colIndex] == target)
                    return true;

                if (matrix[rowIndex][colIndex] < target)
                    colIndex++;

                else
                    rowIndex--;
            }
            return false;
        }
    }
}
