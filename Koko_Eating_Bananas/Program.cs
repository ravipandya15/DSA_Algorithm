using System;
using System.Linq;

namespace Koko_Eating_Bananas
{
    class Program
    {
        public static bool possible(int[] bananas, int value, int h)
        {
            bool ans = false;
            int possibleans = 0;
            for (int i = 0; i < bananas.Length; i++)
            {
                if (bananas[i] <= value)
                {
                    possibleans = possibleans + 1;
                }
                else
                {
                    possibleans += Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(bananas[i]) / value));
                }
            }
            return possibleans <= h;
        }

        public static int MinimumBananas(int[] bananas, int h)
        {
            if (bananas == null && bananas.Length == 0)
            {
                return 0;
            }
            int low = 1;
            int high = bananas.ToList().Max();
            //int low = int.MinValue;
            //int high = int.MaxValue;
            int mi = -1; // medium of low and high
            while (low < high)
            {
                mi = Convert.ToInt32(Math.Floor((Convert.ToDecimal(low) + Convert.ToDecimal(high)) / 2));
                if (possible(bananas, mi, h))
                {
                    high = mi;
                }
                else
                {
                    low = mi + 1;
                }
            }
            return Convert.ToInt32(low);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Koko earting bananas");
            Console.WriteLine("How many minimum number(k) requires to eat k bananas per hour so that koko can eat all bananas before guard comes in h hours");
            while(true)
            {
                Console.WriteLine("Enter length of banana arrays");
                int n = Convert.ToInt32(Console.ReadLine());
                int[] bananas = new int[n];
                Console.WriteLine($"Enter {n} times...");
                for (int i = 0; i < n; i++)
                {
                    bananas[i] = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine($"banana array is...");
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine(bananas[i] + " ");
                }
                Console.WriteLine("Enter no of hours by when guard returns....");
                int h = Convert.ToInt32(Console.ReadLine());
                int ans = MinimumBananas(bananas, h);
                Console.WriteLine($"ans is {ans}");
            }
            Console.ReadLine();
        }
    }
}
