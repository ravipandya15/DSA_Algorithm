using System;
using System.Collections.Generic;

namespace _230._Kth_Smallest_Element_in_a_BST
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("230. Kth Smallest Element in a BST");
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

        

        //Morris Traversal
        public int Morris_KthSmallest1(TreeNode root, int k)
        {
            //Morris Traversal
            TreeNode cur = root;
            int count = 0;
            while (cur != null)
            {
                if (cur.left == null)
                {
                    count++;
                    if (count == k) return cur.val;
                    cur = cur.right;
                }
                else
                {
                    TreeNode prev = cur.left;
                    while (prev.right != null && prev.right != cur)
                    {
                        prev = prev.right;
                    }
                    if (prev.right == null)
                    {
                        prev.right = cur;
                        cur = cur.left;
                    }
                    else
                    {
                        prev.right = null;
                        count++;
                        if (count == k) return cur.val;
                        cur = cur.right;
                    }
                }
            }
            return -1;
        }

        private static void inOrder(TreeNode root, int k, int count, IList<int> ans)
        {
            if (root == null) return;

            inOrder(root.left, k, count, ans);
            ans.Add(root.val);
            inOrder(root.right, k, count, ans);
        }

        //Recursion
        public int KthSmallest1(TreeNode root, int k)
        {
            IList<int> ans = new List<int>();
            inOrder(root, k, 0, ans);
            return ans[k-1];
        }

        //Iterative
        public int KthSmallest2(TreeNode root, int k)
        {
            Stack<TreeNode> st = new Stack<TreeNode>();
            st.Push(root);
            TreeNode node = root;
            int count = 0;
            while (true)
            {
                if (node != null)
                {
                    st.Push(node);
                    node = node.left;
                }
                else
                {
                    if (st.Count == 0) break;
                    node = st.Peek();
                    st.Pop();

                    count++;
                    if (count == k) return node.val;

                    node = node.right;
                }
            }
            return -1;
        }
    }
}
