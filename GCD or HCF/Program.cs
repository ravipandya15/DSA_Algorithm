using System;

namespace GCD_or_HCF
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GCD_or_HCF -> using Euclid'd Algorithm");
            int a = 24, b = 72;
            Console.WriteLine($"GCD of {a} and {b} is {GCD(a,b)}");
            Console.ReadLine();
        }

        public static int GCD(int a, int b)
        {
            if (a == 0) return b;
            if (b == 0) return a;

            while (a != b)
            {
                if (a > b) a = a - b;
                else b = b - a;
            }
            return a;
        }
    }
}
