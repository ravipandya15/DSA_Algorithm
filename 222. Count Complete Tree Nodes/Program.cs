using System;

namespace _222._Count_Complete_Tree_Nodes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("222. Count Complete Tree Nodes");

            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);

            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);

            root.right.left = new TreeNode(6);

            int nodes = CountNodes(root);
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

        private static int findLeftHeight(TreeNode node)
        {
            int height = 0;
            while (node != null)
            {
                height++;
                node = node.left;
            }
            return height;
        }

        private static int findRightHeight(TreeNode node)
        {
            int height = 0;
            while (node != null)
            {
                height++;
                node = node.right;
            }
            return height;
        }

        public static int CountNodes(TreeNode root)
        {
            if (root == null) return 0;

            int lh = findLeftHeight(root);
            int rh = findRightHeight(root);

            if (lh == rh) return (1 << lh) - 1;

            return 1 + CountNodes(root.left) + CountNodes(root.right);
        }
    }
}
