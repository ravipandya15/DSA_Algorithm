using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace LinkedList_Cycle
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x)
        {
            val = x;
            next = null;
        }
    }
    class Program
    {
        // program to check if linked list contains cycle or not.
        ListNode head; // head of linked list

        public void Push(int new_data)
        {
            ListNode newNode = new ListNode(new_data);
            newNode.next = head;
            head = newNode;
        }

        public void PrintList(ListNode head)
        {
            Console.WriteLine("Printing Linked List");
            while (head != null)
            {
                Console.Write(head.val + "-->");
                head = head.next;
            }
        }

        // using HashSet -> time complexity O(n) , space complexity O(n)
        public bool HasCycle1(ListNode head)
        {
            HashSet<ListNode> nodeSeen = new HashSet<ListNode>();
            while (head != null)
            {
                if (nodeSeen.Contains(head))
                {
                    return true;
                }
                nodeSeen.Add(head);
                head = head.next;
            }
            return false;
        }

        public ListNode HasCycleWithIndex(ListNode head)
        {
            ListNode result = null;
            int index = 0;
            Dictionary<int, ListNode> nodeSeen = new Dictionary<int, ListNode>();
            // if we just want to return node then we can use HashSet instead of Dictionary
            while (head != null)
            {
                if (nodeSeen.ContainsValue(head))
                {
                    result = nodeSeen.FirstOrDefault(x => x.Value == head).Value;
                    return result;
                }
                nodeSeen.Add(index, head);
                head = head.next;
                index++;
            }
            return result;
        }

        public ListNode HasCycleWithHashSet(ListNode head)
        {
            HashSet<ListNode> nodeSeen = new HashSet<ListNode>();
            while (head != null)
            {
                if (nodeSeen.Contains(head))
                {
                    return head;
                }
                nodeSeen.Add(head);
                head = head.next;
            }
            return head; // or NULL as head will become null
        }

        public bool HasCycle(ListNode head)
        {
            if (head == null || head.next == null)
                return false;

            ListNode slow = head;
            ListNode fast = head;

            while (fast.next != null && fast.next.next != null)
            {
                fast = fast.next.next; // as fast.next.next should not be null otherwise will throw null pointer exception
                slow = slow.next;
                if (fast == slow)
                    return true;
            }

            return false;
        }

        // Floyd's Cycle finding algorithm -> time complexity O(n) , space complexity O(1)
        public bool HasCycleUsingFloyd(ListNode head)
        {
            if (head == null)
                return false;

            ListNode slow = head;
            ListNode fast = head.next;
            while (fast != slow)
            {
                if (fast == null || fast.next == null)
                {
                    return false;
                }
                slow = slow.next;
                fast = fast.next.next;
            }
            return true;
        }

        public ListNode ReverseLinkList(ListNode head)
        {
            if (head == null)
            {
                return null;
            }
            ListNode prevNode = null, nextNode = head.next;
            while (head != null)
            {
                head.next = prevNode;
                prevNode = head;
                head = nextNode;
                if (nextNode != null)
                {
                    nextNode = nextNode.next;
                }
            }
            head = prevNode;

            return head;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Program to check cyclic linked list");
            Program linkedList = new Program();
            //linkedList.Push(-4);
            //linkedList.Push(0);
            //linkedList.Push(2);
            //linkedList.Push(3);
            //Console.WriteLine(linkedList.head.val);

            linkedList.PrintList(linkedList.head);
            Console.WriteLine("After Reverse LinkedList : ");
            ListNode reserveHead = linkedList.ReverseLinkList(linkedList.head);
            linkedList.PrintList(reserveHead);
            Console.ReadLine();
        }
    }
}
