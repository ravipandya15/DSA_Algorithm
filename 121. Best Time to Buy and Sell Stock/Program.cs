using System;

namespace _121._Best_Time_to_Buy_and_Sell_Stock
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("121. Best Time to Buy and Sell Stock");
            int[] prices = new int[] { 7, 1, 5, 3, 6, 4 };
            int result = MaxProfit(prices);
            Console.WriteLine($"maxProfit is {result}");
            Console.ReadLine();
        }

        public static int MaxProfit(int[] prices)
        {
            int maxProfit = 0, min = Int32.MaxValue;

            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < min)
                {
                    min = prices[i];
                }
                else if (prices[i] - min > maxProfit)
                {
                    maxProfit = prices[i] - min;
                }

                //if (prices[i] < min)
                //    min = prices[i];
                //else if (prices[i] > min)
                //    maxProfit = Math.Max(maxProfit, prices[i] - min);
            }

            return maxProfit;
        }
    }
}
