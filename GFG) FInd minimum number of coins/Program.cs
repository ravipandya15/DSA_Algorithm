using System;
using System.Collections.Generic;

namespace GFG__FInd_minimum_number_of_coins
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GFG) Find_minimum_number_of_coins");
            int[] coins = new int[] { 1, 2, 5, 10, 20, 50, 100, 500, 1000 };
            int value = 47;
            Console.WriteLine($"minimum coins required are {FindMinimumCoins(coins, value)}");
            Console.ReadLine();
        }

        // TC -> O(V) -> V is value like 47
        // it works as 2 + 5 < 10, 10 + 20 < 50
        // will not work for {9,6,5,1} and V = 11
        public static int FindMinimumCoins(int[] coins, int value)
        {
            List<int> values = new List<int>();
            int result = 0;
            for (int i = coins.Length - 1; i >= 0; i--)
            {
                while (coins[i] <= value)
                {
                    value -= coins[i];
                    values.Add(coins[i]);
                    result++;
                }
            }
            return result;
        }
    }
}
