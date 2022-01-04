using System;
using System.Collections.Generic;

namespace _106._Construct_Binary_Tree_from_Inorder_and_Postorder_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Construct_Binary_Tree_from_Inorder_and_Postorder_Traversal_106");
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

        private static TreeNode BuildTreePostIn(int[] inorder, int inStart, int inEnd, int[] postorder, int postStart, int postEnd, Dictionary<int, int> map)
        {
            if (inStart > inEnd || postStart > postEnd) return null;

            TreeNode root = new TreeNode(postorder[postEnd]);
            int inRoot = map[root.val];
            int numsLeft = inRoot - inStart;

            root.left = BuildTreePostIn(inorder, inStart, inRoot - 1, postorder, postStart, postStart + numsLeft - 1, map);
            root.right = BuildTreePostIn(inorder, inRoot + 1, inEnd, postorder, postStart + numsLeft, postEnd - 1, map);

            return root;

        }

        public static TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            if (inorder == null || postorder == null || inorder.Length != postorder.Length) return null;
            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < inorder.Length; i++)
            {
                map[inorder[i]] = i;
            }

            return BuildTreePostIn(inorder, 0, inorder.Length - 1, postorder, 0, postorder.Length - 1, map);
        }
    }
}
