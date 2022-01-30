using System;

namespace _206._Reverse_Linked_List
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("206. Reverse Linked List");
            ListNode node5  = new ListNode(5);
            ListNode node4 = new ListNode(4, node5);
            ListNode node3 = new ListNode(3, node4);
            ListNode node2 = new ListNode(2, node3);
            ListNode head = new ListNode(1, node2);

            ListNode ans = ReverseList(head);
            Console.WriteLine($"Answer is {ans.val}");
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

        // TC -> O(N)
        // SC -> O(1)
        public static ListNode ReverseList(ListNode head)
        {
            ListNode prev = null;
            ListNode cur = head;

            while (cur != null)
            {
                ListNode next = cur.next;
                cur.next = prev;
                prev = cur;
                cur = next;
            }

            return prev;
        }

        // TC -> O(N)
        // SC -> O(N)
        public static ListNode Reverse1(ListNode head)
        {
            if (head == null || head.next == null) return head;

            ListNode smallHead = Reverse1(head.next);
            head.next.next = head;
            head.next = null;

            return smallHead;
        }

        public static void Reverse(ref ListNode head, ListNode cur, ListNode prev)
        {
            // base case
            if (cur == null)
            {
                head = prev;
                return;
            }

            ListNode next = cur.next;
            Reverse(ref head, next, cur);
            cur.next = prev;
        }

        // TC -> O(N)
        // SC -> O(N)
        public static ListNode ReverseList1(ListNode head)
        {
            ListNode prev = null;
            ListNode cur = head;

            Reverse(ref head, ref cur, ref prev);
            return prev;
        }
    }
}
