using System;

namespace _876._Middle_of_the_Linked_List
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("876. Middle of the Linked List");
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

        // TC -> O(N/2)
        // SC -> O(1)
        public static ListNode MiddleNode(ListNode head)
        {
            ListNode slow = head, fast = head;
            while(fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            return slow;
        }
    }
}
