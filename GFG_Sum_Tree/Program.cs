using System;

namespace GFG_Sum_Tree
{
    public class Node
    {
        public int data;
        public Node left, right;

        public Node(int item)
        {
            data = item;
            left = right = null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GFG_Sum_Tree");
        }

        public static int solve(Node root)
        {
            if (root == null) return 0;
            if (root.left == null && root.right == null) return root.data;

            int left = solve(root.left);
            if (left == -1) return -1;
            int right = solve(root.right);
            if (right == -1) return -1;

            if (root.data != (left + right)) return -1;

            return root.data + left + right;
        }

        bool isSumTree(Node root)
        {
            return solve(root) != -1;
        }
    }
}
