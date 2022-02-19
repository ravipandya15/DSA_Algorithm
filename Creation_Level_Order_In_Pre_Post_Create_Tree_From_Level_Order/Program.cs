using System;
using System.Collections.Generic;

namespace Creation_Level_Order_In_Pre_Post_Create_Tree_From_Level_Order
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
            Console.WriteLine("Creation_Level_Order_In_Pre_Post_Create_Tree_From_Level_Order");
        }

        public static Node buildTree(Node root)
        {
            Console.WriteLine("Enter data");
            int data = Convert.ToInt32(Console.ReadLine());

            if (data == -1)
            {
                return null;
            }

            Console.WriteLine($"Enter data for inserting left of {data}");
            root.left = buildTree(root.left);
            Console.WriteLine($"Enter data for inserting right of {data}");
            root.right = buildTree(root.right);

            return root;
        }

        // Level Order
        // for reverse level order first push right and then push left
        public static void LevelOrder(Node root)
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            queue.Enqueue(null);

            while (queue.Count > 0)
            {
                Node temp = queue.Peek();
                queue.Dequeue();

                if (temp == null)
                {
                    Console.WriteLine();
                    if (queue.Count > 0)
                    {
                        queue.Enqueue(null);
                    }
                }
                else
                {
                    Console.Write($"{temp.data} ");

                    if (temp.left != null)
                        queue.Enqueue(temp.left);

                    if (temp.right != null)
                        queue.Enqueue(temp.right);
                }
            }
        }
    }
}
