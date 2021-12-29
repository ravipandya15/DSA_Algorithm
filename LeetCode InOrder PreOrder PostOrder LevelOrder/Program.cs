using System;
using System.Collections.Generic;

namespace LeetCode_InOrder_PreOrder_PostOrder_LevelOrder
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
            Console.WriteLine("Hello World!");

            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);
            root.left.right.left = new TreeNode(6);

            root.right.left = new TreeNode(7);
            root.right.right = new TreeNode(8);
            root.right.right.left = new TreeNode(9);
            root.right.right.right = new TreeNode(10);

            var result1 = InorderTraversal(root);
            var result2 = PreorderTraversal(root);
            var result3 = PostorderTraversal(root);

            Console.ReadLine();
        }

        public static void DfsInorder(TreeNode root, IList<int> result)
        {
            if (root == null) return;

            DfsInorder(root.left, result);
            result.Add(root.val);
            DfsInorder(root.right, result);
        }

        public static IList<int> InorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            DfsInorder(root, result);
            return result;
        }

        public static void DfsPreorder(TreeNode root, IList<int> result)
        {
            if (root == null) return;

            result.Add(root.val);
            DfsPreorder(root.left, result);
            DfsPreorder(root.right, result);
        }

        public static List<int> PreorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            DfsPreorder(root, result);
            return result;
        }

        public static void DfsPostorder(TreeNode root, IList<int> result)
        {
            if (root == null) return;

            DfsPostorder(root.left, result);
            DfsPostorder(root.right, result);
            result.Add(root.val);
        }

        public static IList<int> PostorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            DfsPostorder(root, result);
            return result;
        }

        public static IList<IList<int>> LevelOrder(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                int size = q.Count;
                List<int> temp = new List<int>();
                for (int i = 0; i < size; i++)
                {
                    TreeNode node = q.Peek();
                    q.Dequeue();
                    if (node.left != null)
                    {
                        q.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        q.Enqueue(node.right);
                    }
                    temp.Add(node.val);
                }
                result.Add(temp);
            }
            return result;
        }

    }
}
