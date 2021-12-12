using System;

namespace M_Coloring_Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("M-Coloring Problem");
            int m = 3;
            int v = 4;
            int[,] graph = new int[,]
            {
                { 0, 1, 1, 1},
                { 1, 0, 1, 1},
                { 1, 1, 0, 0},
                { 1, 1, 0, 0}
            };
            Console.WriteLine($"Is possible to with {m} colors ? - {GraphColoring(graph, m, v)}");
            Console.ReadLine();
        }

        public static bool IsPossible(int node, int[] color, int[,] graph, int n, int col)
        {
            for (int i = 0; i < n; i++) // check for all nodes
            {
                if (i != node && graph[node,i] == 1 && color[i] == col)
                    return false;
            }
            return true;
        }

        public static bool Solve(int node, int[] color, int[,] graph, int m, int n)
        {
            if (node == n)
                return true;

            for (int i = 1; i <= m; i++) // try all colors
            {
                if (IsPossible(node, color, graph, n, i))
                {
                    color[node] = i;
                    if (Solve(node + 1, color, graph, m, n))
                        return true;
                    color[node] = 0; // backtracking step
                }
            }
            return false; // as I check all color but not possible for any color.
        }

        public static bool GraphColoring(int[,] graph, int m, int v)
        {
            int[] color = new int[v];
            if (Solve(0, color, graph, m, v)) 
                return true;
            return false;
        }
    }
}
