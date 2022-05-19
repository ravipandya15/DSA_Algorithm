using System;

namespace Reorder_List_143
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Reorder_List_143");
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

        ListNode findMiddle(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head.next;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            return slow;
        }

        ListNode reverseLinkedList(ListNode node)
        {
            ListNode prev = null;
            ListNode curr = node;
            ListNode next = null;

            while (curr != null)
            {
                next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }

            return prev;
        }

        ListNode mergeTwoLinkedList(ListNode head1, ListNode head2)
        {
            if (head1 == null) return head2;
            if (head2 == null) return head1;

            ListNode resultNode = head1;

            // only head2 != null will also work as list2 length is same or 1 less than list1
            while (head1 != null && head2 != null)
            {
                ListNode next1 = head1.next;
                ListNode next2 = head2.next;
                head1.next = head2;
                head2.next = next1;
                head1 = next1;
                head2 = next2;
            }

            return resultNode;
        }

        void reorderList(ListNode head)
        {
            if (head == null) return;

            ListNode middle = findMiddle(head);
            ListNode head2 = middle.next;
            middle.next = null;

            head2 = reverseLinkedList(head2);
            head = mergeTwoLinkedList(head, head2);
        }
    }
}
