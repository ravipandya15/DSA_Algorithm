using System;
using System.Text;

namespace Cn_Encode_The_String
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string result = encodeString(3, "dog");
        }

        public static String encodeString(int n, string s)
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                if (s[i] == 'a' || s[i] == 'e' || s[i] == 'i' || s[i] == 'o' || s[i] == 'u')
                {
                    char ch = Convert.ToChar(s[i] + 1);
                    str.Append(ch);
                }
                else
                {
                    char ch = Convert.ToChar(s[i] - 1);
                    str.Append(ch);
                }

            }
            return str.ToString();
        }

    }
}
