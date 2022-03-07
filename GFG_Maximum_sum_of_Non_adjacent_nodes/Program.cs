using System;

namespace GFG_Maximum_sum_of_Non_adjacent_nodes
{
    public class Node
    {
        public int data;
        public Node left, right;

        public Node(int data)
        {
            this.data = data;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GFG_Maximum_sum_of_Non_adjacent_nodes");
        }

        public static Tuple<int, int> solve(Node root)
        {
            if (root == null)
            {
                return new Tuple<int, int>(0, 0);
            }

            Tuple<int, int> left = solve(root.left);
            Tuple<int, int> right = solve(root.right);

            // include current node
            int first = root.data + left.Item2 + right.Item2;

            // exclude current Node
            int second = Math.Max(left.Item1, left.Item2) + Math.Max(right.Item1, right.Item2);

            return new Tuple<int, int>(first, second);
        }

        static int getMaxSum(Node root)
        {
            Tuple<int, int> ans = solve(root);
            return Math.Max(ans.Item1, ans.Item2);
        }
    }
}
