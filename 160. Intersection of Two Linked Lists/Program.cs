﻿using System;

namespace _160._Intersection_of_Two_Linked_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("160. Intersection of Two Linked Lists");
            Console.ReadLine();
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public static ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null) return null;

            ListNode a = headA;
            ListNode b = headB;

            while (a != b)
            {
                a = a == null ? headB : a.next;
                b = b == null ? headA : b.next;
            }

            return a;
        }
    }
}
