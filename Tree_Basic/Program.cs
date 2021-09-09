using System;
using System.Collections.Generic;
using System.Linq;

namespace Tree_Basic
{
    class Program
    {
        public class Node
        {
            public int key;
            public Node left, right;
            public Node(int key)
            {
                this.key = key;
                this.left = this.right = null;
            }
            public Node()
            {

            }
        }

        public static Node root;

        public static void InOrder(Node root)
        {
            if (root == null)
                return;

            InOrder(root.left);
            Console.Write(root.key + " ");
            InOrder(root.right);
        }
        public static void Insert(Node root, int key)
        {
            if (root == null)
                root = new Node(key);

            Queue<Node> queueNodes = new Queue<Node>();
            queueNodes.Enqueue(root);

            while (queueNodes.Count != 0)
            {
                Node peekNode = queueNodes.Peek();
                queueNodes.Dequeue();

                if (peekNode.left == null)
                {
                    peekNode.left = new Node(key);
                    break;
                }
                else
                    queueNodes.Enqueue(peekNode.left);

                if (peekNode.right == null)
                {
                    peekNode.right = new Node(key);
                    break;
                }
                else
                    queueNodes.Enqueue(peekNode.right);
            }
        }

        public void DeleteNode()
        {

        }

        public static int FindRightBottomMost(Node root)
        {
            Node parent = null;

            while(root != null)
            {
                if (root.left == null && root.right == null)
                {
                    if (parent == null)
                    {
                        return root.key;   
                    }
                    else
                    {
                        if (parent.left.key == root.key)
                        {
                            parent.left = null;
                            return root.key;
                        }
                        else if (parent.right.key == root.key)
                        {
                            parent.right = null;
                            return root.key;
                        }
                    }
                }
                    //return root.key;

                if (root.right != null)
                {
                    parent = root;
                    root = root.right;
                }
                else if (root.left != null)
                {
                    parent = root;
                    root = root.left;
                }
            }

            return int.MinValue;
        }

        public static void ReplaceNode(int key, int rightMostvalue, Node root)
        {
            Queue<Node> queueNodes = new Queue<Node>();
            queueNodes.Enqueue(root);

            while (queueNodes.Count != 0)
            {
                Node peek = queueNodes.Peek();
                queueNodes.Dequeue();

                if (peek.key == key)
                {
                    peek.key = rightMostvalue;
                    return;
                }
                queueNodes.Enqueue(peek.left);
                queueNodes.Enqueue(peek.right);
            }
        }

        public static List<int> ansList = new List<int>();
        public static int ans = 0;

        public static int MaxDepth(Node root)
        {
            if (root == null)
            {
                return 0;
            }
            else
            {
                int answer = 1;
                if (root.left == null && root.right == null)
                {
                    return answer;
                }
                else
                {
                    if (root.left != null)
                    {
                        answer = Math.Max(answer, MaxDepth(root.left) + 1);
                    }
                    if (root.right != null)
                    {
                        answer = Math.Max(answer, MaxDepth(root.right) + 1);
                    }
                    return answer;
                }
            }
        }

        public static int DFS(Node root, int value)
        {
            if (root == null)
            {
                return value;
            }
            ans++;
            ansList.Add(ans);
            int leftvalue = DFS(root.left, ans);
            //ans--;
            //ans = Math.Max(ans, leftvalue);
            //ans++;
            int rightValue = DFS(root.right, ans);
            ans--;
            //ans = Math.Max(ans, rightValue);
            return ansList.Max();
        }

        static void Main(string[] args)
        {
            //Console.WriteLine("Insertion of Node into the binary tree at the first position available in level order..");
            //root = new Node(10);
            //root.left = new Node(11);
            //root.right = new Node(9);
            //root.left.left = new Node(7);
            //root.right.left = new Node(15);
            //root.right.right = new Node(8);
            //Console.WriteLine("Inorder before adding Node ....");
            //InOrder(root);
            //Console.WriteLine();
            //Console.WriteLine("Inorder after adding Node ....");
            //Insert(root, 12);
            //InOrder(root);

            //Console.WriteLine("Deletion of Node in binary tree.... replace deleted node with right most bottom most node");
            //root = new Node(10);
            //root.left = new Node(11);
            //root.left.left = new Node(7);
            //root.left.right = new Node(12);
            //root.left.right.right = new Node(13);
            //root.right = new Node(9);
            //root.right.left = new Node(15);
            //root.right.right = new Node(8);
            int key = 11;

            Console.WriteLine("MaxDepth of Binary tree.........Using Recursion");
            root = new Node(3);
            root.left = new Node(9);
            root.right = new Node(20);
            root.right.left = new Node(15);
            root.right.right = new Node(7);
            Console.WriteLine($"Max Depth of Binary tree is {MaxDepth(root)}");
            Console.ReadLine();

            int ans = DFS(root, 0);
            foreach (var value in ansList)
            {
                Console.WriteLine($"{value} ");
            }
            Console.WriteLine($"Ans is {ans}");
            // only for deletion
            //if (root == null)
            //{
            //    Console.WriteLine("Root is null. deletion is not possible");
            //}

            Console.WriteLine("Inorder before adding Node ....");
            InOrder(root);
            Console.WriteLine();
            Console.WriteLine("Inorder after adding Node ....");

            int rightMostvalue = FindRightBottomMost(root);

            ReplaceNode(key, rightMostvalue, root);
            InOrder(root);
            Console.ReadLine();
        }
    }
}
