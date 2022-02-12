using System;
using System.Collections.Generic;

namespace GFG_Max_rectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GFG_Max_rectangle");
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

        // TC -> O(n * m)
        // SC -> O(m)
        public int maxArea(int[][] M, int n, int m)
        {
            // step 1 -> compute max area for 1st row
            int area = largestRectangleArea(M[0]);

            // step 2 -> compute max area for remaining row
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (M[i][j] != 0)
                    {
                        M[i][j] += M[i - 1][j];
                    }
                    else
                    {
                        M[i][j] = 0;
                    }
                }

                area = Math.Max(area, largestRectangleArea(M[i]));
            }

            return area;
        }
    }
}
