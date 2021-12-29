using System;
using System.Collections.Generic;

namespace Iterator_Version_PreOrder_PostOrder_InOrder
{
    class Program
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
        static void Main(string[] args)
        {
            Console.WriteLine("Iterative Version");
            Console.ReadLine();
        }

        // TC -> O(N)
        // SC -> O(N) 
        public static IList<int> inorderTraversal(TreeNode root)
        {
            IList<int> result = new List<int>();
            if (root == null) return result;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                TreeNode node = stack.Peek();
                stack.Pop();
                result.Add(node.val);

                if (node.right != null)
                {
                    stack.Push(node.right);
                }
                if (node.left != null)
                {
                    stack.Push(node.left);
                }
            }
            return result;
        }

        // TC -> O(N)
        // SC -> O(N) 
        public static IList<int> InorderTraversal(TreeNode root)
        {
            IList<int> inOrder = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode node = root;

            while (true)
            {
                if (node != null)
                {
                    stack.Push(node);
                    node = node.left;
                }
                else
                {
                    if (stack.Count == 0) break;
                    node = stack.Peek();
                    stack.Pop();
                    inOrder.Add(node.val);
                    node = node.right;
                }
            }
            return inOrder;
        }

        //using 2 Stack
        public static IList<int> PostorderTraversal_1(TreeNode root)
        {
            IList<int> postOrder = new List<int>();
            if (root == null) return postOrder;
            Stack<TreeNode> st1 = new Stack<TreeNode>();
            Stack<TreeNode> st2 = new Stack<TreeNode>();
            st1.Push(root);

            while (st1.Count > 0)
            {
                root = st1.Peek();
                st1.Pop();
                st2.Push(root);

                if (root.left != null) st1.Push(root.left);
                if (root.right != null) st1.Push(root.right);
            }

            while (st2.Count > 0)
            {
                postOrder.Add(st2.Peek().val);
                st2.Pop();
            }

            return postOrder;
        }

        // TLE mare chhe -> Check SDE Cheet or Free ka Tree Series Code
        //using 1 Stack
        public static IList<int> PostorderTraversal_2(TreeNode root)
        {
            //iterative approach
            IList<int> postOrder = new List<int>();
            if (root == null) return postOrder;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode cur = root;
            while (cur != null || stack.Count > 0)
            {
                if (cur != null)
                {
                    stack.Push(cur);
                    cur = cur.left;
                }
                else
                {
                    TreeNode temp = stack.Peek().right;
                    if (temp == null)
                    {
                        temp = stack.Peek();
                        stack.Pop();
                        postOrder.Add(temp.val);
                        if (stack.Count > 0 && temp == stack.Peek().right)
                        {
                            temp = stack.Peek();
                            stack.Pop();
                            postOrder.Add(temp.val);
                        }
                    }
                    else
                    {
                        cur = temp;
                    }
                }
            }
            return postOrder;
        }

    }
}
