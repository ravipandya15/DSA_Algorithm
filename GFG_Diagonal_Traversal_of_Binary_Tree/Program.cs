using System;
using System.Collections.Generic;

public class Node
{
    public int data;
    public Node left;
    public Node right;
    public Node(int data)
    {
        this.data = data;
        left = null;
        right = null;
    }
}

public class Pair
{
    public Node node;
    public int line;

    public Pair(Node _node, int _line)
    {
        node = _node;
        line = _line;
    }
}

namespace GFG_Diagonal_Traversal_of_Binary_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GFG_Diagonal_Traversal_of_Binary_Tree");

            // Input : 12 11 12 7 1 12 14 11 N 7 3 6 4 12 7 14 14 N 2 10 8. 7
            Node root = new Node(12);
            Node node2 = new Node(11);
            Node node3 = new Node(12);
            Node node4 = new Node(7);
            Node node5 = new Node(1);
            Node node6 = new Node(12);
            Node node7 = new Node(14);
            Node node8 = new Node(11);
            Node node9 = new Node(7);
            Node node10 = new Node(3);
            Node node11 = new Node(6);
            Node node12 = new Node(4);
            Node node13 = new Node(12);
            Node node14 = new Node(7);
            Node node15 = new Node(14);
            Node node16 = new Node(14);
            Node node17 = new Node(2);
            Node node18 = new Node(10);
            Node node19 = new Node(8);
            Node node20 = new Node(7);

            root.left = node2;
            root.right = node3;

            node2.left = node4;
            node2.right = node5;

            node3.left = node6;
            node3.right = node7;

            node4.left = node8;

            node5.left = node9;
            node5.right = node10;

            node6.left = node11;
            node6.right = node12;

            node7.left = node13;
            node7.right = node14;

            node8.left = node15;
            node8.right = node16;

            node9.right = node17;

            node10.left = node18;
            node10.right = node19;

            node11.left = node20;

            List<int> result = diagonal(root);
            foreach (int data in result)
            {
                Console.Write(data + " ");
            }

        }

        public static List<int> diagonal(Node root)
        {
            List<int> res = new List<int>();
            if (root == null) return res;
            Stack<Pair> stack = new Stack<Pair>();
            SortedDictionary<int, Queue<int>> map = new SortedDictionary<int, Queue<int>>();

            stack.Push(new Pair(root, 0));

            while (stack.Count > 0)
            {
                Pair pair = stack.Peek();
                stack.Pop();

                Node node = pair.node;
                int line = pair.line;

                if (!map.ContainsKey(line))
                {
                    map.Add(line, new Queue<int>());
                }

                map[line].Enqueue(node.data);

                if (node.right != null)
                {
                    stack.Push(new Pair(node.right, line));
                }
                if (node.left != null)
                {
                    stack.Push(new Pair(node.left, line + 1));
                }
            }

            foreach (Queue<int> value in map.Values)
            {
                foreach (int val in value)
                {
                    res.Add(val);
                }
            }

            return res;
        }
    }
}
