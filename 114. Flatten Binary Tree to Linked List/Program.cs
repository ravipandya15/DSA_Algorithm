using System;
using System.Collections.Generic;

namespace _114._Flatten_Binary_Tree_to_Linked_List
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Flatten_Binary_Tree_to_Linked_List_114");

            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.left.left = new TreeNode(3);
            root.left.right = new TreeNode(4);

            root.right = new TreeNode(5);
            root.right.right = new TreeNode(6);
            root.right.right.left = new TreeNode(7);

            Flatten2(root);
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

        // Approach - 1
        // Recursive
        // TC -> O(N), SC -> O(N)
        TreeNode prev = null;
        public void Flatten1(TreeNode root)
        {
            // Approach - 1
            // Recursive
            // TC -> O(N), SC -> O(N)
            if (root == null) return;

            Flatten1(root.right);
            Flatten1(root.left);

            root.right = prev;
            root.left = null;
            prev = root;
        }

        // Approach -2 
        // Iterative
        // TC -> O(N), SC -> O(N)
        public static void Flatten2(TreeNode root)
        {
            // Approach -2 
            // Iterative
            // TC -> O(N), SC -> O(N)
            if (root == null) return;
            Stack<TreeNode> st = new Stack<TreeNode>();
            st.Push(root);

            while (st.Count > 0)
            {
                TreeNode cur = st.Peek();
                st.Pop();

                if (cur.right != null) st.Push(cur.right);
                if (cur.left != null) st.Push(cur.left);

                if (st.Count > 0) cur.right = st.Peek();
                cur.left = null;
            }
        }

        // Approach - 3 
        // Morris Traversal
        // TC -> O(N), SC -> O(1)
        public void Flatten3_Morris_Traversal(TreeNode root)
        {
            // Approach - 3 
            // Morris Traversal
            // TC -> O(N), SC -> O(1)
            while (root != null)
            {
                if (root.left != null)
                {
                    TreeNode prev = root.left;
                    while (prev.right != null) prev = prev.right;

                    prev.right = root.right;
                    root.right = root.left;
                    root.left = null;
                }
                root = root.right;
            }
        }

    }
}
