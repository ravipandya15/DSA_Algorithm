using System;
using System.Collections.Generic;

namespace Combination_Sum_III_216
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Combination_Sum_III_216");
            int k = 9, n = 45;
            IList<IList<int>> result = CombinationSum3(k, n);
        }

        public static void solve(int number, int k, int n, IList<int> ans, IList<IList<int>> result)
        {
            // base case
            if (k < 0 || n < 0) return;
            if (k == 0 && n == 0)
            {
                result.Add(new List<int>(ans));
                return;
            }

            for (int i = number; i <= 9; i++)
            {
                if (i <= n)
                {
                    ans.Add(i);
                    n = n - i;
                    k--;
                    solve(i + 1, k, n, ans, result);
                    k++;
                    n = n + i;
                    ans.RemoveAt(ans.Count - 1);
                }
            }
        }

        public static IList<IList<int>> CombinationSum3(int k, int n)
        {
            IList<IList<int>> result = new List<IList<int>>();
            IList<int> ans = new List<int>();
            solve(1, k, n, ans, result);
            return result;
        }
    }
}
