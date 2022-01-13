using System;

namespace _1008._Construct_Binary_Search_Tree_from_Preorder_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1008. Construct Binary Search Tree from Preorder Traversal");
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        // bound is upper bound, value should not be greater than or equal to bound
        private static TreeNode buildBST(int[] preOrder, int bound, ref int i)
        {
            if (i == preOrder.Length || preOrder[i] > bound) return null;
            TreeNode root = new TreeNode(preOrder[i++]);
            root.left = buildBST(preOrder, root.val, ref i);
            root.right = buildBST(preOrder, bound, ref i);
            return root;
        }

        public TreeNode BstFromPreorder(int[] preorder)
        {
            int i = 0;
            return buildBST(preorder, Int32.MaxValue, ref i);
        }
    }
}
