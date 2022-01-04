using System;

namespace _124._Binary_Tree_Maximum_Path_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("124. Binary Tree Maximum Path Sum");
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

        private static int MaxPathDown(TreeNode node, ref int maxi)
        {
            if (node == null) return 0;

            int leftSum = Math.Max(0, MaxPathDown(node.left, ref maxi));
            int rightSum = Math.Max(0, MaxPathDown(node.right, ref maxi));

            maxi = Math.Max(maxi, node.val + leftSum + rightSum);

            return node.val + Math.Max(leftSum, rightSum);
            // below will also work if we don't need to use Math.Max(0, MaxPathDown(node.left, ref maxi));
            //return (node.val + Math.Max(leftSum, rightSum)) > 0 ? node.val + Math.Max(leftSum, rightSum): 0;
        }

        public static int MaxPathSum(TreeNode root)
        {
            int maxi = Int32.MinValue;
            MaxPathDown(root, ref maxi);
            return maxi;
        }
    }
}
