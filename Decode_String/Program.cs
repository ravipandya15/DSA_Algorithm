using System;
using System.Linq;
using System.Text;

namespace Decode_String
{
    class Program
    {
        // will not work for input String a2345678999999999999999 - String out of memory exception
        public static char DecodedStringWithIndex(string inputString, int index)
        {
            char outputChar = ' ';
            int digit = 0;
            StringBuilder sb = new StringBuilder("");
            //string outputString = string.Empty;
            for (int i = 0; i < inputString.Length; i++)
            {
                if (!char.IsDigit(inputString[i]))
                {
                    //outputString += inputString[i];
                    //sb.Append(inputString[i]);
                }
                else
                {
                    // s will only contain lowercase letters and digits 2 through 9.
                    digit = Convert.ToInt32(char.GetNumericValue(inputString[i])) - 1;
                    string temp = Convert.ToString(sb);
                    while (digit != 0)
                    {
                        sb.Append(temp);
                        //outputString += temp;
                        digit--;
                    }
                }
            }
            Console.WriteLine($"Output String is {sb.ToString()}");

            //It's guaranteed that index is less than or equal to the length of the decoded string.
            if (index-1 <= sb.Length-1)
            {
                return sb[index-1];
            }
            return outputChar;
        }

        public static string DecodeAtIndex(string s, int k)
        {
            string outputString = string.Empty;

            // find total size of output string
            long size = 0;
            int n = s.Length;
            for (int i = 0;i < n; i++)
            {
                if (char.IsDigit(s[i]))
                {
                    size = size * (s[i] - '0');
                }
                else
                {
                    size++;
                }
            }

            Console.WriteLine($"Size is {size}");

            for (int i = n -1; i>=0; i--)
            {
                k = (int)(k % size);
                if (k == 0 && char.IsLetter(s[i]))
                {
                    return s[i].ToString();
                }
                if (char.IsDigit(s[i]))
                {
                    size = size / (s[i] - '0');
                }
                else
                {
                    size--;
                }
            }
            throw null;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Decoded String at index");
            while (true)
            {
                Console.WriteLine("Enter a string");
                string inputString = Console.ReadLine();
                Console.WriteLine("Enter an index");
                int index = Convert.ToInt32(Console.ReadLine());
                //Console.WriteLine($"the {index}th letter in decoded string is {DecodedStringWithIndex(inputString, index)}");
                Console.WriteLine($"the {index}th letter in decoded string is {DecodeAtIndex(inputString, index)}");
            }
        }
    }
}
