using System;

namespace GFG_Sum_of_the_Longest_Bloodline_of_a_Tree
{
    public class Node
    {
        public int data;
        public Node left, right;

        public Node(int data)
        {
            this.data = data;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GFG_Sum_of_the_Longest_Bloodline_of_a_Tree");
        }

        // can use ref keyword instead of array.
        //[] is there as copy code from java

        public static void solve(Node root, int len, int[] maxLen, int sum, int[] maxSum)
        {
            // base case
            if (root == null)
            {
                if (len > maxLen[0])
                {
                    maxLen[0] = len;
                    maxSum[0] = sum;
                }
                else if (len == maxLen[0])
                {
                    maxSum[0] = Math.Max(sum, maxSum[0]);
                }
                return;
            }

            sum = sum + root.data;

            solve(root.left, len + 1, maxLen, sum, maxSum);
            solve(root.right, len + 1, maxLen, sum, maxSum);
        }

        public int sumOfLongRootToLeafPath(Node root)
        {
            int len = 0, sum = 0;
            int[] maxLen = { 0 };
            int[] maxSum = { 0 };

            solve(root, len, maxLen, sum, maxSum);
            return maxSum[0];
        }
    }
}
