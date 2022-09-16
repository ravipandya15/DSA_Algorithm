using System;

namespace Minimum_Distance_Between_BST_Nodes_783
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode() { }
        public TreeNode(int val) { this.val = val; }
        public TreeNode(int val, TreeNode left, TreeNode right)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Minimum_Distance_Between_BST_Nodes_783");
            TreeNode root = new TreeNode(90);
            TreeNode node2 = new TreeNode(69);
            TreeNode node3 = new TreeNode(49);
            TreeNode node4 = new TreeNode(89);
            TreeNode node5 = new TreeNode(52);
            root.left = node2;
            node2.left = node3;
            node2.right = node4;
            node3.right = node5;
            int ans = minDiffInBST(root);
            Console.WriteLine($"ans is {ans}");
        }

        public static void solve(TreeNode root, int[] res, int pre)
        {
            if (root.left != null) solve(root.left, res, pre);
            if (pre >= 0) res[0] = Math.Min(res[0], root.val - pre);
            pre = root.val;
            if (root.right != null) solve(root.right, res, pre);
        }

        public static int minDiffInBST(TreeNode root)
        {
            int[] res = { Int32.MaxValue };
            int pre = -1;
            solve(root, res, pre);
            return res[0];
        }
    }
}
