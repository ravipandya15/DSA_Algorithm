using System;

namespace Isomorphic_Strings_205
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Isomorphic_Strings_205");
        }

        public static bool IsIsomorphic(string s, string t)
        {
            int n = s.Length;
            char[] map_s = new char[128];
            char[] map_t = new char[128];
            for (int i = 0; i < 128; i++)
            {
                map_s[i] = '0';
                map_t[i] = '0';
            }

            for (int i = 0; i < n; i++)
            {
                if (map_s[s[i]] != map_t[t[i]]) return false;
                map_s[s[i]] = (char)(i + 1);
                map_t[t[i]] = (char)(i + 1);
            }
            return true;
        }
    }
}
