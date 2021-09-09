using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace No_of_Segments
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "Hello, My name is Ravi Pandya!";
            s = ", , , ,        a, eaefa    ";
            
            Console.WriteLine("No of Segments are : ", Program.CountSegments(s));
            Console.ReadLine();
        }

        public static int CountSegments(string s)
        {
            string trimmed = s.Trim();
            if (string.IsNullOrWhiteSpace(trimmed))
            {
                return 0;
            }
            string result = Regex.Replace(trimmed, "\\s+", " ");
            return result.Split(" ").ToList().Count;
        }
    }
}
