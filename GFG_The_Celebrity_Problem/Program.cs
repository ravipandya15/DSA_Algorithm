using System;
using System.Collections.Generic;

namespace GFG_The_Celebrity_Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GFG_The_Celebrity_Problem");
        }

        private static bool knows(int a, int b, int[,] M, int n)
        {
            if (M[a, b] == 1) return true;
            return false;
        }

        // TC -> O(N)
        // SC -> O(N)
        public int celebrity(int[,] M, int n)
        {
            // step 1 -> push all indexes in Stack
            Stack<int> st = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                st.Push(i);
            }

            // step 2
            while (st.Count > 1)
            {
                int a = st.Peek();
                st.Pop();

                int b = st.Peek();
                st.Pop();

                if (knows(a, b, M, n))
                {
                    // ingore a and push b
                    st.Push(b);
                }
                else
                {
                    st.Push(a);
                }
            }

            // now only 1 element is there in stack whih might be Potential solution
            // verify
            int ans = st.Peek();
            int rowCount = 0;
            for (int i = 0; i < n; i++)
            {
                if (M[ans, i] == 0) rowCount++;
            }

            if (rowCount != n) return -1;

            int colCount = 0;
            for (int i = 0; i < n; i++)
            {
                if (M[i, ans] == 1) colCount++;
            }

            if (colCount != n - 1) return -1;
            return ans;
        }
    }
}
