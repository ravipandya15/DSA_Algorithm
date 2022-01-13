using System;

namespace _98._Validate_Binary_Search_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("98. Validate Binary Search Tree");
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

        private static bool isValidBST(TreeNode root, long minVal, long maxVal)
        {
            if (root == null) return true;

            if (root.val >= maxVal || root.val <= minVal) return false;

            return isValidBST(root.left, minVal, root.val)
                && isValidBST(root.right, root.val, maxVal);
        }

        public bool IsValidBST(TreeNode root)
        {
            return isValidBST(root, long.MinValue, long.MaxValue);
        }
    }
}
