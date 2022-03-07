using System;
using System.Collections.Generic;

namespace Insertions_Deletion_Searching_Of_Node
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
            Console.WriteLine("Insertions_Deletion_Searching_Of_Node");
            Node root = null;
            Console.WriteLine("Enter data to create BST");
            takeInput(ref root);

            Console.WriteLine("Level Order tranersal of BST");
            LevelOrder(root);
        }

        public static bool searchInBST(Node root, int x)
        {
            Node temp = root;
            while (temp != null)
            {
                if (temp.data == x)
                {
                    return true;
                }
                if (x < temp.data)
                {
                    temp = temp.left;
                }
                else
                {
                    temp = temp.right;
                }
            }

            return false;
        }

        public static void takeInput(ref Node root)
        {
            int data = Convert.ToInt32(Console.ReadLine());
            while (data != -1)
            {
                insertIntoBST(ref root, data);
                data = Convert.ToInt32(Console.ReadLine());
            }
        }

        public static Node insertIntoBST(ref Node root, int data)
        {
            if (root == null)
            {
                root = new Node(data);
                return root;
            }

            if (data < root.data)
            {
                root.left = insertIntoBST(ref root.left, data);
            }
            else
            {
                root.right = insertIntoBST(ref root.right, data);
            }

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
