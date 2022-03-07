using System;

namespace Reduce_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static int countMinOp(int n, int m, int[,] mat)
        {
            int[] sum = new int[m];
            // Write your code here.
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    sum[i] += mat[j, i];
                }
            }

            //int[] count = new int[];

            //return count;

            return 0;

        }
    }
}
