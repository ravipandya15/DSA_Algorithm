using System;

namespace _99._Recover_Binary_Search_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("99. Recover Binary Search Tree");
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        private TreeNode first, middle, last, prev;

        private void InOrder(TreeNode root)
        {
            if (root == null) return;

            InOrder(root.left);

            if (prev != null && root.val < prev.val)
            {
                // if this is first violation mark these two nodes as first and middle
                if (first == null)
                {
                    first = prev;
                    middle = root;
                }
                else
                {// if this is second violation mark this as last.
                    last = root;
                }
            }

            prev = root;
            InOrder(root.right);
        }

        public void RecoverTree(TreeNode root)
        {
            first = middle = last = null;
            prev = new TreeNode(Int32.MinValue);

            InOrder(root);
            if (first != null && last != null)
            {
                // swap first and last value
                int temp = first.val;
                first.val = last.val;
                last.val = temp;
            }
            else if (first != null && middle != null)
            {
                // swap first and middle value
                int temp = first.val;
                first.val = middle.val;
                middle.val = temp;
            }
        }
    }
}
