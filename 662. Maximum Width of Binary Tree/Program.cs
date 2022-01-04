using System;
using System.Collections.Generic;

namespace _662._Maximum_Width_of_Binary_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("662. Maximum Width of Binary Tree");
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

        public class Pair
        {
            public TreeNode node;
            public int index;
            public Pair(TreeNode _node, int _index)
            {
                node = _node;
                index = _index;
            }
        }

        public static int WidthOfBinaryTree(TreeNode root)
        {
            if (root == null) return 0;
            Queue<Pair> q = new Queue<Pair>();
            int ans = 0;
            q.Enqueue(new Pair(root, 0));

            while (q.Count > 0)
            {
                int size = q.Count;
                int min_level_index = q.Peek().index;
                int first = 0, last = 0;
                for (int i = 0; i < size; i++)
                {
                    Pair pair = q.Peek();
                    q.Dequeue();
                    int cur_index = pair.index - min_level_index;
                    TreeNode node = pair.node;

                    if (i == 0) first = cur_index;
                    if (i == size - 1) last = cur_index;
                    if (node.left != null) q.Enqueue(new Pair(node.left, cur_index * 2 + 1));
                    if (node.right != null) q.Enqueue(new Pair(node.right, cur_index * 2 + 2));
                }
                ans = Math.Max(ans, last - first + 1);
            }

            return ans;
        }
    }
}
