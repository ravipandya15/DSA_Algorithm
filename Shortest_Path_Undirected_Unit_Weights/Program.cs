using System;
using System.Collections.Generic;

namespace Shortest_Path_Undirected_Unit_Weights
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Shortest_Path_Undirected_Unit_Weights");
        }

        public void ShortestPath(int N, int src, List<List<int>> adj)
        {
            int[] dist = new int[N];
            for (int i = 0; i < N; i++)
            {
                dist[i] = Int32.MaxValue;
            }

            Queue<int> q = new Queue<int>();
            dist[src] = 0;
            q.Enqueue(src);

            while (q.Count > 0)
            {
                int node = q.Peek();
                q.Dequeue();

                foreach (int it in adj[node])
                {
                    if (dist[node] + 1 < dist[it])
                    {
                        dist[it] = dist[node] + 1;
                        q.Enqueue(it);
                    }
                }
            }

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(dist[i] + " ");
            }
        }
    }
}
