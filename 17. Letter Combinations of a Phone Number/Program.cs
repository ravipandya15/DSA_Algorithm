using System;
using System.Collections.Generic;
using System.Text;

namespace _17._Letter_Combinations_of_a_Phone_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("17. Letter Combinations of a Phone Number");
            string numberString = "23";
            var result = LetterCombinations(numberString);
            Console.ReadLine();
        }

        private static void Solve(string digits, int index, StringBuilder output, 
                                  string[] mapping, IList<string> result)
        {
            if (index == digits.Length)
            {
                result.Add(new string(output.ToString()));
                return;
            }

            int number = digits[index] - '0';
            string value = mapping[number];

            for (int i = 0; i < value.Length; i++)
            {
                output.Append(value[i]);
                Solve(digits, index + 1, output, mapping, result);
                output.Remove(output.Length - 1, 1); // knows as back-tracking
            }
        }

        public static IList<string> LetterCombinations(string digits)
        {
            IList<string> result = new List<string>();

            if (digits.Length == 0) return result;
            StringBuilder output = new StringBuilder();
            string[] mapping = new string[] { "", "", "abc","def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz"};

            Solve(digits, 0, output, mapping, result);
            return result;
        }
    }
}
