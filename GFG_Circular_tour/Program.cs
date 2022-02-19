using System;

namespace GFG_Circular_tour
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int tour(int[] p, int[] d, int n)
        {
            int start = 0;
            int deficit = 0;
            int balance = 0;

            for (int i = 0; i < n; i++)
            {
                balance = balance + p[i] - d[i];
                if (balance < 0)
                {
                    deficit = deficit + balance;
                    start = i + 1;
                    balance = 0;
                }
            }

            if (deficit + balance >= 0)
            {
                return start;
            }
            return -1;
        }
    }
}
