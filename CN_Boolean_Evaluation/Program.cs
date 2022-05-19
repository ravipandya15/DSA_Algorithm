using System;

namespace CN_Boolean_Evaluation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static long solve(int i, int j, int isTrue, string exp, int mod)
        {
            // base case
            if (i > j) return 0;

            if (i == j)
            {
                if (isTrue == 1) return exp[i] == 'T' ? 1 : 0;
                else return exp[i] == 'F' ? 1 : 0;
            }

            long ways = 0;
            for (int ind = i + 1; ind <= j - 1; ind += 2)
            {
                long lT = solve(i, ind - 1, 1, exp, mod);
                long lF = solve(i, ind - 1, 0, exp, mod);
                long rT = solve(ind + 1, j, 1, exp, mod);
                long rF = solve(ind + 1, j, 0, exp, mod);

                if (exp[ind] == '&')
                {
                    if (isTrue == 1) ways = (ways + (lT * rT) % mod) % mod;
                    else ways = (ways + (lT * rF) % mod + (lF * rT) % mod + (lF * rF) % mod) % mod;
                }
                else if (exp[ind] == '|')
                {
                    if (isTrue == 1) ways = (ways + (lT * rF) % mod + (lF * rT) % mod + (lT * rT) % mod) & mod;
                    else ways = (ways + (lF * rF) % mod) % mod;
                }
                else
                {// exp[ind] == '^'
                    if (isTrue == 1) ways = (ways + (lT * rF) % mod + (lF * rT)) % mod;
                    else ways = (ways + (lT * rT) % mod + (lF * rF)) % mod;
                }
            }

            return ways % mod;
        }

        // Recusrion
        // TC -> Exponential
        int evaluateExp_1(string exp)
        {
            int mod = (int)1000000007;
            return (int)solve(0, exp.Length - 1, 1, exp, mod);
        }

        int solve_1(int i, int j, int isTrue, string exp, int mod, int[,,] dp)
        {
            // base case
            if (i > j) return 0;

            if (i == j)
            {
                if (isTrue == 1) return exp[i] == 'T' ? 1 : 0;
                else return exp[i] == 'F' ? 1 : 0;
            }

            if (dp[i,j,isTrue] != -1) return dp[i,j,isTrue];

            long ways = 0;
            for (int ind = i + 1; ind <= j - 1; ind += 2)
            {
                long lT = solve_1(i, ind - 1, 1, exp, mod, dp);
                long lF = solve_1(i, ind - 1, 0, exp, mod, dp);
                long rT = solve_1(ind + 1, j, 1, exp, mod, dp);
                long rF = solve_1(ind + 1, j, 0, exp, mod, dp);

                if (exp[ind] == '&')
                {
                    if (isTrue == 1) ways = (ways + (lT * rT) % mod) % mod;
                    else ways = (ways + (lT * rF) % mod + (lF * rT) % mod + (lF * rF) % mod) % mod;
                }
                else if (exp[ind] == '|')
                {
                    if (isTrue == 1) ways = (ways + (lT * rF) % mod + (lF * rT) % mod + (lT * rT) % mod) & mod;
                    else ways = (ways + (lF * rF) % mod) % mod;
                }
                else
                {// exp[ind] == '^'
                    if (isTrue == 1) ways = (ways + (lT * rF) % mod + (lF * rT)) % mod;
                    else ways = (ways + (lT * rT) % mod + (lF * rF)) % mod;
                }
            }

            return dp[i,j,isTrue] = (int)(ways % mod);
        }

        // Memoization
        // TC -> O(N^3)
        // Sc-> O(N^2) + Stack space
        int evaluateExp_2(string exp)
        {
            int n = exp.Length;
            int mod = (int)1000000007;
            int[,,] dp = new int[n, n, 2];
            return solve_1(0, n - 1, 1, exp, mod, dp);
        }
    }
}
