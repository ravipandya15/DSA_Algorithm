using System;

namespace Disjoint_Set_Union_By_Rank_And_Path_Compression
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Disjoint_Set_Union_By_Rank_And_Path_Compression");
            int m = 5;
            int[] parent = new int[100000];
            int[] rank = new int[100000];
            makeSet(m, parent, rank);
            
            while (m-- > 0)
            {
                int u, v;
                u = Convert.ToInt32(Console.ReadLine());
                v = Convert.ToInt32(Console.ReadLine());

                Union(u, v, parent, rank);
            }
            
            // if 2 and 3 belongs to same component or not
            if (findParent(2, parent) != findParent(2, parent))
            {
                Console.WriteLine("diff. component");
            }
            else
            {
                Console.WriteLine("Same component");
            }
        }

        public static void makeSet(int size, int[] parent, int[] rank)
        {
            for (int i = 0; i < size; i++)
            {
                parent[i] = i;
                rank[i] = 0;
            }
        }

        // compression 7 -> 6 -> 5 -> 4 -> 3
        public static int findParent(int node, int[] parent)
        {
            if (node == parent[node])
            {
                return node;
            }

            // storing in parent[node] is path compression 
            return parent[node] = findParent(parent[node], parent);

            // or we can write like this
            //parent[node] = findParent(parent[node], parent);
            //return parent[node];
        }

        public static void Union(int u, int v, int[] parent, int[] rank)
        {
            int i = findParent(u, parent);
            int j = findParent(v, parent);

            // if both i and i are in same set
            if (i == j) return;

            if (rank[i] < rank[j])
            {
                parent[i] = j;
            }
            else if (rank[j] < rank[i])
            {
                parent[j] = i;
            }
            else
            {// means rank of i and j are same
                parent[j] = i;
                rank[i]++;
            }
        }
    }
}
