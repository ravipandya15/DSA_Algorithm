using System;
using System.Collections.Generic;

namespace CN_Next_Smaller_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Next_Smaller_Element");
        }

        static List<int> nextSmallerElement(List<int> arr, int n)
        {
            Stack<int> st = new Stack<int>();
            st.Push(-1);
            List<int> ans = new List<int>();

            for (int i = n - 1; i >= 0; i--)
            {
                int cur = arr[i];
                while (st.Peek() >= cur)
                {
                    st.Pop();
                }
                //ans.add(i, st.peek());
                //ans.set(i, st.peek());
                ans.Add(st.Peek());
                st.Push(cur);
            }
            ans.Reverse();
            return ans;
        }
    }
}
