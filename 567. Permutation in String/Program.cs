using System;

namespace _567._Permutation_in_String
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("567. Permutation in String");
            string s1 = "ab", s2 = "eidbaooo";
            Console.WriteLine($"is {s2} contains permutation of {s1}? - {CheckInclusion(s1, s2)}");
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

        // TC -> O(m + n) -> m is length of s1, n is length of s2
        // SC -> O(1)
        public static bool CheckInclusion(string s1, string s2)
        {
            // character count array
            int[] count = new int[26];
            int windowSize = s1.Length;
            for (int j = 0; j < windowSize; j++)
            {
                int temp = s1[j] - 'a';
                count[temp]++;
            }

            int[] count2 = new int[26];

            int i = 0;

            // checking 1st window
            //i < s2.Length is required as iterator is possible that s1 is larger than s2
            while (i < windowSize && i < s2.Length)
            {
                int temp = s2[i] - 'a';
                count2[temp]++;
                i++;
            }

            // check if both array are equal
            if (Compare(count, count2))
                return true;

            // else check remaining window
            while (i < s2.Length)
            {
                // add new character
                char newChar = s2[i];
                int index = newChar - 'a';
                count2[index]++;

                // remove last index -> which is processed
                char oldChar = s2[i - windowSize];
                index = oldChar - 'a';
                count2[index]--;

                i++;

                if (Compare(count, count2))
                    return true;
            }
            return false;
        }
    }
}
