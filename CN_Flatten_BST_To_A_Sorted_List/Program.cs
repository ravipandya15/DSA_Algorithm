using System;
using System.Collections.Generic;

namespace CN_Flatten_BST_To_A_Sorted_List
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Flatten_BST_To_A_Sorted_List");
        }

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

        public static void InOrderTraversal(TreeNode<int> root, List<int> inOrder)
        {
            if (root == null)
            {
                return;
            }

            InOrderTraversal(root.left, inOrder);
            inOrder.Add(root.data);
            InOrderTraversal(root.right, inOrder);
        }

        public static TreeNode<int> flatten(TreeNode<int> root)
        {
            // min. ek node to hase j
            // as N >= 1
            List<int> inOrder = new List<int>();
            InOrderTraversal(root, inOrder);

            TreeNode<int> newNode = new TreeNode<int>(inOrder[0]);
            TreeNode<int> cur = newNode;

            for (int i = 1; i < inOrder.Count; i++)
            {
                TreeNode<int> temp = new TreeNode<int>(inOrder[i]);
                cur.left = null;
                cur.right = temp;
                cur = temp;
            }

            // for last node
            cur.left = null;
            cur.right = null;
            return newNode;
        }
    }
}
