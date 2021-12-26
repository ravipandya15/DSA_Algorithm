using System;

namespace _1047._Remove_All_Adjacent_Duplicates_In_String
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1047. Remove All Adjacent Duplicates In String");
            string s = "azxxzy";
            Console.WriteLine($"String after removing all it's adjacent is {RemoveDuplicates(s)}");
            Console.ReadLine();
        }

        public static string RemoveDuplicates(string s)
        {
            int i = 1;
            int n = s.Length;

            while (i < n)
            {
                if (s[i] == s[i - 1])
                {
                    // as length is endIndex - startIndex + 1
                    s = s.Substring(0, i - 2 - 0 + 1) + s.Substring(i + 1);
                    i = 1;
                    n = s.Length;
                }
                else
                {
                    i++;
                }
            }

            return s;
        }
    }
}
