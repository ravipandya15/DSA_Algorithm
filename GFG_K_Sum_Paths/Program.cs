using System;
using System.Collections.Generic;

namespace GFG_K_Sum_Paths
{
    public class Node
    {
        public int data;
        public Node left;
        public Node right;
        public Node(int data)
        {
            this.data = data;
            left = null;
            right = null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GFG_K_Sum_Paths");
        }

        public static void solve(Node root, int k, int[] count, List<int> list)
        {
            if (root == null) return;

            list.Add(root.data);

            solve(root.left, k, count, list);
            solve(root.right, k, count, list);

            int sum = 0;
            int size = list.Count;
            for (int i = size - 1; i >= 0; i--)
            {
                sum = sum + list[i];
                if (sum == k)
                    count[0]++;
            }

            list.RemoveAt(list.Count - 1);
        }

        public int sumK(Node root, int k)
        {
            List<int> list = new List<int>();
            int[] count = { 0 };
            solve(root, k, count, list);
            return count[0];
        }
    }
}
