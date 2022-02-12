using System;
using System.Collections.Generic;

namespace CN_Minimum_Cost_To_Make_String_Valid
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Minimum_Cost_To_Make_String_Valid");
        }

        // TC -> O(N)
        // SC -> O(N)
        public static int findMinimumCost(string str)
        {
            // odd length
            if (str.Length % 2 == 1) return -1;

            // if any valid paranthesis found remove it
            Stack<char> st = new Stack<char>();
            for (int i = 0; i < str.Length; i++)
            {
                char ch = str[i];
                if (ch == '{')
                {
                    st.Push(ch);
                }
                else
                {// closing bracket
                    if (st.Count > 0 && st.Peek() == '{')
                    {
                        st.Pop();
                    }
                    else
                    {
                        st.Push(ch);
                    }
                }
            }

            // stack contains invalid chars
            int a = 0, b = 0;
            while (st.Count > 0)
            {
                if (st.Peek() == '{') b++;
                else if (st.Peek() == '}') a++;
                st.Pop();
            }

            int ans = (a + 1) / 2 + (b + 1) / 2;
            return ans;
        }
    }
}
