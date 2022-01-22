using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CN_Max_Xor_Queries
{
    class Node
    {
        Node[] links = new Node[2];

        public bool containesKey(int bit)
        {
            return (links[bit] != null);
        }

        public Node get(int bit)
        {
            return links[bit];
        }

        public void put(int bit, Node node)
        {
            links[bit] = node;
        }
    }

    class Trie
    {
        private Node root;

        public Trie()
        {
            root = new Node();
        }

        public void insert(int num)
        {
            Node node = root;
            for (int i = 31; i >= 0; i--)
            {
                int bit = (num >> i) & 1;
                if (!node.containesKey(bit))
                {
                    node.put(bit, new Node());
                }
                node = node.get(bit);
            }
        }

        public int getMax(int num)
        {
            Node node = root;
            int max = 0;
            for (int i = 31; i >= 0; i--)
            {
                int bit = (num >> i) & 1;
                if (node.containesKey(1 - bit))
                {
                    max = max | (1 << i);
                    node = node.get(1 - bit);
                }
                else
                {
                    node = node.get(bit);
                }
            }
            return max;
        }
    }

    public class QueriesComparer : IComparer<List<int>>
    {
        public int Compare(List<int> x, List<int> y)
        {
            return x[0].CompareTo(y[0]);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Max_Xor_Queries");
            List<int> arr = new List<int>() { 0, 1, 2, 3, 4 };
            List<List<int>> queries = new List<List<int>>()
            {
                new List<int> {1,3},
                new List<int> {5,6}
            };
            var result = maxXorQueries(arr, queries);
        }

        public static List<int> maxXorQueries(List<int> arr, List<List<int>> queries)
        {
            // Write your code here.
            arr.Sort();
            List<List<int>> offlineQueries = new List<List<int>>();
            int m = queries.Count;

            for (int i = 0; i < m; i++)
            {
                List<int> temp = new List<int>();
                temp.Add(queries[i][1]);
                temp.Add(queries[i][0]);
                temp.Add(i);

                offlineQueries.Add(temp);
            }

            offlineQueries.Sort(new QueriesComparer());

            int index = 0;
            int n = arr.Count;
            List<int> ans = new List<int>(m);

            Trie trie = new Trie();

            // below line is required as ans.set will replace value with old value.
            for (int i = 0; i < m; i++) ans.Add(-1);

            for (int i = 0; i < m; i++)
            {
                while (index < n && arr[index] <= offlineQueries[i][0])
                {
                    trie.insert(arr[index]);
                    index++;
                }

                int queryIndex = offlineQueries[i][2];
                if (index != 0)
                {
                    ans[queryIndex] = trie.getMax(offlineQueries[i][1]);
                }
                else
                {
                    ans[queryIndex] = -1;
                }
            }

            return ans;
        }

    }
}
