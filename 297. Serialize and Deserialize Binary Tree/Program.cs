using System;
using System.Collections.Generic;
using System.Text;

namespace _297._Serialize_and_Deserialize_Binary_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("297. Serialize and Deserialize Binary Tree");
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(13);
            root.right.left = new TreeNode(4);
            root.right.right = new TreeNode(5);
            string str = serialize(root);
            TreeNode node = deserialize(str);
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        // Encodes a tree to a single string.
        public static string serialize(TreeNode root)
        {
            if (root == null) return "";
            StringBuilder res = new StringBuilder();
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                TreeNode node = q.Peek();
                q.Dequeue();
                if (node == null)
                {
                    res.Append("#,");
                    continue;
                }
                res.Append(node.val + ",");
                q.Enqueue(node.left);
                q.Enqueue(node.right);
            }
            return res.ToString();
        }

        // Decodes your encoded data to tree.
        public static TreeNode deserialize(string data)
        {
            if (data == "") return null;
            Queue<TreeNode> q = new Queue<TreeNode>();
            string[] values = data.Split(',');
            TreeNode root = new TreeNode(Convert.ToInt32(values[0]));
            q.Enqueue(root);
            int i = 1;
            while(q.Count > 0)
            {
                TreeNode node = q.Peek();
                q.Dequeue();
                if (!values[i].Equals("#"))
                {
                    TreeNode left = new TreeNode(Convert.ToInt32(values[i]));
                    node.left = left;
                    q.Enqueue(left);
                }
                i++;
                // i++ will not work. ++i will work or add one line b/w two if and write i++;
                if (!values[i].Equals("#"))
                {
                    TreeNode right = new TreeNode(Convert.ToInt32(values[i]));
                    node.right = right;
                    q.Enqueue(right);
                }
                i++;
            }
            return root;
        }
    }
}
