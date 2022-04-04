using System;
using System.Collections.Generic;

namespace CN_Normal_BST_To_Balanced_BST
{
    class Program
    {
        public class TreeNode<T>
        {
            public T data;
            public TreeNode<T> left;
            public TreeNode<T> right;

            public TreeNode(T data)
            {
                this.data = data;
                left = null;
                right = null;
            }
        };

        static void Main(string[] args)
        {
            Console.WriteLine("CN_Normal_BST_To_Balanced_BST");
        }

        private static void InOrderTraversal(TreeNode<int> root, List<int> inOrder)
        {
            if (root == null)
            {
                return;
            }

            InOrderTraversal(root.left, inOrder);
            inOrder.Add(root.data);
            InOrderTraversal(root.right, inOrder);
        }

        private static TreeNode<int> inorderToBST(int s, int e, List<int> inOrder)
        {
            if (s > e)
            {
                return null;
            }

            int mid = (s + e) / 2;
            TreeNode<int> root = new TreeNode<int>(inOrder[mid]);
            root.left = inorderToBST(s, mid - 1, inOrder);
            root.right = inorderToBST(mid + 1, e, inOrder);

            return root;
        }

        public static TreeNode<int> balancedBst(TreeNode<int> root)
        {
            List<int> inOrder = new List<int>();
            InOrderTraversal(root, inOrder);

            return inorderToBST(0, inOrder.Count - 1, inOrder);
        }
    }
}
