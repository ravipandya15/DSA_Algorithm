using System;
using System.Collections.Generic;
using System.Linq;

namespace _103._Binary_Tree_Zigzag_Level_Order_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("103. Binary Tree Zigzag Level Order Traversal");
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20);

            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(7);
            var result = ZigzagLevelOrder(root);
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

        public static IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null) return result;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            bool leftToRight = true;

            while (queue.Count > 0)
            {
                int size = queue.Count;
                List<int> tempList = new List<int>();
                for (int i = 0; i < size; i++)
                {
                    TreeNode temp = queue.Peek();
                    queue.Dequeue();

                    if (temp.left != null) queue.Enqueue(temp.left);
                    if (temp.right != null) queue.Enqueue(temp.right);

                    tempList.Add(temp.val);
                }
                if (!leftToRight)
                {
                    tempList.Reverse();
                }
                result.Add(tempList);
                leftToRight = !leftToRight;
            }
            return result;
        }
    }
}
