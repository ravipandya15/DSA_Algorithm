using System;

namespace _101._Symmetric_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Symmetric_Tree");
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

        private static bool isSymmetrichelp(TreeNode left, TreeNode right)
        {
            if (left == null || right == null) return (left == right);

            if (left.val != right.val) return false;

            return isSymmetrichelp(left.left, right.right) && isSymmetrichelp(left.right, right.left);
        }

        public static bool IsSymmetric(TreeNode root)
        {
            return (root == null) || isSymmetrichelp(root.left, root.right);
        }
    }
}
