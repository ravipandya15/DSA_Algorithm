using System;
using System.Collections.Generic;

namespace CN_Remove_Duplicates_From_Unsorted_Linked_List
{
    public class LinkedListNode<T>
    {
        public T data;
        public LinkedListNode<T> next;

        public LinkedListNode(T data)
        {
            this.data = data;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Remove_Duplicates_From_Unsorted_Linked_List");
            LinkedListNode<int> head = new LinkedListNode<int>(4);
            LinkedListNode<int> node2 = new LinkedListNode<int>(2);
            LinkedListNode<int> node3 = new LinkedListNode<int>(5);
            LinkedListNode<int> node4 = new LinkedListNode<int>(4);
            LinkedListNode<int> node5 = new LinkedListNode<int>(2);
            LinkedListNode<int> node6 = new LinkedListNode<int>(2);
            head.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;
            node5.next = node6;

            var result = removeDuplicates(head);
        }

        public static LinkedListNode<int> removeDuplicates(LinkedListNode<int> head)
        {
            if (head == null) return null;
            Dictionary<int, bool> map = new Dictionary<int, bool>();
            LinkedListNode<int> cur = head;
            LinkedListNode<int> prev = null;

            while (cur != null)
            {
                if (map.ContainsKey(cur.data))
                {
                    prev.next = cur.next;
                    LinkedListNode<int> nodeToDelete = cur;
                    cur = cur.next;
                    nodeToDelete.next = null;
                }
                else
                {
                    map.Add(cur.data, true);
                    prev = cur;
                    cur = cur.next;
                }
            }
            return head;
        }
    }
}
