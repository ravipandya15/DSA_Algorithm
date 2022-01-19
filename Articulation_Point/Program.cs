using System;
using System.Collections.Generic;

namespace Articulation_Point
{

    class Main
    {
        // doubt
        // timer starts with 0 and as per dry run it should start from 1
        // hear we are passing timer but it should be as reference -> not necessory but in C++ Code it's used as ref
        private static void dfs(int node, int parent, int[] visited, int[] tin, int[] low, 
                                ref int timer, List<List<int>> adj, int[] isArticulation)
        {
            visited[node] = 1;
            tin[node] = low[node] = timer++;

            int child = 0;

            foreach (int it in adj[node])
            {
                if (it == parent) continue;

                if (visited[it] == 0)
                {
                    dfs(it, node, visited, tin, low, ref timer, adj, isArticulation);
                    low[node] = Math.Min(low[node], low[it]);

                    child++;

                    if (low[it] >= tin[node] && parent != -1)
                    {
                        isArticulation[node] = 1;
                    }
                }
                else
                {
                    low[node] = Math.Min(low[node], tin[it]);
                }
            }

            if (child > 1 && parent == -1)
            {
                isArticulation[node] = 1;
            }
        }
        public void findArticulationPoint(int N, List<List<int>> adj)
        {
            int[] visited = new int[N];
            int[] tin = new int[N];
            int[] low = new int[N];

            int[] isArticulation = new int[N];

            int timer = 0;
            for (int i = 0; i < N; i++)
            {
                if (visited[i] == 0)
                {
                    dfs(i, -1, visited, tin, low, ref timer, adj, isArticulation);
                }
            }

            for (int i = 0; i < N; i++)
            {
                if (isArticulation[i] == 1) Console.WriteLine(i);
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Articulation_Point");
            int N = 5;
            List<List<int>> adj = new List<List<int>>();

            for (int i = 0; i < N; i++)
                adj.Add(new List<int>());


            adj[0].Add(1);
            adj[1].Add(0);

            adj[0].Add(2);
            adj[2].Add(0);

            adj[1].Add(2);
            adj[2].Add(1);

            adj[1].Add(3);
            adj[3].Add(1);

            adj[3].Add(4);
            adj[4].Add(3);
            Main obj = new Main();
            obj.findArticulationPoint(N, adj);
        }
    }
}
