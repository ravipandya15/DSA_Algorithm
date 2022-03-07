using System;

namespace CN_Number_of_ways_to_clear_the_pit
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Number_of_ways_to_clear_the_pit");
            int count = waysToClear(4, 2);
        }


        // k is static so it will be solved using 1D array
        // Check this
        // below code was giving TLE -> may be used 2D array -> 1D array will work


        public static int solve(int n, int k, int mod)
        {
            // base case
            if (n < 0) return 0;
            if (n == 0) return 1;

            int count = 0;
            // check all case
            for (int i = 1; i <= k; i++)
            {
                if (i <= n)
                {
                    count += solve(n-i, k, mod);
                }
            }
            return count % (mod);
        }

        public static int solve(int n, int k, int mod, int[,] dp)
        {
            // base case
            if (n < 0) return 0;
            if (n == 0) return 1;

            if (dp[n,k] != -1) return dp[n,k];

            int count = 0;
            // check all case
            for (int i = 1; i <= k; i++)
            {
                if (i <= n)
                {
                    count += solve(n - i, k, mod, dp);
                }
            }
            return dp[n,k] = count % (mod);
        }

        public static int waysToClear(int n, int k)
        {
            int[,] dp = new int[n+1,k+1];

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= k; j++)
                {
                    dp[i, j] = -1;
                }
            }
            int mod = (int)(1e9 + 7);
            return solve(n, k, mod, dp);
        }
    }
}
