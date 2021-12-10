using System;
using System.Collections.Generic;

namespace _131._Palindrome_Partitioning
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("131. Palindrome Partitioning");
            string s = "aabb";
            var result = Partition(s);
            Console.ReadLine();
        }

        public static bool IsPalindrom(string s, int start, int end)
        {
            while (start <= end)
            {
                if (s[start++] != s[end--])
                {
                    return false;
                }
            }
            return true;
        }

        public static void func(string s, int index, IList<string> path, IList<IList<string>> res)
        {
            // base condition
            if (index == s.Length)
            {
                res.Add(new List<string>(path));
                return;
            }

            for (int i = index; i < s.Length; i++)
            {
                if (IsPalindrom(s, index, i))
                {
                    path.Add(s.Substring(index, i - index + 1));
                    func(s, i + 1, path, res);
                    path.RemoveAt(path.Count - 1);
                }
            }
        }

        public static IList<IList<string>> Partition(string s)
        {
            IList<IList<string>> res = new List<IList<string>>();
            IList<string> path = new List<string>();
            func(s, 0, path, res);
            return res;
        }
    }
}
