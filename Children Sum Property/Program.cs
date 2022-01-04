using System;

namespace Children_Sum_Property
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Children Sum Property");
        }
        public class BinaryTreeNode<Integer>
        {
            public int data;
            public BinaryTreeNode<Integer> left;
            public BinaryTreeNode<Integer> right;

            public BinaryTreeNode(int data)
            {
                this.data = data;
            }
        }

        // TC-> O(N)
        // SC-> O(N)
        public static void changeTree(BinaryTreeNode<int> root)
        {
            if (root == null) return;
            int child = 0;
            if (root.left != null) child += root.left.data;
            if (root.right != null) child += root.right.data;
            if (child >= root.data) root.data = child;
            else
            {
                if (root.left != null) root.left.data = root.data;
                if (root.right != null) root.right.data = root.data;
            }

            changeTree(root.left);
            changeTree(root.right);

            int total = 0;
            if (root.left != null) total += root.left.data;
            if (root.right != null) total += root.right.data;
            // below if condition is required. if both left ad right is null then total remains 0 and root.data becomes 0.
            if (root.left != null || root.right != null) root.data = total;

            // below condition will also work instead of line no 34 condition
            // if (total > root.data) root.data = total;
        }
    }
}
