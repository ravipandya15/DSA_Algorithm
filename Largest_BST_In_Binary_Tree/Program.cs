using System;

namespace Largest_BST_In_Binary_Tree
{
    public class NodeValue
    {
        public int minNode, maxNode, maxSize;
        public NodeValue(int minNode, int maxNode, int maxSize)
        {
            this.minNode = minNode;
            this.maxNode = maxNode;
            this.maxSize = maxSize;
        }
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

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Largest_BST_In_Binary_Tree");
        }

        private NodeValue LargestBSTSubTReeHelper(TreeNode root)
        {
            if (root == null) return new NodeValue(Int32.MaxValue, Int32.MinValue, 0);

            NodeValue left = LargestBSTSubTReeHelper(root.left);
            NodeValue right = LargestBSTSubTReeHelper(root.right);

            if (left.maxNode < root.val && root.val < right.minNode)
            {
                // it is a BST
                return new NodeValue(Math.Min(root.val, left.minNode),
                                     Math.Max(root.val, right.maxNode),
                                     left.maxSize + right.maxSize + 1);
            }
            return new NodeValue(Int32.MaxValue, Int32.MinValue, Math.Max(left.maxSize, right.maxSize));
        }

        public int LargestBSTSubTree(TreeNode root)
        {
            return LargestBSTSubTReeHelper(root).maxSize;
        }
    }
}
