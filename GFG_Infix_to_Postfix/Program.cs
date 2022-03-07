using System;
using System.Collections.Generic;
using System.Text;

namespace GFG_Infix_to_Postfix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GFG_Infix_to_Postfix");
        }

        // Asked in PayPal
        // Code still remining

        public static string infixToPostfix(string exp)
        {
            Dictionary<char, int> priority = new Dictionary<char, int>();
            priority.Add('^', 0);
            priority.Add('/', 1);
            priority.Add('*', 1);
            priority.Add('+', 2);
            priority.Add('-', 2);

            Dictionary<char, int> associativity = new Dictionary<char, int>();
            // 1 means Left to right and -1 means right to left
            associativity.Add('^', -1);
            associativity.Add('*', 1);
            associativity.Add('/', 1);
            associativity.Add('+', 1);
            associativity.Add('-', 1);

            StringBuilder str = new StringBuilder();
            Stack<char> st = new Stack<char>();
            for (int i = 0; i < exp.Length; i++)
            {
                // character is operand
                if (exp[i] - 'a' >= 0 && exp[i] - 'a' < 26)
                {
                    str.Append(exp[i]);
                }
                else if (exp[i] == '(')
                {
                    st.Push(exp[i]);
                }
                else if (exp[i] == ')')
                {
                    while (st.Count > 0 && st.Peek() != '(')
                    {
                        str.Append(st.Peek());
                        st.Pop();
                    }
                    str.Append(st.Peek());
                    st.Pop();
                }
                else
                {// it's operator
                    //if (priority[exp[i]] > priority[st.])
                }
            }

            return string.Empty;
        }

    }
}