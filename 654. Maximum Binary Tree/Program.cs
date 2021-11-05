using System;

namespace _654._Maximum_Binary_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("654. Maximum Binary Tree");
            int[] nums = new int[] { 3, 2, 1, 6, 0, 5 };
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

        public static TreeNode ConstructMaximumBinaryTree(int[] nums)
        {
            return construct(nums, 0, nums.Length);
        }

        public static TreeNode construct(int[] nums, int l, int r)
        {
            if (l == r)
                return null;

            int maxIndex = max(nums, l, r);
            TreeNode rootNode = new TreeNode(nums[maxIndex]);
            rootNode.left = construct(nums, l, maxIndex);
            rootNode.right = construct(nums, maxIndex + 1, r);
            return rootNode;
        }

        public static int max(int[] nums, int l, int r)
        {
            int maxIndex = l;
            for (int i = l + 1; i < r; i++)
            {
                if (nums[maxIndex] < nums[i])
                {
                    maxIndex = i;
                }
            }

            return maxIndex;
        }
    }
}
