using System;
using System.Collections.Generic;
using System.Text;

namespace Subsequences_of_String
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Subsequences of String");
            // same as subset but empty string is not consider as Subsequences
            string str = "abc";
            var result = subsequences(str);
            Console.ReadLine();
        }

        private static void solve(string str, int index, StringBuilder output, List<string> ans)
        {
            // base case
            if (index >= str.Length)
            {
                if (output.Length > 0)
                {
                    ans.Add(new string(output.ToString()));
                }
                return;
            }

            // exclude
            solve(str, index + 1, output, ans);

            // inclde
            output.Append(str[index]);
            solve(str, index + 1, output, ans);
            output.Remove(output.Length - 1, 1);
        }

        public static List<string> subsequences(string str)
        {
            List<string> ans = new List<string>();
            string s = "";
            StringBuilder output = new StringBuilder(s);
            solve(str, 0, output, ans);
            return ans;
        }
    }
}
