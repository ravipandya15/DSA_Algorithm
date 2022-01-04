using System;

namespace _104._Maximum_Depth_of_Binary_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("104. Maximum Depth of Binary Tree");
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

        // TC -> O(N)
        // SC -> O(N)
        public static int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;

            int leftHeight = MaxDepth(root.left);
            int rightHeight = MaxDepth(root.right);

            return 1 + Math.Max(leftHeight, rightHeight);
        }
    }
}
