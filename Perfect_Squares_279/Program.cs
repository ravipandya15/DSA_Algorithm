using System;

namespace Perfect_Squares_279
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Perfect_Squares_279");
            int ans = numSquares(12);
            Console.WriteLine($"ans is {ans}");
        }

        public static int solve(int n, int[] dp)
        {
            // base case
            if (n == 0) return 0;

            if (dp[n] != -1) return dp[n];

            int ans = n;
            for (int i = 1; i < n; i++)
            {
                if (i * i > n)
                {
                    break;
                }
                ans = Math.Min(ans, 1 + solve(n - i * i, dp));
            }
            return dp[n] = ans;
        }
        public static int numSquares(int n)
        {
            int[] dp = new int[n + 1];
            for (int i = 0; i <= n; i++)
            {
                dp[i] = -1;
            }
            int ans = solve(n, dp);
            return ans;
        }
    }
}
