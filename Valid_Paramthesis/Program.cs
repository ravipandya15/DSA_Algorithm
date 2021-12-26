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

        public static bool IsValid1(string s)
        {
            Stack<char> st = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(' || s[i] == '{' || s[i] == '[')
                    st.Push(s[i]);
                else
                {
                    if (st.Count == 0) return false;
                    char ch = st.Peek();
                    st.Pop();
                    if ((s[i] == ')' && ch == '(') ||
                        (s[i] == '}' && ch == '{') ||
                        (s[i] == ']' && ch == '['))
                    {

                    }
                    else
                    {
                        return false;
                    }
                }
            }

            if (st.Count == 0) return true;
            return false;
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Valid Paranthesis");
            string inputString = Console.ReadLine();
            Console.WriteLine($"result is {IsValid(inputString)}");
        }
    }
}
