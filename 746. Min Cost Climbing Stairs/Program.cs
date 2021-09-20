using System;

namespace _746._Min_Cost_Climbing_Stairs
{
    class Program
    {
        static int[] dp;
        static void Main(string[] args)
        {
            Console.WriteLine("746. Min Cost Climbing Stairs");
            int[] cost = { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1 };
            int result = MinCostClimbingStairs(cost);
            Console.WriteLine($"Cost is {result}");
            Console.ReadLine();
        }

        public static int MinCostClimbingStairs(int[] cost)
        {
            int n = cost.Length;
            dp = new int[n];
            return Math.Min(minCost(cost, n - 1), minCost(cost, n - 2));
        }

        public static int minCost(int[] cost, int n)
        {
            if (n < 0)
                return 0;
            if (n == 0 || n == 1)
                return cost[n];
            if (dp[n] != 0)
                return dp[n];
            dp[n] = cost[n] + Math.Min(minCost(cost, n - 1), minCost(cost, n - 2));
            return dp[n];
        }
    }
}
