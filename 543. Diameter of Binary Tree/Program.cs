using System;

namespace _543._Diameter_of_Binary_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Diameter_of_Binary_Tree");
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

        private static int Height(TreeNode root, ref int diameter)
        {
            if (root == null) return 0;

            int lh = Height(root.left, ref diameter);
            int rh = Height(root.right, ref diameter);

            diameter = Math.Max(diameter, lh + rh);

            return 1 + Math.Max(lh, rh);
        }

        public static int DiameterOfBinaryTree(TreeNode root)
        {
            int diameter = 0;
            Height(root, ref diameter);
            return diameter;
        }
    }
}
