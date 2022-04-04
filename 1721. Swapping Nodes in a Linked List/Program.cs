using System;

namespace _1721._Swapping_Nodes_in_a_Linked_List
{
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
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        // also do for swapping Nodes -> InPlace

        // swapping values
        public ListNode SwapNodes(ListNode head, int k)
        {
            if (head == null || head.next == null) return head;

            ListNode cur = head;
            int kk = k;
            while (kk - 1 > 0)
            {
                kk--;
                cur = cur.next;
            }

            ListNode first = cur;
            ListNode last = head;

            while (cur.next != null)
            {
                last = last.next;
                cur = cur.next;
            }
            int temp = first.val;
            first.val = last.val;
            last.val = temp;

            return head;
        }
    }
}
