using System;
using System.Collections.Generic;

namespace _84._Largest_Rectangle_in_Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("84. Largest Rectangle in Histogram");
            int[] arr = new int[] { 2, 1, 5, 6, 2, 3, 1 };
            Console.WriteLine($"Largest Rectangle Area is {LargestRectangleArea(arr)}");
            Console.ReadLine();
        }

        // Optimal don't say this solution in interview as it is very hard to convey
        public static int LargestRectangleArea1(int[] heights)
        {
            Stack<int> stack = new Stack<int>();
            int n = heights.Length;
            int max = 0;
            for (int i = 0; i <= n; i++)
            {
                while (stack.Count > 0 && (i == n || heights[stack.Peek()] >= heights[i]))
                {
                    int height = heights[stack.Peek()];
                    stack.Pop();
                    int width;
                    if (stack.Count == 0) width = i;
                    else width = i - stack.Peek() - 1;
                    max = Math.Max(max, height * width);
                }
                stack.Push(i);
            }
            return max;
        }

        // TC -> O(N)
        // SC -> O(N)
        public static int LargestRectangleArea(int[] heights)
        {
            Stack<int> stack = new Stack<int>();
            int n = heights.Length;
            int[] leftSmall = new int[n];
            int[] rightSmall = new int[n];

            // left small
            for (int i = 0; i < n; i++)
            {
                while (stack.Count > 0 && heights[stack.Peek()] >= heights[i])
                    stack.Pop();

                if (stack.Count == 0) leftSmall[i] = 0;
                else leftSmall[i] = stack.Peek() + 1;

                stack.Push(i);
            }

            // clear stack as it will be re - used for right small
            while (stack.Count > 0) stack.Pop();

            // right small
            for (int i = n - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && heights[stack.Peek()] >= heights[i])
                    stack.Pop();

                if (stack.Count == 0) rightSmall[i] = n - 1;
                else rightSmall[i] = stack.Peek() - 1;

                stack.Push(i);
            }

            // compute max area
            int max = 0;
            for (int i = 0; i < n; i++)
            {
                max = Math.Max(max, (rightSmall[i] - leftSmall[i] + 1) * heights[i]);
            }

            return max;
        }
    }
}
