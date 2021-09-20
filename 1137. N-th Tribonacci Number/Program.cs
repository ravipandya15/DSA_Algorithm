using System;

namespace _1137._N_th_Tribonacci_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1137._N_th_Tribonacci_Number");
            while(true)
            {
                Console.WriteLine("Enter num : ");
                int num = Convert.ToInt32(Console.ReadLine());
                int result = Tribonacci(num);
                Console.WriteLine($"Result is {result}");
            }
        }

        public static int Tribonacci(int n)
        {
            if (n < 2)
                return n;
            else
            {
                int a = 0, b = 1, c = 1, d;
                while (n-- > 2)
                {
                    d = a + b + c;
                    a = b;
                    b = c;
                    c = d;
                }
                return c;
            }
        }
    }
}
