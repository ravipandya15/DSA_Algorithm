using System;
using System.Collections.Generic;

namespace PreOrder_InOrder_PostOrder_In_One_Code
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("All Traversal");
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(5);
            root.left.left = new TreeNode(3);
            root.left.right = new TreeNode(4);

            root.right.left = new TreeNode(6);
            root.right.right = new TreeNode(7);

            AllTraversal(root);
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

        class Pair
        {
            public int num;
            public TreeNode node;
            public Pair(TreeNode root, int val)
            {
                node = root;
                num = val;
            }
        }

        public static void AllTraversal(TreeNode root)
        {
            Stack<Pair> stack = new Stack<Pair>();
            IList<int> pre = new List<int>();
            IList<int> inOrder = new List<int>();
            IList<int> post = new List<int>();

            stack.Push(new Pair(root, 1));

            while (stack.Count > 0)
            {
                Pair it = stack.Peek();
                stack.Pop();

                if (it.num == 1)
                {
                    pre.Add(it.node.val);
                    it.num++;
                    stack.Push(it);

                    if (it.node.left != null) stack.Push(new Pair(it.node.left, 1));
                }
                else if (it.num == 2)
                {
                    inOrder.Add(it.node.val);
                    it.num++;
                    stack.Push(it);

                    if (it.node.right != null) stack.Push(new Pair(it.node.right, 1));
                }
                else
                {
                    post.Add(it.node.val);
                }
            }
        }
    }
}
