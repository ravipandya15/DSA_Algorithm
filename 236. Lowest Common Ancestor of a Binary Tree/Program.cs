using System;

namespace _236._Lowest_Common_Ancestor_of_a_Binary_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("236. Lowest Common Ancestor of a Binary Tree");
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || root == p || root == q) return root;

            TreeNode left = LowestCommonAncestor(root.left, p, q);
            TreeNode right = LowestCommonAncestor(root.right, p, q);

            // this will also work
            //if (left != null && right != null) return root;
            //else if (left != null) return left;
            //else return right;

            if (left == null) return right;
            else if (right == null) return left;
            else
            { // both left and right are not null, we found our ans
                return root;
            }
        }
    }
}
