using System;
using System.Collections.Generic;

namespace BFS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("BFS");
        }

        public static List<int> BFS(int V, List<List<int>> adj)
        {
            List<int> bfs = new List<int>();
            bool[] visited = new bool[V + 1];

            // loop for every component
            for (int i = 1; i <= V; i++)
            {
                if (visited[i] == false)
                {

                    // bfs
                    Queue<int> q = new Queue<int>();
                    q.Enqueue(i);
                    visited[i] = true;

                    while (q.Count > 0)
                    {
                        int node = q.Peek();
                        q.Dequeue();
                        bfs.Add(node);

                        foreach (int it in adj[node])
                        {
                            if (!visited[it])
                            {
                                q.Enqueue(it);
                                visited[it] = true;
                            }
                        }
                    }

                }
            }

            return bfs;
        }
    }

    
}
