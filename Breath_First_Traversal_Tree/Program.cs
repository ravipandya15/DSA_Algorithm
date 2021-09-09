using System;
using System.Collections.Generic;

namespace Breath_First_Traversal_Tree
{
    class Program
    {
        public class Node
        {
            public int val;
            public Node left, right;

            public Node(int val)
            {
                this.val = val;
                this.left = null;
                this.right = null;
            }
        }

        //DFS travseral is inorder, preroder, postorder 
        //inOrder(root.left);
        //Console.WriteLine(root);
        //inOrder(root.right);

        //BFS Traversal
        public static void PrintBFSTree(Node root)
        {
            if (root == null)
            {
                return;
            }
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            Console.WriteLine($"{root.val}");
            while (queue.Count != 0)
            {
                Node temp = queue.Dequeue();
                Console.Write($"{temp.val} ");
                if (temp.left != null)
                {
                    queue.Enqueue(temp.left);
                }
                if (temp.right != null)
                {
                    queue.Enqueue(temp.right);
                }
            }
        }
        //102. Binary Tree Level Order Traversal
        public static IList<IList<int>> LevelOrder(Node root)
        {
            if (root == null)
            {
                return new List<IList<int>>();
            }

            List<IList<int>> outputList = new List<IList<int>>();
            Queue<Node> queue = new Queue<Node>();
            int tempCount = 0;
            List<int> tempList = null;
            queue.Enqueue(root);
            Node temp = null;
            bool RightToLeftOrder = false;
            while (queue.Count != 0)
            {
                tempList = new List<int>();
                tempCount = queue.Count;
                while (tempCount != 0)
                {
                    temp = queue.Dequeue();
                    Console.Write($"{temp.val} ");
                    if (temp.left != null)
                    {
                        queue.Enqueue(temp.left);
                    }
                    if (temp.right != null)
                    {
                        queue.Enqueue(temp.right);
                    }
                    tempList.Add(temp.val);
                    tempCount--;
                }
                if (RightToLeftOrder)
                {
                    tempList.Reverse();
                }
                RightToLeftOrder = !RightToLeftOrder;
                outputList.Add(tempList);
            }
            return outputList;
        }

        // Binary Tree Level Order Traversal using recursion
        public static IList<IList<int>> LevelOrderRecursion(Node root)
        {
            if (root == null)
            {
                return new List<IList<int>>();
            }
            List<IList<int>> outputList = new List<IList<int>>();
            outputList.Add(new List<int> { root.val });

            TraverseTree(root.left, outputList, 1);
            TraverseTree(root.right, outputList, 1);
            return outputList;
        }

        public static void TraverseTree(Node root, IList<IList<int>> outputList, int depth)
        {
            if (root == null) return;
            if (outputList.Count == depth)
            {
                outputList.Add(new List<int>());
            }

            outputList[depth].Add(root.val);

            TraverseTree(root.left, outputList, depth + 1);
            TraverseTree(root.right, outputList, depth + 1);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("BFS of a tree...");
            Node root = new Node(1);
            root.left = new Node(2);
            root.right = new Node(3);
            root.left.left = new Node(4);
            root.right.right = new Node(5);
            Console.WriteLine("BFS traversal of a tree is....");
            Console.WriteLine();
            //PrintBFSTree(root);
            LevelOrder(root);
            //LevelOrderRecursion(root);
        }
    }
}
