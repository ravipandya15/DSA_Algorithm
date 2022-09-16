using System;

namespace Jump_Game_VII_1871
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string s = "01101110";
            int min = 2, max = 3;
            bool ans = canReach(s, min, max);
            Console.WriteLine($"ans is {ans}");
        }

        public static int solve(int ind, string s, int min, int max, int n, int[] dp)
        {
            // base case
            if (ind == n - 1) return 1;

            if (dp[ind] != -1) return dp[ind];

            for (int i = ind + min; i <= Math.Min(ind + max, n - 1); i++)
            {
                if (s[i] == '0')
                {
                    if (solve(i, s, min, max, n, dp) == 1) return dp[ind] = 1;
                }
            }
            return dp[ind] = 0;
        }

        public static bool canReach(string s, int minJump, int maxJump)
        {
            int n = s.Length;
            int[] dp = new int[n];
            for (int i = 0; i < n; i++)
            {
                dp[i] = -1;
            }
            int ans = solve(0, s, minJump, maxJump, n, dp);
            return ans == 1 ? true : false;
        }
    }
}
