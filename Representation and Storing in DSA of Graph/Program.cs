using System;
using System.Collections.Generic;

namespace Representation_and_Storing_in_DSA_of_Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int n = 3;
            int m = 3;


            // 1st way -> using Adjecency Matrix
            int[,] adj = new int[n + 1, n + 1];


            adj[1, 3] = 1;
            adj[2, 1] = 1;

            // 2nd way -> using Adjecency List
            List<List<int>> adjList = new List<List<int>>();

            for (int i = 0; i <= n; i++)
            {
                adjList.Add(new List<int>());
            }

            // adge 1-->2
            adjList[1].Add(2);
            adjList[2].Add(1);

            // 2--> 3
            adjList[2].Add(3);
            adjList[3].Add(2);


            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j < adjList[i].Count; j++)
                {
                    Console.WriteLine(adjList[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
