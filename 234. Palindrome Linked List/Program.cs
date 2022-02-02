using System;

namespace _234._Palindrome_Linked_List
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("234. Palindrome Linked List");

            ListNode node6 = new ListNode(1, null);
            ListNode node5 = new ListNode(2, node6);
            //ListNode node4 = new ListNode(3, node5);
            ListNode node3 = new ListNode(3, node5);
            ListNode node2 = new ListNode(2, node3);
            ListNode head = new ListNode(1, node2);

            Console.WriteLine($"Answer is {IsPalindrome(head)}");
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

        public static ListNode findMiddleNode(ListNode head)
        {
            ListNode slow = head, fast = head;
            while (fast.next != null && fast.next.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }

            return slow;

        }

        public static ListNode ReverseList(ListNode head)
        {
            ListNode newNode = null;

            while (head != null)
            {
                ListNode next = head.next;
                head.next = newNode;
                newNode = head;
                head = next;
            }
            return newNode;
        }

        public static bool IsPalindrome(ListNode head)
        {
            if (head == null || head.next == null)
                return true;

            ListNode middle = findMiddleNode(head);
            middle.next = ReverseList(middle.next);

            middle = middle.next;

            while (middle != null)
            {
                if (head.val != middle.val)
                    return false;

                head = head.next;
                middle = middle.next;
            }

            return true;
        }
    }
}
