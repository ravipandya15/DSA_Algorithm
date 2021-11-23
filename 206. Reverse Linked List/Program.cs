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

        public static ListNode ReverseList(ListNode head)
        {
            ListNode newNode = null;
            
            while(head != null)
            {
                ListNode next = head.next;
                head.next = newNode;
                newNode = head;
                head = next;
            }

            return newNode;
        }
    }
}
