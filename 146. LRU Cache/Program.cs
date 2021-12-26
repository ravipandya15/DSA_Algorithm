using System;
using System.Collections.Generic;

namespace _146._LRU_Cache
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("146. LRU Cache");
            //Your LRUCache object will be instantiated and called as such:
            int capacity = 3;
            LRUCache obj = new LRUCache(capacity);
            obj.Put(1, 10);
            obj.Put(3, 15);
            obj.Put(2, 10);
            obj.Get(3);
            obj.Put(4, 20);
            obj.Get(2);
            obj.Put(4, 25);
            obj.Get(6);
            Console.ReadLine();
        }

        public class LRUCache
        {
            Node head = new Node(0,0), tail = new Node(0,0);
            Dictionary<int, Node> map = new Dictionary<int, Node>();
            int capacity;

            public class Node
            {
                public Node next, prev;
                public int key, value;
                public Node(int _key, int _value)
                {
                    key = _key;
                    value = _value;
                }
            }

            public LRUCache(int _capacity)
            {
                capacity = _capacity;
                head.next = tail;
                tail.prev = head;
            }

            public void Insert(Node node)
            {
                map.Add(node.key, node);
                Node headNext = head.next;
                node.prev = head;
                head.next = node;
                node.next = headNext;
                headNext.prev = node;
            }

            public void Remove(Node node)
            {
                map.Remove(node.key);
                node.prev.next = node.next;
                node.next.prev = node.prev;
            }

            public int Get(int key)
            {
                if (map.ContainsKey(key))
                {
                    Node node = map[key];
                    Remove(node);
                    Insert(node);
                    return node.value;
                }
                else
                    return -1;
            }

            public void Put(int key, int value)
            {
                if (map.ContainsKey(key))
                {
                    Remove(map[key]);
                }
                if (map.Count == capacity)
                {
                    Remove(tail.prev);
                }

                Insert(new Node(key, value));
            }
        }
    }
}
