using System;

namespace GFG_Kth_Ancestor_in_a_Tree
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
            Console.WriteLine("GFG_Kth_Ancestor_in_a_Tree");
        }

        public static Node solve(Node root, ref int k, int node)
        {
            // base case
            if (root == null) return null;

            if (root.data == node)
            {
                return root;
            }

            Node left = solve(root.left, ref k, node);
            Node right = solve(root.right, ref k, node);

            if (left != null && right == null)
            {
                k--;
                if (k <= 0)
                {
                    // to lock the answer -> edge case
                    k = Int32.MaxValue;
                    return root;
                }
                return left;
            }

            if (left == null && right != null)
            {
                k--;
                if (k <= 0)
                {
                    // to lock the answer -> edge case
                    k = Int32.MaxValue;
                    return root;
                }
                return right;
            }
            else
            {
                // both null .   -> both non - null case never comes
                return null;
            }
        }

        public int kthAncestor(Node root, int k, int node)
        {
            Node ans = solve(root, ref k, node);
            if (ans == null || ans.data == node)  //ans.data == node -> edge case
            {
                return -1;
            }
            return ans.data;
        }
    }
}
