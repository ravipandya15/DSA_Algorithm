using System;

namespace Best_Time_to_Buy_and_Sell_Stock_II_122
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Best_Time_to_Buy_and_Sell_Stock_II_122");
        }

        public int solve(int index, int buy, int[] prices, int n)
        {
            // base case
            if (index == n) return 0;

            int profit = 0;
            if (buy == 1)
            {
                profit = Math.Max(-prices[index] + solve(index + 1, 0, prices, n),
                                   0 + solve(index + 1, 1, prices, n));
            }
            else
            {
                profit = Math.Max(prices[index] + solve(index + 1, 1, prices, n),
                                   0 + solve(index + 1, 0, prices, n));
            }

            return profit;
        }

        // Recusrion
        // TC -> O(2^N)
        // SC -> O(N)
        public int maxProfit_1(int[] prices)
        {
            int n = prices.Length;
            return solve(0, 1, prices, n);
        }

        public int solve_1(int index, int buy, int[] prices, int n, int[,] dp)
        {
            // base case
            if (index == n) return 0;

            if (dp[index, buy] != -1) return dp[index, buy];

            int profit = 0;
            if (buy == 1)
            {
                profit = Math.Max(-prices[index] + solve_1(index + 1, 0, prices, n, dp),
                                   0 + solve_1(index + 1, 1, prices, n, dp));
            }
            else
            {
                profit = Math.Max(prices[index] + solve_1(index + 1, 1, prices, n, dp),
                                   0 + solve_1(index + 1, 0, prices, n, dp));
            }

            return dp[index, buy] = profit;
        }

        // Memoization
        // TC -> O(N * 2)
        // SC -> O(N * 2) + O(N)
        public int maxProfit_2(int[] prices)
        {
            int n = prices.Length;
            int[,] dp = new int[n, 2];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    dp[i, j] = -1;
                }
            }

            return solve_1(0, 1, prices, n, dp);
        }

        // Tabulation
        // TC -> O(N * 2)
        // SC -> O(N * 2)
        public int maxProfit_3(int[] prices)
        {
            int n = prices.Length;
            int[,] dp = new int[n + 1, 2];

            // base case
            dp[n, 0] = dp[n, 1] = 0;

            for (int index = n - 1; index >= 0; index--)
            {
                for (int buy = 0; buy < 2; buy++)
                {
                    int profit = 0;
                    if (buy == 1)
                    {
                        profit = Math.Max(-prices[index] + dp[index + 1, 0],
                                        0 + dp[index + 1, 1]);
                    }
                    else
                    {
                        profit = Math.Max(prices[index] + dp[index + 1, 1],
                                        0 + dp[index + 1, 0]);
                    }

                    dp[index, buy] = profit;
                }
            }

            return dp[0, 1];
        }

        // Space optimization
        // TC -> O(N * 2)
        // SC -> O(2)
        public int maxProfit_4(int[] prices)
        {
            int n = prices.Length;
            int[] ahead = new int[2];

            // base case
            ahead[0] = ahead[1] = 0;

            for (int index = n - 1; index >= 0; index--)
            {
                int[] cur = new int[2];
                for (int buy = 0; buy < 2; buy++)
                {
                    int profit = 0;
                    if (buy == 1)
                    {
                        profit = Math.Max(-prices[index] + ahead[0],
                                        0 + ahead[1]);
                    }
                    else
                    {
                        profit = Math.Max(prices[index] + ahead[1],
                                        0 + ahead[0]);
                    }

                    cur[buy] = profit;
                }
                ahead = cur;
            }

            return ahead[1];
        }

        // Using 2 variables
        // TC -> O(N * 2)
        // SC -> O(1)
        public int maxProfit_5(int[] prices)
        {
            int n = prices.Length;

            // base case
            int aheadNotBuy = 0, aheadBuy = 0, currentNotBuy, currentBuy;
            for (int index = n - 1; index >= 0; index--)
            {
                currentBuy = Math.Max(-prices[index] + aheadNotBuy,
                                    0 + aheadBuy);
                currentNotBuy = Math.Max(prices[index] + aheadBuy,
                                    0 + aheadNotBuy);

                aheadNotBuy = currentNotBuy;
                aheadBuy = currentBuy;
            }

            return aheadBuy;
        }

        // Easiest Approach
        // TC -> O(N)
        // SC -> O(1)
        public int maxProfit_6(int[] prices)
        {
            int profit = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > prices[i - 1])
                {
                    profit += prices[i] - prices[i - 1];
                }
            }
            return profit;
        }
    }
}
