using System;

namespace _338._Counting_Bits
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter n");
            int n = Convert.ToInt32(Console.ReadLine());
            CountBits(n);
            Console.ReadLine();
        }

        public static int[] CountBits(int n)
        {
            int[] ans = new int[n + 1];
            //ans[0] = 0;
            for (int i = 0; i < n + 1; i++)
            {
                ans[i] = ans[i / 2] + i % 2;

                // as i / 2 = i >> 1 and i % 2 = i & 1
                //ans[i] = ans[i >> 1] + i & 1;
                Console.WriteLine($"{i} --> {ans[i]}");
            }
            return ans;
        }
    }
}
