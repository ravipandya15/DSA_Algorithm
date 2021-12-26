using System;

namespace _1910._Remove_All_Occurrences_of_a_Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1910. Remove All Occurrences of a Substring");
            string s = "daabcbaabcbc";
            string part = "abc";
            Console.WriteLine($"Resultant string is {RemoveOccurrences(s, part)}");
            Console.ReadLine();
        }

        public static string RemoveOccurrences(string s, string part)
        {
            //while (s.Length > 0 && s.IndexOf(part) != 1)
            //{
            //    s.Remove(s.IndexOf(part), part.Length);
            //}
            //return s;

            while (s.Contains(part))
            {
                s = s.Remove(s.IndexOf(part), part.Length);
            }
            return s;
        }
    }
}
