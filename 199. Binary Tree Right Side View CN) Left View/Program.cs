using System;
using System.Collections.Generic;

namespace _199._Binary_Tree_Right_Side_View_CN__Left_View
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("199._Binary_Tree_Right_Side_View_CN__Left_View");
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

        // right view
        private static void Recursion(TreeNode node, int level, IList<int> res)
        {
            if (node == null) return;

            if (level == res.Count) res.Add(node.val);

            Recursion(node.right, level + 1, res);
            Recursion(node.left, level + 1, res);
        }

        // left view
        private static void Recursion1(TreeNode node, int level, IList<int> res)
        {
            if (node == null) return;

            if (level == res.Count) res.Add(node.val);

            Recursion(node.left, level + 1, res);
            Recursion(node.right, level + 1, res);
        }

        public static IList<int> RightSideView(TreeNode root)
        {
            IList<int> res = new List<int>();
            Recursion(root, 0, res);
            // for left view 
            Recursion1(root, 0, res);
            return res;
        }
    }
}
