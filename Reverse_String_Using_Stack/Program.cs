using System;
using System.Text;
using System.Collections.Generic;

namespace Reverse_String_Using_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Reverse_String_Using_Stack");
            string result = ReverseString("Ravi");
        }

        public static string ReverseString(string str)
        {
            Stack<char> st = new Stack<char>();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                st.Push(str[i]);
            }

            while (st.Count > 0)
            {
                sb.Append(st.Peek());
                st.Pop();
            }

            return sb.ToString();
        }
    }
}
