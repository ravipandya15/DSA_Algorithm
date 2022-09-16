using System;

namespace _501._Find_Mode_in_Binary_Search_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("501. Find Mode in Binary Search Tree");
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

        public static void inorder(TreeNode cur, TreeNode prev, IList<int> ans, int[] count, int[] max)
        {
            // base case
            if (cur == null) return;
            inorder(cur.left, prev, ans, count, max);

            // logic
            if (prev != null)
            {
                if (cur.val == prev.val) count[0]++;
                else count[0] = 1;
            }
            if (count[0] > max[0])
            {
                max[0] = count[0];
                ans.clear();
                ans.add(cur.val);
            }
            else if (count[0] == max[0])
            {
                ans.add(count[0]);
            }
            prev = cur;

            inorder(cur.right, prev, ans, count, max);
        }

        public int[] findMode(TreeNode root)
        {
            int[] count = { 1 };
            int[] max = { Int32.MinValue };
            IList<int> ans = new List<int>();
            TreeNode prev = null;
            inorder(root, prev, ans, count, max);

            int n = ans.size();
            int[] result = new int[n];

            for (int i = 0; i < n; i++)
            {
                result[i] = ans[i];
            }
            return result;
        }
    }
}
