using System;

namespace _1641._Count_Sorted_Vowel_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1641. Count Sorted Vowel Strings");
            int n = 2;
            Console.WriteLine($"ans is {countVowelStrings(n)}");
        }
        
        // check Java code

        public static int countVowelStrings(int n)
        {
            int[,] dp = new int[n + 1,5];

            // base case
            for (int i = 0; i < 5; i++)
            {
                dp[0,i] = 1;
            }

            for (int i = 1; i <= n; i++)
            {
                for (int ind = 4; ind >= 0; ind--)
                {
                    int count = 0;
                    for (int j = ind; j < 5; j++)
                    {
                        count += dp[i - 1,j];
                    }
                    dp[i,ind] = count;
                }
            }

            return dp[n,0];
        }
    }
}
