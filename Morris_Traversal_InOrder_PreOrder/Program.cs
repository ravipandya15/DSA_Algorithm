using System;
using System.Collections.Generic;

namespace Morris_Traversal_InOrder_PreOrder
{
    class Program
    {
        // Morris_Inorder
        // TC -> O(N), SC -> O(1)
        static void Main(string[] args)
        {
            Console.WriteLine("Morris_Traversal_InOrder_PreOrder");
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

        public static IList<int> Morris_Inorder(TreeNode root)
        {
            // Morris_Inorder
            // TC -> O(N), SC -> O(1)
            IList<int> morris_Inorder = new List<int>();
            TreeNode cur = root;
            while (cur != null)
            {
                if (cur.left == null)
                {
                    morris_Inorder.Add(cur.val);
                    cur = cur.right;
                }
                else
                {
                    // go to right most down most node of left subtree
                    TreeNode prev = cur.left;
                    while (prev.right != null && prev.right != cur)
                    {
                        prev = prev.right;
                    }

                    if (prev.right == null)
                    {
                        // make pointer pointer
                        prev.right = cur;
                        cur = cur.left;
                    }
                    else
                    {
                        // means prev.right == cur
                        prev.right = null;
                        morris_Inorder.Add(cur.val);
                        cur = cur.right;
                    }
                }
            }
            return morris_Inorder;
        }

        public static IList<int> Morris_Preorder(TreeNode root)
        {
            // Morris_Preorder
            // TC -> O(N), SC -> O(1)
            IList<int> morris_Preorder = new List<int>();
            TreeNode cur = root;
            while (cur != null)
            {
                if (cur.left == null)
                {
                    morris_Preorder.Add(cur.val);
                    cur = cur.right;
                }
                else
                {
                    // go to right most down most node of left subtree
                    TreeNode prev = cur.left;
                    while (prev.right != null && prev.right != cur)
                    {
                        prev = prev.right;
                    }

                    if (prev.right == null)
                    {
                        // make pointer pointer
                        prev.right = cur;
                        morris_Preorder.Add(cur.val);
                        cur = cur.left;
                    }
                    else
                    {
                        // means prev.right == cur
                        prev.right = null;
                        cur = cur.right;
                    }
                }
            }
            return morris_Preorder;
        }
    }
}
