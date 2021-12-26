using System;
using System.Collections.Generic;

namespace _54._Spiral_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("54. Spiral Matrix");
            int[][] matrix = new int[][]
            {
                new int[] {1,2,3,4},
                new int[] {5,6,7,8},
                new int[] {9,10,11,12},
            };
            var result = SpiralOrder(matrix);
            Console.ReadLine();
        }

        public static IList<int> SpiralOrder(int[][] matrix)
        {
            List<int> ans = new List<int>();
            int row = matrix.Length;
            int col = matrix[0].Length;
            int count = 0;
            int total = row * col;

            // initialize Index;
            int startingRow = 0, starttingCol = 0, endingRow = row - 1, enddingCol = col - 1;

            while (count < total)
            {
                // print starting row
                for (int index = starttingCol; count < total && index <= enddingCol; index++)
                {
                    ans.Add(matrix[startingRow][index]);
                    count++;
                }
                startingRow++;

                // print ending Col
                for (int index = startingRow; count < total && index <= endingRow; index++)
                {
                    ans.Add(matrix[index][enddingCol]);
                    count++;
                }
                enddingCol--;

                // print ending Row
                for (int index = enddingCol; count < total && index >= starttingCol; index--)
                {
                    ans.Add(matrix[endingRow][index]);
                    count++;
                }
                endingRow--;

                // print starting Col
                for (int index = endingRow; count < total && index >= startingRow; index--)
                {
                    ans.Add(matrix[index][starttingCol]);
                    count++;
                }
                starttingCol++;
            }
            return ans;
        }
    }
}
