using System;
using System.Collections.Generic;

namespace Compress_String
{
    //Input: chars = ["a","a","b","b","c","c","c"]
    //Output: Return 6, and the first 6 characters of the input array should be: ["a","2","b","2","c","3"]
    //Explanation: The groups are "aa", "bb", and "ccc". This compresses to "a2b2c3".
    //Input: chars = ["a","b","b","b","b","b","b","b","b","b","b","b","b"]
    //Output: Return 4, and the first 4 characters of the input array should be: ["a","b","1","2"].
    //Explanation: The groups are "a" and "bbbbbbbbbbbb". This compresses to "ab12".
    class Program
    {
        public static Tuple<int, int> FindModulo(int value)
        {
            int modulo = -1;
            int result = -1;
            result = Convert.ToInt32(Math.Floor(Convert.ToDecimal(value) / 10));
            modulo = value % 10;
            Tuple<int, int> tuple = Tuple.Create(result, modulo);
            return tuple;
        }

        public static void Compute(List<string> output, char[] chars, char currentChar, int currentOccurence)
        {
            Tuple<int, int> resultAndModuloTuple;
            Stack<int> stack = new Stack<int>();
            bool flag = false;
            output.Add(currentChar.ToString());
            resultAndModuloTuple = FindModulo(currentOccurence);
            while (resultAndModuloTuple.Item1 != 0)
            {
                flag = true;
                stack.Push(resultAndModuloTuple.Item2);
                resultAndModuloTuple = FindModulo(resultAndModuloTuple.Item1);
            }
            if (flag == true)
            {
                stack.Push(resultAndModuloTuple.Item2);
                while (stack.Count != 0)
                {
                    output.Add(stack.Pop().ToString());
                }
            }
            else
            {
                if (Convert.ToChar(resultAndModuloTuple.Item2) > 1)
                {
                    output.Add(resultAndModuloTuple.Item2.ToString());
                }
            }
        }

        public static int Compress(char[] chars)
        {
            if (chars == null && chars.Length == 0)
                return 0;

            char currentChar = chars[0];
            int currentOccurence = 1;
            List<string> output = new List<string>();

            for (int i = 1; i < chars.Length; i++)
            {
                if (chars[i].Equals(currentChar))
                {
                    currentOccurence++;
                }
                else
                {
                    Compute(output, chars, currentChar, currentOccurence);
                    currentChar = chars[i];
                    currentOccurence = 1;
                }
            }
            Compute(output, chars, currentChar, currentOccurence);
            Console.WriteLine("compressed array is ....");
            for (int i = 0; i < output.Count; i++)
            {
                Console.Write(output[i] + " ");
            }
            return output.Count;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Compresssed String");
            while (true)
            {
                Console.WriteLine("Enter length of input arrays");
                int n = Convert.ToInt32(Console.ReadLine());
                char[] chars = new char[n];
                Console.WriteLine($"Enter {n} times...");
                for (int i = 0; i < n; i++)
                {
                    chars[i] = Convert.ToChar(Console.ReadLine());
                }
                Console.WriteLine($"chars array is...");
                for (int i = 0; i < n; i++)
                {
                    Console.Write(chars[i] + " ");
                }
                Console.WriteLine($"length of compressed string is {Compress(chars)}");
            }
        }
    }
}
