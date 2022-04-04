using System;
using System.Collections.Generic;

namespace _653._Two_Sum_IV___Input_is_a_BST
{
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


    //in JAVA filename is BSTIterator.java



    public class BSTIterator
    {
        private Stack<TreeNode> stack = new Stack<TreeNode>();
        bool reverse = true;
        public BSTIterator(TreeNode root, bool isReverse)
        {
            // this flag must be set to isReverse before PushAll() function ->
            // otherwise PushAll function will perform for reverse = true
            reverse = isReverse;
            PushAll(root);
        }

        public int Next()
        {
            TreeNode node = stack.Peek();
            stack.Pop();
            if (reverse) PushAll(node.left);
            else PushAll(node.right);
            return node.val;
        }

        public bool HasNext()
        {
            return (stack.Count > 0);
        }

        private void PushAll(TreeNode node)
        {
            while (node != null)
            {
                stack.Push(node);
                if (reverse) node = node.right;
                else node = node.left;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public bool FindTarget(TreeNode root, int k)
        {
            if (root == null) return false;
            BSTIterator l = new BSTIterator(root, false);
            BSTIterator r = new BSTIterator(root, true);

            int i = l.Next();
            int j = r.Next();  // this is r.before() find of thing
            while (i < j)
            {
                if ((i + j) == k) return true;
                else if ((i + j) < k) i = l.Next();
                else j = r.Next();
            }
            return false;
        }

        //CN
        //public static bool twoSumInBST(BinaryTreeNode<Integer> root, int target)
        //{
        //    // Write your code here!
        //    //Code is in 

        //}
    }
}
