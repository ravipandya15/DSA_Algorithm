using System;

namespace CN_Ceil_from_BST
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Ceil_from_BST");
        }

        public class TreeNode<T>
        {
            public T data;
            public TreeNode<T> left;
            public TreeNode<T> right;

            public TreeNode(T data)
            {
                this.data = data;
                left = null;
                right = null;
            }
        };

        public static int findCeil(TreeNode<int> node, int x)
        {
            int ceil = -1;
            while (node != null)
            {
                if (node.data == x)
                {
                    ceil = node.data;
                    return ceil;
                }
                if (x < node.data)
                { // left side
                    ceil = node.data;
                    node = node.left;
                }
                else
                {
                    node = node.right;
                }
            }
            return ceil;
        }
    }
}
