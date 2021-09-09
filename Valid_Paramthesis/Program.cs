using System;
using System.Collections.Generic;

namespace Valid_Paramthesis
{
    class Program
    {
        public static bool IsValid(string s)
        {
            Stack<char> stack = new Stack<char>();

            foreach (var item in s.ToCharArray())
            {
                if (item == '(')
                    stack.Push(')');
                else if (item == '[')
                    stack.Push(']');
                else if (item == '{')
                    stack.Push('}');
                else if (stack.Count == 0 || stack.Pop() != item)
                    return false;
            }

            return stack.Count == 0;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Valid Paranthesis");
            string inputString = Console.ReadLine();
            Console.WriteLine($"result is {IsValid(inputString)}");
        }
    }
}
