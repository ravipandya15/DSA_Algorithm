using System;
using System.Collections.Generic;

namespace Topological_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Topological Sorting usinf DFS and BFS(Kahn's Algorithm)");
        }

        // DFS
        // TC -> O(N + E)
        // SC -> O(N+E) + O(N) + O(N) + O(N)
        private static void findTopoSort(int node, Stack<int> st, int[] visited, List<List<int>> adj)
        {
            visited[node] = 1;

            foreach (int it in adj[node])
            {
                if (visited[it] == 0)
                {
                    findTopoSort(it, st, visited, adj);
                }
            }

            st.Push(node);
        }

        public static int[] topoSort1(int V, List<List<int>> adj)
        {
            Stack<int> st = new Stack<int>();
            int[] visited = new int[V]; // considering 0 based indexing

            for (int i = 0; i < V; i++)
            {
                if (visited[i] == 0)
                {
                    findTopoSort(i, st, visited, adj);
                }
            }

            int[] ans = new int[V];
            int index = 0;
            while (st.Count > 0)
            {
                ans[index++] = st.Peek();
                st.Pop();
            }

            return ans;
        }

        // Kahn's Algorithm
        // BFS
        // TC -> O(N + E)
        // SC -> O(N+E) + O(N) + O(N) + O(N) 
        public static int[] topoSort(int V, List<List<int>> adj)
        {
            int[] indegree = new int[V];
            for (int i = 0; i < V; i++)
            {
                foreach (int it in adj[i])
                {
                    indegree[it]++;
                }
            }

            Queue<int> q = new Queue<int>();
            for (int i = 0; i < V; i++)
            {
                if (indegree[i] == 0)
                {
                    q.Enqueue(i);
                }
            }

            int[] ans = new int[V];
            int index = 0;
            while (q.Count > 0)
            {
                int node = q.Peek();
                ans[index++] = node;
                q.Dequeue();

                foreach (int it in adj[node])
                {
                    indegree[it]--;
                    if (indegree[it] == 0)
                    {
                        q.Enqueue(it);
                    }
                }
            }

            return ans;
        }
    }
}
