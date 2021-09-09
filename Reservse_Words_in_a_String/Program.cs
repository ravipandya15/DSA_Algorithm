using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Reservse_Words_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "Alice does not even like bob";
            Console.WriteLine(s);
            Console.WriteLine("Reverse Words in a Strings are !");
            Console.WriteLine(Program.ReverseWords(s));
            Console.ReadLine();
        }

        public static string ReverseWords(string s)
        {
            string trimmed = s.Trim();
            if (string.IsNullOrWhiteSpace(trimmed) || trimmed == string.Empty)
            {
                return s;
            }
            string spaceSeperateString = Regex.Replace(trimmed, "\\s+", " ");
            List<string> resultList = spaceSeperateString.Split(" ").ToList();
            string result = string.Empty;
            for (int i = resultList.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    result += resultList[i];
                }
                else
                {
                    result += resultList[i] + " ";
                }
            }

            return result;
        }
    }
}
