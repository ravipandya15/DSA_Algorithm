using System;

namespace _1281._Subtract_the_Product_and_Sum_of_Digits_of_an_Integer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1281. Subtract the Product and Sum of Digits of an Integer");
            Console.ReadLine();
        }

        public int subtractProductAndSum(int n)
        {
            int prod = 1;
            int sum = 0;

            while (n != 0)
            {
                int digit = n % 10;
                prod *= digit;
                sum += digit;

                n /= 10;
            }

            return prod - sum;
        }
    }
}
