using System;
using System.Collections.Generic;

namespace _438._Find_All_Anagrams_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("438. Find All Anagrams in a String");
            string s1 = "cbaebabacd", s2 = "abc";
            var result = FindAnagrams(s1, s2);
            Console.ReadLine();
        }

        private static bool Compare(int[] a, int[] b)
        {
            for (int i = 0; i < 26; i++)
            {
                if (a[i] != b[i])
                    return false;
            }
            return true;
        }

        public static IList<int> FindAnagrams(string s, string p)
        {
            IList<int> result = new List<int>();

            // character count array
            int[] count = new int[26];
            int windowSize = p.Length;
            for (int j = 0; j < windowSize; j++)
            {
                int temp = p[j] - 'a';
                count[temp]++;
            }

            int[] count2 = new int[26];

            int i = 0;

            // checking 1st window
            //i < s2.Length is required as iterator is possible that s1 is larger than s2
            while (i < windowSize && i < s.Length)
            {
                int temp = s[i] - 'a';
                count2[temp]++;
                i++;
            }

            // check if both array are equal
            if (Compare(count, count2))
                result.Add(i-windowSize);

            // else check remaining window
            while (i < s.Length)
            {
                // add new character
                char newChar = s[i];
                int index = newChar - 'a';
                count2[index]++;

                // remove last index -> which is processed
                char oldChar = s[i - windowSize];
                index = oldChar - 'a';
                count2[index]--;

                i++;

                if (Compare(count, count2))
                    result.Add(i - windowSize);
            }
            return result;
        }

    }
}
