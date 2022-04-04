using System;
using System.Collections.Generic;
using System.Text;

namespace _1249._Minimum_Remove_to_Make_Valid_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1249. Minimum Remove to Make Valid Parentheses");
            string s = "lee(t(c)o)de)";
            string ans = MinRemoveToMakeValid(s);
        }

        // Approach 1 : Using Stack
        public static string MinRemoveToMakeValid(string s)
        {
            StringBuilder sb = new StringBuilder();
            Stack<int> stack = new Stack<int>();
            int n = s.Length;
            for (int i = 0; i < n; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(i);
                }
                else if (s[i] == ')')
                {
                    if (stack.Count > 0 && s[stack.Peek()] == '(')
                    {
                        stack.Pop();
                    }
                }
            }

            for (int i = n-1; i >= 0; i--)
            {
                if (stack.Count > 0 && i != stack.Peek())
                {
                    sb.Append(s[i]);
                }

                if (stack.Count < 0)
                {
                    sb.Append(s[i]);
                }
            }

            char[] result = sb.ToString().ToCharArray();
            Array.Reverse(result);

            return new string(result);
        }
    }
}
