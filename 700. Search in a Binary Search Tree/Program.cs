using System;

namespace _700._Search_in_a_Binary_Search_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("700. Search in a Binary Search Tree");
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

        public static TreeNode SearchBST(TreeNode root, int val)
        {
            while (root != null && root.val != val)
            {
                root = val < root.val ? root.left : root.right;
            }
            return root;
        }
    }
}
