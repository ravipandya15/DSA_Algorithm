using System;
using System.Collections.Generic;

namespace Max_Depth_Of_N_Array_Tree
{
    class Program
    {
        public class Node
        {
            public int val;
            public List<Node> children;

            public Node(){}

            public Node(int val, List<Node> children)
            {
                this.val = val;
                this.children = children;
            }
        }
        public static int MaxDepth(Node root)
        {
            if (root == null)
            {
                return 0;
            }
            else
            {
                int ans = 1;
                if (root.children != null)
                {
                    foreach (Node x in root.children)
                    {
                        ans = Math.Max(ans, MaxDepth(x) + 1);
                    }
                }
                return ans;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Max Depth of N-array tree");
            //Node child1 = new Node(5, null);
            //Node child2 = new Node(6, null);
            //List<Node> children1 = new List<Node>();
            //children1.Add(child1);
            //children1.Add(child2);
            //Node child3 = new Node(3, children1);
            //List<Node> children2 = new List<Node>();
            //Node child4 = new Node(2, null);
            //Node child5 = new Node(4, null);
            //children2.Add(child3);
            //children2.Add(child4);
            //children2.Add(child5);
            //Node root = new Node(1, children2);

            Node child1 = new Node(14, null);
            Node child2 = new Node(12, null);
            Node child3 = new Node(13, null);
            Node child4 = new Node(10, null);
            Node child5 = new Node(2, null);
            Node child6 = new Node(11, new List<Node> { child1});
            Node child7 = new Node(8, new List<Node> { child2 });
            Node child8 = new Node(9, new List<Node> { child3 });
            Node child9 = new Node(7, new List<Node> { child6 });
            Node child10 = new Node(6, null);
            Node child11 = new Node(3, new List<Node> { child10, child9 });
            Node child12 = new Node(4, new List<Node> { child7});
            Node child13 = new Node(5, new List<Node> { child8, child4 });
            Node root = new Node(1, new List<Node> { child5, child11, child12, child13});
            Console.WriteLine($"MaxDepth is {MaxDepth(root)}");
            Console.ReadLine();
        }
    }
}
