using System;
using System.Collections.Generic;

namespace CN_Stocks_are_profitable
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Stocks_are_profitable");
        }

        public static int maximumProfit(List<int> prices)
        {
            int mini = prices[0];
            int profit = 0;
            for (int i = 1; i < prices.Count; i++)
            {
                int currentProfit = prices[i] - mini;
                profit = Math.Max(profit, currentProfit);
                mini = Math.Min(mini, prices[i]);
            }

            return profit;
        }
    }
}
