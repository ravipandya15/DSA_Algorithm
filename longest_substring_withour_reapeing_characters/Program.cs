using System;
using System.Collections.Generic;
using System.Linq;

namespace longest_substring_withour_reapeing_characters
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string inputString = "dvdf";
            
            Console.WriteLine($"Max Count is {LengthOfLongestSubstring("abcaabcdba")}");
            Console.ReadLine();
        }

        // Sliding window
        // time complexity -> O(2N)
        // space complexity -> O(N)
        public static int LengthOfLongestSubstring1(string s)
        {
            int left = 0, right = 0;
            int len = 0;
            int n = s.Length;
            HashSet<int> hashSet = new HashSet<int>();

            while (right < n)
            {
                while (hashSet.Contains(s[right]))
                {
                    hashSet.Remove(s[left]);
                    left++;
                }

                hashSet.Add(s[right]);
                len = Math.Max(len, right - left + 1);
                right++;
            }

            return len;
        }

        // most optimal -> improvement on sliding window
        // time complexity -> O(N)
        // space complexity -> O(N)
        public static int LengthOfLongestSubstring(string s)
        {
            int left = 0, right = 0;
            int len = 0;
            int n = s.Length;
            Dictionary<char, int> hashMap = new Dictionary<char, int>();

            while (right < n)
            {
                if (hashMap.TryGetValue(s[right], out int temp))
                {
                    left = Math.Max(left, temp + 1);
                    hashMap[s[right]] = right;
                }
                else
                {
                    hashMap.Add(s[right], right);
                }

                len = Math.Max(len, right - left + 1);
                right++;
            }

            return len;
        }
    }
}
