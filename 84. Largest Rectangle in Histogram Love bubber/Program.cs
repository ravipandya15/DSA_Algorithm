using System;
using System.Collections.Generic;

namespace _84._Largest_Rectangle_in_Histogram_Love_bubber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("84. Largest Rectangle in Histogram");
        }

        public static int[] findNextSmallerElement(int[] heights, int n)
        {
            Stack<int> st = new Stack<int>();
            st.Push(-1);
            int[] ans = new int[n];

            for (int i = n - 1; i >= 0; i--)
            {
                int cur = heights[i];
                while (st.Peek() != -1 && heights[st.Peek()] >= cur)
                {
                    st.Pop();
                }
                ans[i] = st.Peek();
                st.Push(i);
            }
            return ans;
        }

        public static int[] findPreviousSmallerElement(int[] heights, int n)
        {
            Stack<int> st = new Stack<int>();
            st.Push(-1);
            int[] ans = new int[n];

            for (int i = 0; i < n; i++)
            {
                int cur = heights[i];
                while (st.Peek() != -1 && heights[st.Peek()] >= cur)
                {
                    st.Pop();
                }
                ans[i] = st.Peek();
                st.Push(i);
            }
            return ans;
        }

        public static int largestRectangleArea(int[] heights)
        {
            int n = heights.Length;
            int[] next = findNextSmallerElement(heights, n);
            int[] prev = findPreviousSmallerElement(heights, n);

            int area = Int32.MinValue;
            for (int i = 0; i < n; i++)
            {
                int l = heights[i];
                if (next[i] == -1)
                {
                    next[i] = n;
                }
                int b = next[i] - prev[i] - 1;
                area = Math.Max(area, (l * b));
            }
            return area;
        }
    }
}
