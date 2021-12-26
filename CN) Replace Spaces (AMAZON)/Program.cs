using System;
using System.Text;

namespace CN__Replace_Spaces__AMAZON_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN) Replace Spaces");
            Console.ReadLine();
        }

        public static StringBuilder replaceSpaces(StringBuilder str)
        {
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                {
                    output.Append("@40");
                }
                else
                {
                    output.Append(str[i]);
                }
            }
            return output;
        }
    }
}
