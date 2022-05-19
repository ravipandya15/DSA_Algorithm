using System;
using System.Collections.Generic;

namespace CN_Longest_String_Chain
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Longest_String_Chain");
            List<string> list = new List<string>();
            list.Add("bac");
            list.Add("ba");
            list.Add("a");
            int maxi = longestStrChain(list);
            Console.WriteLine($"answer is {maxi}");
        }

        public class comparator : IComparer<string>
        {
            public int Compare(string s1, string s2)
            {
                if (s2.Length < s1.Length)
                {
                    return 1;
                }
                return -1;
            }
        }

        // here s1 is always longer than s2
        public static bool checkPossible(string s1, string s2)
        {
            if (s1.Length != s2.Length + 1) return false;

            int first = 0;
            int second = 0;

            while (first < s1.Length && second < s2.Length)
            {
                if (s1[first] == s2[second])
                {
                    first++;
                    second++;
                }
                else
                {
                    first++;
                }
            }

            if (second == s2.Length) return true;

            //if (first == s1.Length && second == s2.Length) return true;
            return false;
        }

        public static int longestStrChain(List<string> arr)
        {
            int n = arr.Count;
            int[] dp = new int[n];
            for (int i = 0; i < n; i++) dp[i] = 1;
            int maxi = 1;
            arr.Sort(new comparator());

            for (int i = 1; i < n; i++)
            {
                for (int prev = 0; prev < i; prev++)
                {
                    if (checkPossible(arr[i], arr[prev]) && 1 + dp[prev] > dp[i])
                    {
                        dp[i] = 1 + dp[prev];
                    }
                }
                maxi = Math.Max(maxi, dp[i]);
            }

            return maxi;
        }
}
}
