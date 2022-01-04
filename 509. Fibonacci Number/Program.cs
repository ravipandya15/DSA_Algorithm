using System;

namespace _509._Fibonacci_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("509. Fibonacci Number");
        }

        public static int Fib(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            return Fib(n - 1) + Fib(n - 2);
        }
    }
}
