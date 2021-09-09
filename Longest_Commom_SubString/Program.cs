using System;

namespace Longest_Commom_SubString
{
    class Program
    {
        public static int LongestCommonSubString(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;

            int[,] DP = new int[n + 1, m + 1];
            int result = 0;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        DP[i, j] = 0;
                    }
                    else if (s[i-1] == t[j-1])
                    {
                        DP[i, j] = DP[i - 1, j - 1] + 1;
                        result = Math.Max(result, DP[i, j]);
                    }
                    else
                    {
                        DP[i, j] = 0;
                    }
                }
            }
            return result;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Longest Common SubString");
            string s = "abcdxyz";
            string t = "xyzabcd";

            Console.WriteLine($"Longest Common SubString is {LongestCommonSubString(s, t)}");
        }
    }
}
