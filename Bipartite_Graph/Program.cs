using System;
using System.Collections.Generic;

namespace Bipartite_Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bipartite using BFS and DFS");
        }

        // BFS
        // TC > O(N+E)
        // SC -> O(N+E) + O(N) + O(N)
        public static bool checkBFS(int node, int[] color, List<List<int>> adj)
        {
            Queue<int> q = new Queue<int>();
            q.Enqueue(node);
            color[node] = 0;

            while (q.Count > 0)
            {
                int cur = q.Peek();
                q.Dequeue();
                foreach (int it in adj[cur])
                {
                    if (color[it] == -1)
                    {
                        q.Enqueue(it);
                        color[it] = 1 - color[cur];
                    }
                    else if (color[it] == color[cur])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool checkBipartite1(int V, List<List<int>> adj)
        {
            // this time it's 0 based indexing
            int[] color = new int[V];
            for (int i = 0; i < V; i++)
            {
                color[i] = -1;
            }

            // check for every component
            for (int i = 0; i < V; i++)
            {
                if (color[i] == -1)
                {
                    if (checkBFS(i, color, adj) == false)
                    {
                        return false;
                    }
                }
            }

            return true;
        }


        // DFS
        // TC > O(N+E)
        // SC -> O(N+E) + O(N) + O(N)
        public static bool checkDFS(int node, int[] color, List<List<int>> adj)
        {
            if (color[node] == -1)
                color[node] = 1;

            foreach (int it in adj[node])
            {
                if (color[it] == -1)
                {
                    color[it] = 1 - color[node];
                    if (!checkDFS(it, color, adj)) return false;
                }
                else if (color[it] == color[node]) return false;
            }
            return true;
        }


        public bool checkBipartite(int V, List<List<int>> adj)
        {
            // this time it's 0 based indexing
            int[] color = new int[V];
            for (int i = 0; i < V; i++)
            {
                color[i] = -1;
            }

            // check for every component
            for (int i = 0; i < V; i++)
            {
                if (color[i] == -1)
                {
                    if (checkDFS(i, color, adj) == false)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
