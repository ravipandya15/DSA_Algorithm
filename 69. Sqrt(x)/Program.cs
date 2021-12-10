using System;

namespace _69._Sqrt_x_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("69. Sqrt(x)");
            int n = 39;
            Console.WriteLine($"Square root if {n} is {MySqrt(n)}");
            Console.ReadLine();
        }


        public static int BinarySearch(int n)
        {
            int s = 0, e = n;
            int mid = s + (e - s) / 2;

            int ans = -1;
            while (s <= e)
            {
                long square = mid * mid;
                if (square == n)
                {
                    return mid;
                }
                else if (square < n)
                {
                    ans = mid;
                    s = mid + 1;
                }
                else
                {
                    e = mid - 1;
                }
                // update mid
                mid = s + (e - s) / 2;
            }
            return ans;
        }
        
        
        public static double FindMorePrecision(int n, int precision, int tempSol)
        {
            double factor = 1;
            double ans = tempSol;

            for (int i = 0; i < precision; i++)
            {
                factor = factor / 10;
                for (double j = ans; j*j < n; j = j + factor)
                {
                    ans = j;
                }
            }
            return ans;

        }
        // tc ->  O(log(n))
        // using Binary Search
        public static int MySqrt(int x)
        {
            int main = BinarySearch(x);
            double finalSolution = FindMorePrecision(x, 3, main);
            Console.WriteLine($"Final Answer is {finalSolution}");

            return BinarySearch(x);
        }
    }
}
