using System;
using System.Collections.Generic;

namespace Build_Tree_From_LevelOrder_Traversal
{
    public class Node
    {
        public int data;
        public Node left;
        public Node right;

        public Node(int d)
        {
            this.data = d;
            this.left = null;
            this.right = null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Build_Tree_From_LevelOrder_Traversal");
            Node root = null;
            BuildFromLevelOrder(root);
        }

        public static void BuildFromLevelOrder(Node root)
        {
            Console.WriteLine("Enter data for root node");
            int data = Convert.ToInt32(Console.ReadLine());
            if (data == -1) return;
            root = new Node(data);

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                Node temp = queue.Peek();
                queue.Dequeue();

                Console.WriteLine($"Enter data for left of {temp.data} node");
                int leftData = Convert.ToInt32(Console.ReadLine());
                if (leftData != -1)
                {
                    temp.left = new Node(leftData);
                    queue.Enqueue(temp.left);
                }

                Console.WriteLine($"Enter data for right of {temp.data} node");
                int rightData = Convert.ToInt32(Console.ReadLine());
                if (rightData != -1)
                {
                    temp.right = new Node(rightData);
                    queue.Enqueue(temp.right);
                }
            }
        }
    }
}
