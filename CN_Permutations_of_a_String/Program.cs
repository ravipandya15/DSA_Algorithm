using System;
using System.Collections.Generic;
using System.Text;

namespace CN_Permutations_of_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Permutations_of_a_String");
            string str = "abc";
            var result = generatePermutations(str);
            Console.ReadLine();
        }

        private static void Swap(int i, int j, StringBuilder str)
        {
            char temp = str[i];
            str[i] = str[j];
            str[j] = temp;
        }

        private static void Solve(int index, StringBuilder output, List<string> result)
        {
            // base case
            if (index == output.Length)
            {
                result.Add(new string(output.ToString()));
                return;
            }
                

            for (int i = index; i < output.Length; i++)
            {
                Swap(index, i, output);
                Solve(index + 1, output, result);
                Swap(index, i, output);
            }
        }

        public static IList<string> generatePermutations(string str)
        {
            List<string> result = new List<string>();
            StringBuilder output = new StringBuilder(str);
            Solve(0, output, result);
            result.Sort();
            return result;
        }
    }
}
