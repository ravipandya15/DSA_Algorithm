using System;
using System.Linq;

namespace _204._Count_Primes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("204. Count Primes");
            int n = 40;
            Console.WriteLine($"No of primes numbers which are less than {n} is {CountPrimes(n)}");
            Console.ReadLine();
        }


        public static int CountPrimes(int n)
        {
            int count = 0;
            // mark all number as prime
            //1->Prime , 0->Non Prime
            int[] primes = Enumerable.Repeat(1, n + 1).ToArray();

            //int[] primes = new int[n + 1];
            //for (int i = 1; i < n + 1; i++)
            //{
            //    primes[i] = 1;
            //}

            for (int i = 2; i < n; i++)
            {
                if (primes[i] == 1)
                {
                    count++;

                    // mark number as non prime -> as i is there in table of j.
                    for (int j = 2 * i; j < n; j = j + i)
                    {
                        primes[j] = 0;
                    }
                }
            }
            return count;
        }
    }
}
