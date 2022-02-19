using System;

namespace CN_Count_Leaf_Nodes
{
    public class BinaryTreeNode<T>
    {
        public T data;
        public BinaryTreeNode<T> left;
        public BinaryTreeNode<T> right;

        public BinaryTreeNode(T data)
        {
            this.data = data;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Count_Leaf_Nodes");
        }

        public static void solve(BinaryTreeNode<int> root, ref int count)
        {
            if (root == null) return;

            if (root.left == null && root.right == null)
            {
                count++;
                return;
            }

            solve(root.left, ref count);
            solve(root.right, ref count);
        }

        public static int noOfLeafNodes(BinaryTreeNode<int> root)
        {
            int count = 0;
            solve(root, ref count);
            return count;
        }
    }
}
