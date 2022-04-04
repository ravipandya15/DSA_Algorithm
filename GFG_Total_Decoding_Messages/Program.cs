using System;

namespace GFG_Total_Decoding_Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GFG_Total_Decoding_Messages");
			string str = "1411511110191111101011871111111111111511374411510811111311124711511116468111611111116111111111117";

			// check first Countways3 sol -> Tabulation
			int result = CountWays3(str);
		}

        public static int solve(int ind, string s)
		{
			// base case
			if (ind == -1) return 1;
			if (ind == 0)
			{
				if (s[ind] == '0') return 0;
				else return 1;
			}

			int count = 0;
			if (s[ind] > '0')
			{
				count += solve(ind - 1, s);
			}
			if ((s[ind-1] == '1') || (s[ind-1] == '2' && s[ind] < '7'))
			{
				count += solve(ind - 2, s);
			}
			return count;
		}

		public static int CountWays(string str)
        {
			int n = str.Length;
			return solve(n - 1, str);
		}

		public static int solve1(int ind, string s)
		{
			// base case
			if (ind == 0) return 1;
			if (ind == 1)
			{
				if (s[ind] == '0') return 0;
				else return 1;
			}

			int count = 0;
			if (s[ind-1] > '0')
			{
				count += solve1(ind - 1, s);
			}
			if ((s[ind - 2] == '1') || (s[ind - 2] == '2' && s[ind -1] < '7'))
			{
				count += solve1(ind - 2, s);
			}
			return count;
		}

		// convert to 1 based indexing
		public static int CountWays1(string str)
		{
			int n = str.Length;
			return solve1(n, str);
		}

		// Memoization
		public static int solve2(int ind, string s, int[] dp)
		{
			// base case
			if (ind == 0) return dp[0] = 1;
			if (ind == 1)
			{
				if (s[ind-1] == '0') return dp[1] = 0;
				else return dp[1] = 1;
			}

			if (dp[ind] != -1) return dp[ind];

			int count = 0;
			if (s[ind - 1] > '0')
			{
				count += solve2(ind - 1, s, dp);
			}
			if ((s[ind - 2] == '1') || (s[ind - 2] == '2' && s[ind - 1] < '7'))
			{
				count += solve2(ind - 2, s, dp);
			}
			return dp[ind] = count;
		}

		// convert to 1 based indexing
		public static int CountWays2(string str)
		{
			int n = str.Length;
			int[] dp = new int[n + 1];
			for (int i = 0; i <= n; i++) dp[i] = -1;
			return solve2(n, str, dp);
		}

		// tabulation
		public static int CountWays3(string s)
		{
			int mod = (int)(1e9 + 7);
			int n = s.Length;
			double[] dp = new double[n + 1];


			// base case
			dp[0] = 1;
			if (s[0] == '0') dp[1] = 0;
			else dp[1] = 1;

			if (n == 1) return (int)dp[1];

			for (int ind = 2; ind <= n; ind++)
			{
				double count = 0;
				if (s[ind - 1] > '0')
				{
					count += (dp[ind - 1] % mod);
				}
				if ((s[ind - 2] == '1') || (s[ind - 2] == '2' && s[ind - 1] < '7'))
				{
					count += (dp[ind - 2] % mod);
				}
				dp[ind] = count % mod;
			}

			return (int)(dp[n]);
		}
	}
}
