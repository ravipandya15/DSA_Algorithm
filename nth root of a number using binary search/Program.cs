using System;

namespace nth_root_of_a_number_using_binary_search
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nth root of a number using binary search");
            Console.WriteLine("Find Nth root of M upto d precision");
            int m = 27;
            int n = 3;
            FindNthRoot(m, n);
        }

        public static void FindNthRoot(int m, int n)
        {
            double start = 1;
            double end = m;
            double eps = 1e-6; // 10 ^ -6 -> 1/ (10^6)
            double mid = 1.0;
            while ((end - start) > eps)
            {
                mid = start + (end - start) / 2.0;
                if (Multiply(mid, n) < m)
                    start = mid;
                else
                    end = mid;
            }
            Console.WriteLine($"ans is {mid}");
            Console.WriteLine($"{start} {end}");
            Console.WriteLine($"{Math.Pow(m, (double)(1.0/(double)n))}");
            Console.WriteLine($"{Math.Pow(3, n)}");
        }

        public static double Multiply(double mid, int n)
        {
            double ans = 1.0;
            for (int i = 0; i < n; i++)
            {
                ans = ans * n;
            }
            return ans;
        }
    }
}
