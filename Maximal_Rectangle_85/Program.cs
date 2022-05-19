using System;
using System.Collections.Generic;

namespace Maximal_Rectangle_85
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Maximal_Rectangle_85");
            char[][] matrix = new char[4][]
            {
                new char[]{'1','0','1','0','0'},
                new char[]{ '1','0','1','1','1'},
                new char[]{'1','1','1','1','1'},
                new char[]{'1','0','0','1','0'}
            };

            int maxArea = MaximalRectangle(matrix);
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

        public static int MaximalRectangle(char[][] matrix)
        {
            int maxAns = 0;
            int n = matrix.Length;
            int m = matrix[0].Length;
            int[] height = new int[m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i][j] == '1') height[j]++;
                    else height[j] = 0;
                }
                int area = largestRectangleArea(height);
                maxAns = Math.Max(maxAns, area);
            }
            return maxAns;
        }
    }
}
