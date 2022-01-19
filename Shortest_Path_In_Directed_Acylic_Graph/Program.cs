using System;
using System.Collections.Generic;

namespace Shortest_Path_In_Directed_Acylic_Graph
{
    class Pair
    {
        private int v;
        private int weight;
        public Pair(int _v, int _w)
        {
            v = _v;
            weight = _w;
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

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Shortest_Path_In_Directed_Acylic_Graph");
        }

        private static void findTopologicalSort(int node, int[] visited, Stack<int> st, List<List<Pair>> adj)
        {
            visited[node] = 1;

            foreach (Pair it in adj[node])
            {
                if (visited[it.getV()] == 0)
                    findTopologicalSort(it.getV(), visited, st, adj);
            }

            st.Push(node);
        }

        public int[] shortestPathInDAG(int V, int src, List<List<Pair>> adj)
        {
            Stack<int> st = new Stack<int>();
            int[] visited = new int[V];
            for (int i = 0; i < V; i++)
            {
                visited[i] = 0;
            }

            for (int i = 0; i < V; i++)
            {
                if (visited[i] == 0)
                {
                    findTopologicalSort(i, visited, st, adj);
                }
            }

            int[] dist = new int[V];
            for (int i = 0; i < V; i++)
            {
                dist[i] = Int32.MaxValue;
            }

            dist[src] = 0;
            while (st.Count > 0)
            {
                int node = st.Peek();
                st.Pop();

                if (dist[node] != Int32.MaxValue)
                {
                    foreach (Pair it in adj[node])
                    {
                        if (dist[node] + it.getWeight() < dist[it.getV()])
                        {
                            dist[it.getV()] = dist[node] + it.getWeight();
                        }
                    }
                }
            }

            return dist;
        }


    }
}
