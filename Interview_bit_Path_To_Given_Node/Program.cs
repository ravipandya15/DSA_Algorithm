using System;
using System.Collections.Generic;

namespace Interview_bit_Path_To_Given_Node
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Interview_bit_Path_To_Given_Node");
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { this.val = x; this.left = this.right = null; }
        }

        private static bool getPath(TreeNode node, int B, List<int> res)
        {
            if (node == null) return false;

            res.Add(node.val);

            if (node.val == B) return true;

            if (getPath(node.left, B, res) || getPath(node.right, B, res)) return true;

            res.RemoveAt(res.Count - 1);

            return false;
        }

        public static List<int> solve(TreeNode A, int B)
        {
            List<int> res = new List<int>();
            if (A == null) return res;
            getPath(A, B, res);
            return res;
        }
    }
}
