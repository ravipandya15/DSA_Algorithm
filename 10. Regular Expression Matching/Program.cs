using System;

namespace _10._Regular_Expression_Matching
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("10. Regular Expression Matching");
            string text = "aab";
            string pattern = "c*a*b";
            bool ans = isMatch(text, pattern);
            Console.WriteLine($"answer is {ans}");
        }

        public static int solve_2(int i, int j, string pattern, string text, int[,] dp)
        {
            // base case
            if (i == 0 && j == 0) return 1;
            if (i == 0 && j > 0) return 0;
            if (j == 0 && i > 0)
            {
                for (int ii = 1; ii <= i; ii++)
                {
                    if (pattern[ii - 1] != '*')
                    {
                        return 0;
                    }
                }
                return 1;
            }

            if (dp[i,j] != -1) return dp[i,j];

            if ((pattern[i - 1] == text[j - 1]) || (pattern[i - 1] == '?'))
            {
                return dp[i,j] = solve_2(i - 1, j - 1, pattern, text, dp);
            }
            else if ((pattern[i - 1] == '*'))
            {
                int temp = solve_2(i - 1, j, pattern, text, dp);
                if (temp == 0)
                {
                    temp = solve_2(i, j - 1, pattern, text, dp);
                }

                return dp[i, j] = temp;
            }
            else
            {
                return 0;
            }
        }

        public static bool isMatch(string text, string pattern)
        {
            int n = pattern.Length;
            int m = text.Length;
            int[,] dp = new int[n + 1,m + 1];
            for (int i = 0; i < n + 1; i++)
            {
                for (int j = 0; j < m + 1; j++)
                {
                    dp[i,j] = -1;
                }
            }
            return solve_2(n, m, pattern, text, dp) == 1 ? true : false;
        }
    }
}
