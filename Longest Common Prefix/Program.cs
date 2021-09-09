using System;
using System.Linq;

namespace Longest_Common_Prefix
{
    class Program
    {
        public static string LongestCommonPrefix(string[] strings)
        {
            string result = string.Empty;
            int highestLength = strings.Aggregate("", (max, cur) => max.Length > cur.Length ? max : cur).Length;

            for (int i = 0; i < highestLength; i++)
            {

            }

            return result;
        }

        static void Main(string[] args)
        {
            string[] strings = new string[3] { "flower", "flow", "flight" };
            string result = LongestCommonPrefix(strings);
            Console.WriteLine($"Longest Common Prefix is {result}");
            Console.ReadLine();
        }
    }
}
