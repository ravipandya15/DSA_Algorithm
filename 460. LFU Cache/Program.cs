using System;
using System.Collections.Generic;

namespace _460._LFU_Cache
{
    class Program
    {
        // not working
        // https://github.com/striver79/SDESheet/blob/main/LFUCacheJava -> woking solution
        static void Main(string[] args)
        {
            Console.WriteLine("460. LFU Cache");
            int capacity = 3;
            LFUCache lfu = new LFUCache(capacity);
            lfu.Put(1, 10);
            lfu.Put(2, 20);
            lfu.Put(3, 30);
            lfu.Put(4, 40);
            int o1 = lfu.Get(3);
            int o2 = lfu.Get(2);
            int o3 = lfu.Get(4);
            lfu.Put(5, 50);
            lfu.Put(2, 25);
            Console.ReadLine();
        }

        public class LFUCache
        {
            int capacity;
            int minFrequencey;
            int curSize;
            Dictionary<int, DLLNode> cache = new Dictionary<int, DLLNode>();
            Dictionary<int, DoubleLinkedList> frequenceMap = new Dictionary<int, DoubleLinkedList>();

            public class DLLNode
            {
                public DLLNode next, prev;
                public int key, value;
                public int frequency;
                public DLLNode(int _key, int _value)
                {
                    key = _key;
                    value = _value;
                    frequency = 1;
                }
            }
            public LFUCache(int _capacity)
            {
                capacity = _capacity;
                curSize = 0;
                minFrequencey = 0;
            }

            public int Get(int key)
            {
                DLLNode curNode;
                if (cache.ContainsKey(key))
                {
                    curNode = cache[key];
                }
                else
                    return -1;

                UpdateNode(curNode);
                return curNode.value;
            }

            public void Put(int key, int value)
            {
                // corner case: check cache capacity initialization
                if (capacity == 0)
                    return;

                if (cache.ContainsKey(key))
                {
                    DLLNode curNode = cache[key];
                    curNode.value = value;
                    UpdateNode(curNode);
                }
                else
                {
                    curSize++;
                    if (curSize > capacity)
                    {
                        // get minimum frequency list
                        DoubleLinkedList minFreList = frequenceMap[minFrequencey];
                        cache.Remove(minFreList.tail.prev.key);
                        minFreList.Remove(minFreList.tail.prev);
                        curSize--;
                    }

                    // reset min frequency to 1 because of adding new node
                    minFrequencey = 1;
                    DLLNode newNode = new DLLNode(key, value);

                    
                    // get the list with frequency 1, and then add new node into the list, as well as into LFU cache
                    if (frequenceMap.TryGetValue(1, out DoubleLinkedList temp))
                    {
                        temp.Insert(newNode);
                        frequenceMap[1] = temp;
                    }
                    else
                    {
                        DoubleLinkedList newList = new DoubleLinkedList();
                        newList.Insert(newNode);
                        frequenceMap.Add(1, newList);
                    }

                    cache.Add(key, newNode);
                }
            }

            public void UpdateNode(DLLNode curNode)
            {
                int curFrequency = curNode.frequency;
                DoubleLinkedList curList = frequenceMap[curFrequency];
                curList.Remove(curNode);

                // if current list the the last list which has lowest frequency and current node is the only node in that list
                // we need to remove the entire list and then increase min frequency value by 1
                if (curFrequency == minFrequencey && curList.listSize == 0)
                {
                    minFrequencey++;
                }

                curNode.frequency++;
                // add current node to another list has current frequency + 1,
                // if we do not have the list with this frequency, initialize it
                DoubleLinkedList newList = new DoubleLinkedList();
                if (frequenceMap.TryGetValue(curNode.frequency, out DoubleLinkedList temp))
                {
                    temp.Insert(curNode);
                    frequenceMap[curNode.frequency] = temp;
                }
                else
                {
                    newList.Insert(curNode);
                    frequenceMap.Add(curNode.frequency, newList);
                }
            }

            class DoubleLinkedList
            {
                public DLLNode head = new DLLNode(0, 0), tail = new DLLNode(0, 0);
                public int listSize;

                public DoubleLinkedList()
                {
                    listSize = 0;
                    head.next = tail;
                    tail.prev = head;
                }

                public void Insert(DLLNode node)
                {
                    DLLNode headNext = head.next;
                    node.prev = head;
                    head.next = node;
                    node.next = headNext;
                    headNext.prev = node;
                    listSize++;
                }

                public void Remove(DLLNode node)
                {
                    node.prev.next = node.next;
                    node.next.prev = node.prev;
                    listSize--;
                }
            }
        }
    }
}
