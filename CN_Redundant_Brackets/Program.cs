using System;
using System.Collections.Generic;

namespace CN_Redundant_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Redundant_Brackets");
        }

        public static bool findRedundantBrackets(string s)
        {
            Stack<char> st = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                char ch = s[i];
                if (ch == '(' || ch == '+' || ch == '-' || ch == '*' || ch == '/')
                    st.Push(ch);
                else
                {
                    // it's ')' or lower case letter
                    if (ch == ')')
                    {
                        bool isRedundant = true;
                        while (st.Peek() != '(') // as it's a valid mathematical expressions we definately find '(' bracket
                        {
                            char top = st.Peek();
                            if (top == '+' || top == '-' || top == '*' || top == '/')
                            {
                                isRedundant = false;
                            }
                            st.Pop();
                        }

                        if (isRedundant) return true;
                        st.Pop(); //-> to remove '('
                    }
                }
            }
            return false;
        }
    }
}
