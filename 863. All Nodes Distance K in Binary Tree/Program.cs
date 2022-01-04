using System;
using System.Collections.Generic;

namespace _863._All_Nodes_Distance_K_in_Binary_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("863. All Nodes Distance K in Binary Tree");
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        private static void MarkParents(TreeNode root, Dictionary<TreeNode, TreeNode> parent_track)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                TreeNode node = q.Peek();
                q.Dequeue();
                if (node.left != null)
                {
                    parent_track.Add(node.left, node);
                    q.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    parent_track.Add(node.right, node);
                    q.Enqueue(node.right);
                }
            }
        }

        public static IList<int> DistanceK(TreeNode root, TreeNode target, int k)
        {
            Dictionary<TreeNode, TreeNode> parent_track = new Dictionary<TreeNode, TreeNode>();
            MarkParents(root, parent_track);
            Queue<TreeNode> q = new Queue<TreeNode>();
            Dictionary<TreeNode, bool> visited = new Dictionary<TreeNode, bool>();
            q.Enqueue(target);
            visited.Add(target, true);
            int dis = 0;
            while (q.Count > 0)
            {
                int size = q.Count;
                if (dis == k) break;
                dis++;
                for (int i = 0; i < size; i++)
                {
                    TreeNode node = q.Peek();
                    q.Dequeue();

                    if (node.left != null && !visited.ContainsKey(node.left))
                    {
                        q.Enqueue(node.left);
                        visited.Add(node.left, true);
                    }
                    if (node.right != null && !visited.ContainsKey(node.right))
                    {
                        q.Enqueue(node.right);
                        visited.Add(node.right, true);
                    }
                    // check parent node
                    if (parent_track.TryGetValue(node, out TreeNode parent) && !visited.ContainsKey(parent))
                    {
                        q.Enqueue(parent);
                        visited.Add(parent, true);
                    }
                }
            }

            IList<int> res = new List<int>();
            while (q.Count > 0)
            {
                TreeNode node = q.Peek();
                q.Dequeue();
                res.Add(node.val);
            }
            return res;
        }
    }
}
