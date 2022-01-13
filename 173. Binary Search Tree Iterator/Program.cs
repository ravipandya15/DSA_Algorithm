using System;
using System.Collections.Generic;

namespace _173._Binary_Search_Tree_Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("173. Binary Search Tree Iterator");
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

        public class BSTIterator
        {
            private Stack<TreeNode> stack = new Stack<TreeNode>();
            public BSTIterator(TreeNode root)
            {
                PushAll(root);
            }

            public int Next()
            {
                TreeNode node = stack.Peek();
                stack.Pop();
                PushAll(node.right);
                return node.val;
            }

            public bool HasNext()
            {
                return (stack.Count > 0);
            }

            private void PushAll(TreeNode node)
            {
                for (; node != null; stack.Push(node), node = node.left);
                // in while loop
                //while (node != null)
                //{
                //    stack.Push(node);
                //    node = node.left;
                //}
            }
        }
    }
}
