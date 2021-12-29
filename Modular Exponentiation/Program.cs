using System;

namespace Modular_Exponentiation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Modular Exponentiation");
            int x = 3, n = 5, m = 7;
            Console.WriteLine($"Modular Exponentiation of {x}^{n} % {m} is {modularExponentiation(x, n, m)}");
            Console.ReadLine();
        }

        // O(log(N))
        public static int modularExponentiation(int x, int n, int m)
        {
            int result = 1;

            while (n > 0)
            {
                if ((n & 1) == 1)
                {// odd
                    result = (int)(Convert.ToInt64((result) % m * (x) % m) % m);
                }
                x = ((x) % m * (x) % m) % m;
                n = n >> 1; // divide by 2
            }
            return result;
        }
    }
}
