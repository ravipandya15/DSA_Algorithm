using System;

namespace _392._Is_Subsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("392. Is Subsequence");
        }

        public static bool IsSubsequence(string s, string t)
        {
            if (s.Length == 0) return true;
            int i = 0;
            for (int j = 0; j < t.Length; j++)
            {
                if (s[i] == t[j])
                {
                    i++;
                }

                if (i == s.Length)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
