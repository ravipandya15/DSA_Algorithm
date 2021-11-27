using System;

namespace _231._Power_of_Two
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("231. Power of Two");
            Console.WriteLine($"answer is {IsPowerOfTwo(1024)}");
            Console.ReadLine();
        }

        public static bool IsPowerOfTwo(int n)
        {
            int ans = 1;
            for (int i = 0; i <= 30; i++) // loop runs for 31 times
            {
                if (ans == n)
                    return true;
                //ans = Math.Pow(2, i);
                if (ans < Int32.MaxValue/2)
                    ans = ans * 2;
            }
            return false;
        }
    }
}
