using System;

namespace CN_Count_Distinct_Substrings
{
    public class Node
    {
        Node[] links = new Node[26];

        public Node() { }

        public bool containsKey(char ch)
        {
            return (links[ch - 'a'] != null);
        }

        public void put(char ch, Node node)
        {
            links[ch - 'a'] = node;
        }

        public Node get(char ch)
        {
            return links[ch - 'a'];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Count_Distinct_Substrings");
            Console.WriteLine($"count of distinct substring is {countDistinctSubstrings("abab")}");
        }

        public static int countDistinctSubstrings(string s)
        {
            //	  Write your code here.
            int n = s.Length;
            Node root = new Node();
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                Node node = root;
                for (int j = i; j < n; j++)
                {
                    if (!node.containsKey(s[j]))
                    {
                        count++;
                        node.put(s[j], new Node());
                    }
                    node = node.get(s[j]);
                }
            }
            return count + 1;
        }
    }
}
