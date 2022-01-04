using System;
using System.Collections.Generic;

namespace _105._Construct_Binary_Tree_from_Preorder_and_Inorder_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Construct_Binary_Tree_from_Preorder_and_Inorder_Traversal_105.java");
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

        private static TreeNode BuildTree(int[] preorder, int preStart, int preEnd,
                                int[] inorder, int inStart, int inEnd,
                                Dictionary<int, int> inMap)
        {
            if (preStart > preEnd || inStart > inEnd) return null;

            TreeNode root = new TreeNode(preorder[preStart]);

            int inRoot = inMap[root.val];
            int numsLeft = inRoot - inStart;

            root.left = BuildTree(preorder, preStart + 1, preStart + numsLeft, inorder, inStart, inRoot - 1, inMap);
            root.right = BuildTree(preorder, preStart + numsLeft + 1, preEnd, inorder, inRoot + 1, inEnd, inMap);

            return root;
        }

        public static TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            Dictionary<int, int> inMap = new Dictionary<int, int>();

            for (int i = 0; i < inorder.Length; i++)
            {
                inMap[inorder[i]] = i;
            }

            TreeNode root = BuildTree(preorder, 0, preorder.Length - 1, inorder, 0, inorder.Length - 1, inMap);
            return root;
        }
    }
}
