using System;

namespace CN_Implement_Trie_ll
{
    public class Node
    {
        Node[] links = new Node[26];
        int countEndWith = 0;
        int countPrefix = 0;

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

        public void increaseEndWith()
        {
            countEndWith++;
        }

        public void increasePrefix()
        {
            countPrefix++;
        }

        public void decreaseEndWith()
        {
            countEndWith--;
        }

        public void decreasePrefix()
        {
            countPrefix--;
        }

        public int getEnd()
        {
            return countEndWith;
        }

        public int getPrefix()
        {
            return countPrefix;
        }
    }

    class Trie
    {
        private Node root;
        public Trie()
        {
            // Write your code here.
            root = new Node();
        }

        public void insert(string word)
        {
            // Write your code here.
            Node node = root;
            for (int i = 0; i < word.Length; i++)
            {
                if (!node.containsKey(word[i]))
                {
                    node.put(word[i], new Node());
                }
                node = node.get(word[i]);
                node.increasePrefix();
            }

            node.increaseEndWith();
        }

        public int countWordsEqualTo(string word)
        {
            // Write your code here.
            Node node = root;
            for (int i = 0; i < word.Length; i++)
            {
                if (node.containsKey(word[i]))
                {
                    node = node.get(word[i]);
                }
                else
                    return 0;
            }
            return node.getEnd();
        }

        public int countWordsStartingWith(string word)
        {
            // Write your code here.
            Node node = root;
            for (int i = 0; i < word.Length; i++)
            {
                if (node.containsKey(word[i]))
                {
                    node = node.get(word[i]);
                }
                else
                    return 0;
            }
            return node.getPrefix();
        }

        public void erase(string word)
        {
            // Write your code here.
            Node node = root;
            for (int i = 0; i < word.Length; i++)
            {
                if (!node.containsKey(word[i]))
                {
                    node.put(word[i], new Node());
                }
                node = node.get(word[i]);
                node.decreasePrefix();
            }

            node.decreaseEndWith();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Implement_Trie_ll");
        }
    }
}
