using System;

namespace Print_Like_A_Wave
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Print Like A Wave");
            Console.ReadLine();
        }

        public static int[] wavePrint(int[][] arr, int nRows, int mCols)
        {
            int size = arr.Length * arr[0].Length;
            int[] result = new int[size];
            int i = 0;

            for (int col = 0; col < mCols; col++)
            {
                if ((int)(col & 1) == 1)
                {
                    // Odd index -> Bottom to Top
                    for (int row = nRows - 1; row >= 0; row--)
                    {
                        result[i++] = arr[row][col];
                    }
                }

                else
                {
                    // Even or 0 index -> Top to Bottom
                    for (int row = 0; row < nRows; row++)
                    {
                        result[i++] = arr[row][col];
                    }
                }
            }

            return result;
        }
    }
}
