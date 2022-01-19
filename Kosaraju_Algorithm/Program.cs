using System;
using System.Collections.Generic;

namespace Kosaraju_Algorithm
{
    class Main
    {

        private static void dfs(int node, int[] visited, Stack<int> st, List<List<int>> adj)
        {
            visited[node] = 1;

            foreach (int it in adj[node])
            {
                if (visited[it] == 0)
                {
                    dfs(it, visited, st, adj);
                }
            }

            st.Push(node);
        }

        private static void revDfs(int node, int[] visited, List<List<int>> transpose)
        {
            Console.Write(node + " ");
            visited[node] = 1;

            foreach (int it in transpose[node])
            {
                if (visited[it] == 0)
                {
                    revDfs(it, visited, transpose);
                }
            }

        }

        public void kosaRaju(int N, List<List<int>> adj)
        {
            int[] visited = new int[N];
            Stack<int> st = new Stack<int>();

            // step 1
            // topological sort
            for (int i = 0; i < N; i++)
            {
                if (visited[i] == 0)
                {
                    dfs(i, visited, st, adj);
                }
            }

            // step 2
            // transpose Graph
            // i->j to j->i

            List<List<int>> transpose = new List<List<int>>();

            for (int i = 0; i < N; i++)
            {
                transpose.Add(new List<int>());
            }

            for (int i = 0; i < N; i++)
            {
                visited[i] = 0;
                foreach (int it in adj[i])
                {
                    transpose[it].Add(i);
                }
            }

            // step 3
            // dfs on Transpose

            while (st.Count > 0)
            {
                int node = st.Peek();
                st.Pop();

                if (visited[node] == 0)
                {
                    Console.Write(" SSC : ");
                    revDfs(node, visited, transpose);
                    Console.WriteLine();
                }
            }

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kosaraju_Algorithm");
            int n = 5;
            List<List<int>> adj = new List<List<int>>();

            for (int i = 0; i < n; i++)
                adj.Add(new List<int>());

            adj[0].Add(1);
            adj[1].Add(2);
            adj[2].Add(0);
            adj[1].Add(3);
            adj[3].Add(4);


            Main obj = new Main();
            obj.kosaRaju(n, adj);
        }


    }
}
