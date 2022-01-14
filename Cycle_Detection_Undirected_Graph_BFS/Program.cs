using System;
using System.Collections.Generic;

namespace Cycle_Detection_Undirected_Graph_BFS
{

    class Node
    {
        public int first;
        public int second;
        public Node(int first, int second)
        {
            this.first = first;
            this.second = second;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("using BFS and DFS");
        }

        // BFS
        // TC -> O(N+E)
        // SC -> O(N+E) + O(N) + O(N)
        private static bool checkForCycle(int i, bool[] visited, List<List<int>> adj)
        {
            Queue<Node> q = new Queue<Node>(); // BFS
            q.Enqueue(new Node(i, -1));
            visited[i] = true;

            while (q.Count > 0)
            {
                int node = q.Peek().first;
                int parent = q.Peek().second;
                q.Dequeue();

                foreach (int it in adj[node])
                {
                    if (!visited[it])
                    {
                        q.Enqueue(new Node(it, node));
                        visited[it] = true;
                    }
                    else
                    {// means it is visited so check is it is parent or not
                        if (it != parent) return true;
                    }
                }
            }


            return false;
        }

        public static bool isCycle_BFS(int V, List<List<int>> adj)
        {
            bool[] visited = new bool[V + 1];
            for (int i = 1; i <= V; i++)
            {
                if (!visited[i])
                {
                    if (checkForCycle(i, visited, adj)) return true;
                }
            }

            return false;
        }



        // DFS
        // TC -> O(N+E)
        // SC -> O(N+E) + O(N) + O(N)
        private static bool checkForCycle_DFS(int node, int parent, bool[] visited, List<List<int>> adj)
        {
            visited[node] = true;

            foreach (int it in adj[node])
            {
                if (!visited[it])
                {
                    if (checkForCycle_DFS(it, node, visited, adj)) return true;
                }
                else
                {
                    if (it != parent) return true;
                }
            }
            return false;
        }


        public static bool isCycle_DFS(int V, List<List<int>> adj)
        {
            bool[] visited = new bool[V + 1];
            for (int i = 1; i <= V; i++)
            {
                if (!visited[i])
                {
                    if (checkForCycle_DFS(i, -1, visited, adj)) return true;
                }
            }

            return false;
        }

    }
}
