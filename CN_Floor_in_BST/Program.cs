using System;

namespace CN_Floor_in_BST
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Floor_in_BST");
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

        public static int floorInBST(TreeNode<int> root, int X)
        {
            int floor = -1;
            while (root != null)
            {
                if (root.data == X)
                {
                    floor = root.data;
                    return floor;
                }
                if (X < root.data)
                { // left side
                    root = root.left;
                }
                else
                {
                    floor = root.data;
                    root = root.right;
                }
            }
            return floor;
        }
    }
}
