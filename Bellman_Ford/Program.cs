using System;
using System.Collections.Generic;

namespace Bellman_Ford
{
    class Node
    {
        int u;
        int v;
        int weight;
        public Node(int _u, int _v, int _w)
        {
            u = _u;
            v = _v;
            weight = _w;
        }

        Node() { }

        public int getU()
        {
            return u;
        }
        public int getV()
        {
            return v;
        }
        public int getWeight()
        {
            return weight;
        }
    }

    class Main
    {
        public void bellmanFord(List<Node> adj, int n, int src)
        {
            int[] dist = new int[n];
            for (int i = 0; i < n; i++)
            {
                dist[i] = Int32.MaxValue;
            }
            dist[0] = 0;

            for (int i = 1; i <= n - 1; i++)
            {
                foreach (Node it in adj)
                {
                    if (dist[it.getU()] + it.getWeight() < dist[it.getV()])
                    {
                        dist[it.getV()] = dist[it.getU()] + it.getWeight();
                    }
                }
            }

            int flag = 0;

            foreach (Node it in adj)
            {
                if (dist[it.getU()] + it.getWeight() < dist[it.getV()])
                {
                    flag = 1;
                    Console.WriteLine("Negative Cycle");
                    break;
                }
            }

            if (flag == 0)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Shortest distance from " + src + " to " + i + " is " + dist[i]);
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bellman_Ford");

            int n = 6;
            List<Node> adj = new List<Node>();


            adj.Add(new Node(3, 2, 6));
            adj.Add(new Node(5, 3, 1));
            adj.Add(new Node(0, 1, 5));
            adj.Add(new Node(1, 5, -3));
            adj.Add(new Node(1, 2, -2));
            adj.Add(new Node(3, 4, -2));
            adj.Add(new Node(2, 4, 3));


            Main obj = new Main();
            obj.bellmanFord(adj, n, 0);
        }
    }
}
