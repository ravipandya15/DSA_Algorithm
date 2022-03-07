using System;
using System.Text;

namespace CN_Shortest_Supersequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Shortest_Supersequence");
        }

        public static string shortestSupersequence(string s, string t)
        {
            // lcs code
            int n = s.Length;
            int m = t.Length;
            int[,] dp = new int[n + 1, m + 1];

            // base case
            for (int j = 0; j <= m; j++) dp[0, j] = 0;

            for (int i = 0; i <= n; i++) dp[i, 0] = 0;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    if (s[i - 1] == t[j - 1])
                    {
                        dp[i, j] = 1 + dp[i - 1, j - 1];
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            int a = n, b = m;

            while (a > 0 && b > 0)
            {
                if (s[a - 1] == t[b - 1])
                {
                    sb.Append(s[a - 1]);
                    a--;
                    b--;
                }
                else if (dp[a - 1,b] > dp[a,b - 1])
                {
                    sb.Append(s[a - 1]);
                    a--;
                }
                else
                {
                    sb.Append(t[b - 1]);
                    b--;
                }
            }

            while (a > 0)
            {
                sb.Append(s[a - 1]);
                a--;
            }
            while (b > 0)
            {
                sb.Append(t[b - 1]);
                b--;
            }

            char[] charArray = sb.ToString().ToCharArray();

            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
