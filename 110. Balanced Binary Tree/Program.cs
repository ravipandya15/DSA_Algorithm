using System;

namespace _110._Balanced_Binary_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Balanced_Binary_Tree_110");
            Console.ReadLine();
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

        public bool IsBalanced(TreeNode root)
        {
            return dfsHeight(root) != -1;
        }

        public static int dfsHeight(TreeNode root)
        {
            if (root == null) return 0;

            int leftHeight = dfsHeight(root.left);
            if (leftHeight == -1) return -1;
            int rightHeight = dfsHeight(root.right);
            if (rightHeight == -1) return -1;

            if (Math.Abs(leftHeight - rightHeight) > 1) return -1;

            return 1 + Math.Max(leftHeight, rightHeight);
        }

    }
}
