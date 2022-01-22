using System;
using System.Collections.Generic;

namespace CN_Maximum_XOR
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

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Maximum_XOR");
            List<int> arr1 = new List<int>() { 6, 8 };
            List<int> arr2 = new List<int>() { 7, 8, 2 };
            Console.WriteLine($"maximun XOR of arr1 and arr2 is {maxXOR(2, 3, arr1, arr2)}");
        }

        public static int maxXOR(int n, int m, List<int> arr1, List<int> arr2)
        {
            // Write your code here.  
            Trie trie = new Trie();
            foreach (int it in arr1)
            {
                trie.insert(it);
            }

            int max = 0;
            foreach (int it in arr2)
            {
                max = Math.Max(max, trie.getMax(it));
            }
            return max;
        }

    }
}
