using System;
using System.Collections.Generic;

namespace CN_LeetCode__Boundary_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_LeetCode__Boundary_Traversal");

            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.left.left = new TreeNode(3);
            root.left.left.right = new TreeNode(4);
            root.left.left.right.left = new TreeNode(5);
            root.left.left.right.right = new TreeNode(6);

            root.right = new TreeNode(7);
            root.right.right = new TreeNode(8);
            root.right.right.left = new TreeNode(9);
            root.right.right.left.left = new TreeNode(10);
            root.right.right.left.right = new TreeNode(11);

            var result = TraverseBoundry(root);

            Console.ReadLine();
        }

        public class TreeNode
        {
            public int data;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.data = val;
                this.left = left;
                this.right = right;
            }
        }

        private static bool isLeaf(TreeNode node)
        {
            return (node.left == null) && (node.right == null);
        }

        private static void addLeftBoundry(TreeNode node, List<int> res)
        {
            TreeNode cur = node.left;
            while (cur != null)
            {
                if (!isLeaf(cur)) res.Add(cur.data);
                if (cur.left != null) cur = cur.left;
                else cur = cur.right;
            }
        }

        private static void addLeaf(TreeNode node, List<int> res)
        {
            if (isLeaf(node)) res.Add(node.data);

            if (node.left != null) addLeaf(node.left, res);
            if (node.right != null) addLeaf(node.right, res);
        }

        private static void addRightBoundry(TreeNode node, List<int> res)
        {
            TreeNode cur = node.right;
            List<int> temp = new List<int>();
            while (cur != null)
            {
                if (!isLeaf(cur)) temp.Add(cur.data);
                if (cur.right != null) cur = cur.right;
                else cur = cur.left;
            }

            for (int i = temp.Count - 1; i >= 0; i--)
            {
                res.Add(temp[i]);
            }
        }

        public static IList<int> TraverseBoundry(TreeNode root)
        {
            List<int> res = new List<int>();
            if (root == null) return res;
            if (!isLeaf(root)) res.Add(root.data);

            addLeftBoundry(root, res);
            addLeaf(root, res);
            addRightBoundry(root, res);
            return res;
        }
    }
}
