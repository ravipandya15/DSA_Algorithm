using System;
using System.Collections.Generic;

namespace DFS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        private static void DFS(int node, bool[] visited, List<List<int>> adj, List<int> dfs)
        {
            dfs.Add(node);
            visited[node] = true;

            foreach (int it in adj[node])
            {
                if (!visited[it])
                {
                    DFS(it, visited, adj, dfs);
                }
            }
        }

        public static List<int> DFSTravsersal(int V, List<List<int>> adj)
        {
            List<int> dfs = new List<int>();
            bool[] visited = new bool[V + 1];

            for (int i = 1; i <= V; i++)
            {
                if (!visited[i])
                    DFS(i, visited, adj, dfs);
            }

            return dfs;
        }
    }
}
