using System;

namespace Minimum_Cost_For_Tickets_983
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Minimum_Cost_For_Tickets_983");
            // days = [1,4,6,7,8,20], costs = [2,7,15]
            int[] days = { 364 };
            int[] costs = { 3, 3, 1 };
            int ans = mincostTickets_3(days, costs);
            Console.WriteLine($"ans is {ans}");
        }

        public static int solve(int index, int n, int[] days, int[] cost, int[] dp)
        {
            // base case
            if (index >= n) return 0;
            if (dp[index] != -1) return dp[index];

            int[] arr = new int[] { 1, 7, 30 };
            int ans = Int32.MaxValue;

            for (int i = 0; i < 3; i++)
            {
                int j = i;
                while (j < n && days[j] < days[index] + arr[i])
                {
                    j++;
                }
                int tempAns = cost[i] + solve(j, n, days, cost, dp);
                ans = Math.Min(ans, tempAns);
            }
            return dp[index] = ans;
        }

        public static int mincostTickets(int[] days, int[] costs)
        {
            int n = days.Length;
            int[] dp = new int[n];
            for (int i = 0; i < n; i++)
            {
                dp[i] = -1;
            }
            return solve(0, n, days, costs, dp);
        }

        public static int mincostTickets_3(int[] days, int[] costs)
        {
            int n = days.Length;
            int[] dp = new int[n + 2];

            // base case
            dp[n] = 0;
            dp[n + 1] = 0;

            for (int i = n - 1; i >= 0; i--)
            {
                int[] arr = new int[] { 1, 7, 30 };
                int ans = Int32.MaxValue;

                for (int ii = 0; ii < 3; ii++)
                {
                    int j = ii;
                    while (j < n && days[j] < days[i] + arr[ii])
                    {
                        j++;
                    }
                    int tempAns = costs[ii] + dp[j];
                    ans = Math.Min(ans, tempAns);
                }
                dp[i] = ans;
            }

            return dp[0];
        }
    }
}
