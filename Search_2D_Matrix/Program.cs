using System;

namespace Search_2D_Matrix
{
    class Program
    {
        // time complexity -> O(log 2(M*N))
        // space complexity -> O(1)
        public static bool SearchMatrix(int[,] matrix, int target)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int low = 0, high = n * m - 1;
            //int mid = (low + high) / 2; or (low + high) >> 1;
            int mid = low + (high - low) / 2; // it's better than above as to reduce overflow.

            while (low <= high)
            {
                int element = matrix[mid / m, mid % m];
                if (element == target)
                {
                    //Console.WriteLine($"x is {i}. y is {j}");
                    return true;
                }
                if (element < target)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
                mid = low + (high - low) / 2;
            }
            return false;
        }

        //public static bool SearchMatrix(int[,] matrix, int target)
        //{
        //    int n = matrix.GetLength(0);
        //    //matrix.Length;
        //    int m = matrix.GetLength(1);
        //    int low = 0, high = n * m - 1;
        //    int i = 0, j = 0;
        //    if (high == 0)
        //    {
        //        return matrix[low, high] == target ? true : false;
        //    }
        //    while (low < high)
        //    {
        //        //int mid = (low + high) / 2;
        //        //i = mid == n ? mid % n : mid / n;
        //        i = n / 2;
        //        j = m / 2;
        //        if (matrix[i, j] == target)
        //        {
        //            Console.WriteLine($"x is {i}. y is {j}");
        //            return true;
        //        }
        //        if (target > matrix[i, j])
        //        {
        //            low = (i * n + j) + 1;
        //        }
        //        else
        //        {
        //            high = i * n + j - 1;
        //        }
        //    }
        //    return false;
        //}

        // search a 2D matrix 2
        //Integers in each row are sorted in ascending from left to right.
        //Integers in each column are sorted in ascending from top to bottom.

        public static bool SearchMatrix2(int[,] matrix, int target)
        {
            int row = matrix.GetLength(0) - 1;
            int col = 0;

            while (row >= 0 && col < matrix.GetLength(1))
            {
                if (matrix[row, col] == target)
                {
                    Console.WriteLine($"x is {row}, y is {col}");
                    return true;
                }
                if (target > matrix[row, col])
                {
                    col++;
                }
                else
                {
                    row--;
                }
            }
            return false;
        }

        //public static bool SearchMatrix2(int[,] matrix, int target)
        //{
        //    int row = 0;
        //    int col = matrix.GetLength(1) - 1;

        //    while (row < matrix.GetLength(0) && col >= 0)
        //    {
        //        if (matrix[row, col] == target)
        //        {
        //            Console.WriteLine($"x is {row}, y is {col}");
        //            return true;
        //        }
        //        if (target > matrix[row, col])
        //        {
        //            row++;
        //        }
        //        else
        //        {
        //            col--;
        //        }
        //    }
        //    return false;
        //}

        static void Main(string[] args)
        {
            Console.WriteLine("Search value from 2D matrix (n * m)");
            int[,] matrix = new int[,] { { 1, 3, 5, 7 }, { 10, 11, 16, 20 }, { 23, 30, 34, 60 } };
            //Console.WriteLine("Enter n (row)");
            //int n = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Enter m (column)");
            //int m = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine($"Enter {n * m} values");
            //int[,] matrix = new int[n, m];
            //for (int i = 0; i < n; i++)
            //{
            //    for (int j = 0; j < m; j++)
            //    {
            //        matrix[i, j] = Convert.ToInt32(Console.ReadLine());
            //    }
            //}
            //Console.WriteLine("Entered 2D array is...");
            //for (int i = 0; i < n; i++)
            //{
            //    for (int j = 0; j < m; j++)
            //    {
            //        Console.WriteLine($"{matrix[i, j]} ");
            //    }
            //    Console.WriteLine();
            //}
            int[,] matrix2 = new int[,] { { 1, 4, 7, 11, 15 }, { 2, 5, 8, 12, 19 }, { 3, 6, 9, 16, 22 }
                                        , { 10,13,14,17,24 }, { 18,21,23,26,30} };


            while (true)
            {
                Console.WriteLine("Enter value which want to find");
                int target = Convert.ToInt32(Console.ReadLine());
                //bool result = SearchMatrix(matrix, target);
                bool result = SearchMatrix2(matrix2, target);
                Console.WriteLine($"Result is {result}");
            }
        }
    }
}
