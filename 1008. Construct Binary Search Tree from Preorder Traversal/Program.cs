using System;
using System.Collections.Generic;

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

        public class BinaryTreeNode<T>
        {
            public T data;
            public BinaryTreeNode<T> left;
            public BinaryTreeNode<T> right;

            public BinaryTreeNode(T data)
            {
                this.data = data;
                left = null;
                right = null;
            }
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


        // CN Code
        private static BinaryTreeNode<int> buildBST_2(List<int> preOrder, int lowerBound, int upperBound, ref int i)
        {
            if (i >= preOrder.Count || preOrder[i] < lowerBound || preOrder[i] > upperBound)
            {
                return null;
            }
            BinaryTreeNode<int> root = new BinaryTreeNode<int>(preOrder[i++]);
            root.left = buildBST_2(preOrder, lowerBound, root.data, ref i);
            root.right = buildBST_2(preOrder, root.data, upperBound, ref i);
            return root;
        }

        // Coding Ninja's Solution
        // can also be done using Lower bound and Upper bound
        public static BinaryTreeNode<int> prorderToBST(List<int> preorder)
        {
            return buildBST_2(preorder, Int32.MinValue, Int32.MaxValue, 0);
        }
    }
}
