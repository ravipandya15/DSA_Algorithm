using System;
using System.Collections.Generic;

namespace Minimum_Window_Substring_76
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Minimum_Window_Substring_76");
            string s = "TOTMTAPTAT";
            string t = "TTA";
            string result = MinWindow(s, t);
        }

        public static string MinWindow(string s, string t)
        {
            if (t.Length > s.Length) return "";
            Dictionary<char, int> mp = new Dictionary<char, int>();

            for (int k = 0; k < t.Length; k++)
            {
                if (mp.ContainsKey(t[k]))
                {
                    mp[t[k]] = mp[t[k]] + 1;
                }
                else
                {
                    mp.Add(t[k], 1);
                }
            }

            int count = mp.Count;

            int i = 0, j = 0;
            int minI = 0, minJ = 0;
            int minLength = 0;
            int n = s.Length;

            while (j < n)
            {
                if (mp.ContainsKey(s[j]))
                {
                    mp[s[j]]--;
                    if (mp[s[j]] == 0)
                    {
                        count--;
                    }
                }
                if (count > 0)
                {
                    j++;
                }
                else if (count == 0)
                {
                    while (count == 0)
                    {
                        if (minLength == 0 || j - i + 1 < minLength)
                        {
                            minI = i;
                            minJ = j;
                            minLength = minJ - minI + 1;
                        }
                        if (mp.ContainsKey(s[i]))
                        {
                            mp[s[i]]++;
                            if (mp[s[i]] > 0)
                            {
                                count++;
                            }
                        }
                        i++;
                    }
                    j++;
                }
            }

            return s.Substring(minI, minLength);
        }
    }
}
