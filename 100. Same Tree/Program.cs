using System;

namespace _100._Same_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("100. Same Tree");
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

        public static bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null || q == null) return (p == q);
            return (p.val == q.val) && IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }
    }
}
