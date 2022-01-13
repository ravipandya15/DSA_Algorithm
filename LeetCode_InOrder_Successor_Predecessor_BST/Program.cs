using System;

namespace LeetCode_InOrder_Successor_Predecessor_BST
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("InOrder_Successor_Predecessor_BST");
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public static TreeNode inOrder_Successor(TreeNode root, TreeNode p)
        {
            TreeNode successor = null;
            while(root != null)
            {
                if (root.val > p.val)
                {
                    successor = root;
                    root = root.left;
                }
                else
                {
                    root = root.right;
                }
            }
            return successor;
        }

        public static TreeNode inOrder_Predecessor(TreeNode root, TreeNode p)
        {
            TreeNode successor = null;
            while (root != null)
            {
                if (root.val >= p.val) root = root.left;
                else
                {
                    successor = root;
                    root = root.right;
                }
            }
            return successor;
        }
    }
}
