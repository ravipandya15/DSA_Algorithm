using System;

namespace _1009._Complement_of_Base_10_Integer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1009. Complement of Base 10 Integer");
            Console.WriteLine($"answer is {bitwiseComplement(5)}");
            Console.ReadLine();
        }

        public static int bitwiseComplement(int n)
        {

            int m = n;
            int mask = 0;

            // edge case
            if (n == 0)
                return 1;

            while (m != 0)
            {
                mask = (mask << 1) | 1;
                m = m >> 1;
            }

            return (~n) & mask;
        }
    }
}
