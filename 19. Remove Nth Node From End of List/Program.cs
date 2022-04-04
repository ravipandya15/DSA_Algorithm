using System;

namespace _19._Remove_Nth_Node_From_End_of_List
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("19. Remove Nth Node From End of List");

            ListNode node6 = new ListNode(6, null);
            ListNode node5 = new ListNode(5, node6);
            ListNode node4 = new ListNode(3, node5);
            ListNode node3 = new ListNode(1, node4);
            ListNode node2 = new ListNode(4, node3);
            ListNode head = new ListNode(2, node2);

            ListNode ans = RemoveNthFromEnd(head, 5);

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
        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode dummy = new ListNode();
            dummy.next = head;
            ListNode slow = dummy;
            ListNode fast = dummy;

            for (int i = 0; i < n; i++)
            {
                fast = fast.next;
            }

            while (fast.next != null)
            {
                slow = slow.next;
                fast = fast.next;
            }

            // check is there any function in C# to delete (free space) node
            //delete(slow.next);
            slow.next = slow.next.next;

            return dummy.next;
        }
    }
}
