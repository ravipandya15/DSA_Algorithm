using System;
using System.Collections.Generic;

namespace _987._Vertical_Order_Traversal_of_a_Binary_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("987._Vertical_Order_Traversal_of_a_Binary_Tree");
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

        public static IList<IList<int>> VerticalTraversal(TreeNode root)
        {
            IList<IList<int>> res = new List<IList<int>>();
            // check Java Code
            return res;
        }
    }
}
