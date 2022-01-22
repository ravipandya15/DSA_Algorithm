using System;

namespace CN__Implement_Trie
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

    class Trie
    {

        private static Node root;

        //Initialize your data structure here

        Trie()
        {
            root = new Node();
        }


        //Inserts a word into the trie

        public static void insert(String word)
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


        //Returns if the word is in the trie

        public static bool search(String word)
        {
            //Write your code here
            Node node = root;
            for (int i = 0; i < word.Length; i++)
            {
                if (!node.containsKey(word[i]))
                {
                    return false;
                }

                node = node.get(word[i]);
            }

            return node.isEnd();
        }


        //Returns if there is any word in the trie that starts with the given prefix

        public static bool startsWith(String prefix)
        {
            //Write your code here
            Node node = root;
            for (int i = 0; i < prefix.Length; i++)
            {
                if (!node.containsKey(prefix[i]))
                {
                    return false;
                }

                node = node.get(prefix[i]);
            }

            return true;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Implement Trie");
        }
    }
}
