using System;

namespace _142._Linked_List_Cycle_II
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("142. Linked List Cycle II");
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
        public static ListNode DetectCycle(ListNode head)
        {
            if (head == null || head.next == null)
                return null;

            ListNode slow = head;
            ListNode fast = head;
            ListNode entry = head;

            while (fast.next != null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;

                if (slow == fast)   // cycle detected
                {
                    while (entry != slow) // return entry when both becomes same
                    {
                        slow = slow.next;
                        entry = entry.next;
                    }
                    return entry;
                }
            }

            return null;
        }
    }
}
