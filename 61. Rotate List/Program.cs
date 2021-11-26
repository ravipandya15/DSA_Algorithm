using System;

namespace _61._Rotate_List
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("61. Rotate List");
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

        public static ListNode RotateRight(ListNode head, int k)
        {
            // edge case
            if (head == null || head.next == null || k == 0)
                return head;

            // compute the length
            ListNode current = head;
            int len = 1;
            while (current.next != null)
            {
                len++;
                current = current.next;
            }

            // go till that node
            current.next = head;
            k = k % len;
            k = len - k;

            while (k > 0)
            {
                current = current.next;
                k--;
            }

            // make the node head and break connection
            head = current.next;
            current.next = null;

            return head;
        }
    }
}
