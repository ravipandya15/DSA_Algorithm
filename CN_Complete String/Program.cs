using System;

namespace CN_Complete_string
{
    public class Node
    {
        Node[] links = new Node[26];
        bool flag = false;

        public Node()
        {
        }

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

        public void setEnd()
        {
            flag = true;
        }

        public bool isEnd()
        {
            return flag;
        }
    }

    public class Trie
    {

        private Node root;

        //Initialize your data structure here

        public Trie()
        {
            root = new Node();
        }


        //Inserts a word into the trie

        public void insert(string word)
        {
            Node node = root;
            for (int i = 0; i < word.Length; i++)
            {
                if (!node.containsKey(word[i]))
                {
                    node.put(word[i], new Node());
                }

                node = node.get(word[i]);
            }

            node.setEnd();
        }

        public bool checkIfAllPrefixExists(string word)
        {
            Node node = root;
            for (int i = 0; i < word.Length; i++)
            {
                if (node.containsKey(word[i]))
                {
                    node = node.get(word[i]);
                    if (node.isEnd() == false) return false;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Complete string");
        }

        public static string completestring(int n, string[] a)
        {
            // Write your code here.
            Trie trie = new Trie();
            foreach (string it in a)
            {
                trie.insert(it);
            }

            string longest = "";
            foreach (string it in a)
            {
                if (trie.checkIfAllPrefixExists(it))
                {
                    if (it.Length > longest.Length)
                    {
                        longest = it;
                    }
                    else if (it.Length == longest.Length && it.CompareTo(longest) < 0)
                    {
                        longest = it;
                    }
                }
            }

            if (longest == "") return "None";
            return longest;
        }
    }
}
