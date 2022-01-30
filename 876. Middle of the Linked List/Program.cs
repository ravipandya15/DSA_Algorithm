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
            // returns 2nd middle Node is even linkedList
            ListNode slow = head, fast = head;
            while(fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            return slow;
        }

        // TC -> O(N) + O(N/2)
        public static ListNode MiddleNode1(ListNode head)
        {
            // returns 2nd middle node in even linkedList
            if (head == null) return null;
            ListNode temp = head;
            int length = 0;
            while (temp != null)
            {
                length++;
                temp = temp.next;
            }

            length = length / 2;
            int count = 0;
            temp = head;

            while (count < length)
            {
                temp = temp.next;
                count++;
            }

            return temp;
        }
    }
}
