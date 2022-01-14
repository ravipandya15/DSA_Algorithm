using System;
using System.Collections.Generic;

namespace Cycle_Detection_Directed_Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Cycle_Detection_Directed_Graph");
        }

        // Kahn's Algorithm (BFS)
        // TC -> O(N+E)
        // SC -> O(N+E) + O(N) + O(N)
        public static bool isCycle_BFS(int V, List<List<int>> adj)
        {
            Queue<int> q = new Queue<int>();
            int[] inDegree = new int[V];
            for (int i = 0; i < V; i++)
            {
                foreach (int it in adj[i])
                {
                    inDegree[it]++;
                }
            }

            for (int i = 0; i < V; i++)
            {
                if (inDegree[i] == 0)
                {
                    q.Enqueue(i);
                }
            }

            int count = 0;
            while (q.Count > 0)
            {
                int node = q.Peek();
                q.Dequeue();
                count++;

                foreach (int it in adj[node])
                {
                    inDegree[it]--;
                    if (inDegree[it] == 0)
                    {
                        q.Enqueue(it);
                    }
                }
            }

            if (count == V) return false; // as topological sort is possible, so there will not be any clcle in graph
            return true;
        }

        // DFS
        // TC -> O(N+E)
        // SC -> O(N+E) + O(N) + O(N)
        private static bool checkForCycle_DFS(int node, int[] vis, int[] dfsVis, List<List<int>> adj)
        {
            vis[node] = 1;
            dfsVis[node] = 1;

            foreach (int it in adj[node])
            {
                if (vis[it] == 0)
                {
                    if (checkForCycle_DFS(it, vis, dfsVis, adj)) return true;
                }
                else if (dfsVis[it] == 1) return true;
            }

            dfsVis[node] = 0;
            return false;
        }

        public static bool isCycle_DFS(int V, List<List<int>> adj)
        {
            // 0 based indexing
            int[] vis = new int[V];
            int[] dfsVis = new int[V];

            for (int i = 0; i < V; i++)
            {
                if (vis[i] == 0)
                {
                    if (checkForCycle_DFS(i, vis, dfsVis, adj)) return true;
                }
            }
            return false;
        }
    }
}
