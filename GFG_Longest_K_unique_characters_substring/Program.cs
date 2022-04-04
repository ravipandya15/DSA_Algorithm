using System;
using System.Collections.Generic;

namespace GFG_Longest_K_unique_Characters_substring
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GFG_Longest_K_unique_chars_substring");
        }

        public int longestkSubstr(string s, int k)
        {
            Dictionary<char, int> mp = new Dictionary<char, int>();

            int i = 0, j = 0;
            int maxi = -1;
            int n = s.Length;

            while (j < n)
            {
                // calculation
                if (mp.ContainsKey(s[j]))
                {
                    mp[s[j]] = mp[s[j]] + 1;
                }
                else
                {
                    mp.Add(s[j], 1);
                }

                if (mp.Count < k)
                {
                    j++;
                }
                else if (mp.Count == k)
                {
                    // ans
                    maxi = Math.Max(maxi, j - i + 1);
                    j++;
                }
                else if (mp.Count > k)
                {
                    while (mp.Count > k)
                    {
                        mp[s[i]] = mp[s[i]] - 1;
                        if (mp[s[i]] == 0)
                        {
                            mp.Remove(s[i]);
                        }
                        i++;
                    }
                    j++;
                }
            }

            return maxi;
        }
    }
}
