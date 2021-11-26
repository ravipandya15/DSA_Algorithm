using System;

namespace _25._Reverse_Nodes_in_k_Group
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("25. Reverse Nodes in k-Group");

            ListNode node8 = new ListNode(8, null);
            ListNode node7 = new ListNode(7, node8);
            ListNode node6 = new ListNode(6, node7);
            ListNode node5 = new ListNode(5, node6);
            ListNode node4 = new ListNode(4, node5);
            ListNode node3 = new ListNode(3, node4);
            ListNode node2 = new ListNode(2, node3);
            ListNode head = new ListNode(1, node2);

            int k = 3;
            ListNode result = ReverseKGroup(head, k); 
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

        public static ListNode ReverseKGroup(ListNode head, int k)
        {
            if (head == null || k == 1)
                return head;

            ListNode dummy = new ListNode(0);
            dummy.next = head;
            ListNode current = dummy, prev = dummy, next = dummy;
            int count = 0;

            while (current.next != null)
            {
                current = current.next;
                count++;
            }

            while (count >= k)
            {
                current = prev.next;
                next = current.next;

                for (int i = 1; i < k; i++) // loop for k-1 times
                {
                    current.next = next.next;
                    next.next = prev.next;
                    prev.next = next; // hear dummy will be updated for 1st iteration
                    next = current.next;
                }

                prev = current;
                count -= k;
            }

            return dummy.next;
        }
    }
}
