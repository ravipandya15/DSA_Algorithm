using System;

namespace _235._Lowest_Common_Ancestor_of_a_Binary_Search_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null) return null;
            if (p.val > root.val && q.val > root.val) return LowestCommonAncestor(root.right, p, q);
            else if (p.val < root.val && q.val < root.val) return LowestCommonAncestor(root.left, p, q);
            return root;
        }

        public TreeNode LowestCommonAncestor_Iterative(TreeNode root, TreeNode p, TreeNode q)
        {
            //Iterative
            while (root != null)
            {
                if (p.val > root.val && q.val > root.val)
                {
                    root = root.right;
                }
                else if (p.val < root.val && q.val < root.val)
                {
                    root = root.left;
                }
                else
                {
                    return root;
                }
            }
            return root;
        }
    }
}
