using System;

namespace _92._Reverse_Linked_List_II
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("92. Reverse Linked List II");
            //ListNode node10 = new ListNode(10);
            //ListNode node9 = new ListNode(9, node10);
            //ListNode node8 = new ListNode(8, node9);
            //ListNode node7 = new ListNode(7, node8);
            //ListNode node6 = new ListNode(6, node7);
            //ListNode node5 = new ListNode(5, node6);
            //ListNode node4 = new ListNode(4, node5);
            //ListNode node3 = new ListNode(3, node4);
            //ListNode node2 = new ListNode(2, node3);
            //ListNode head = new ListNode(1, node2);

            //ListNode head = new ListNode(5, null);

            ListNode node2 = new ListNode(5, null);
            ListNode head = new ListNode(3, node2);

            ListNode ans = ReverseBetween(head, 1, 2);
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

        // TC -> O(N) + O(N) + O(N) = O(3N)
        // SC -> O(1)
        public static ListNode ReverseBetween(ListNode head, int left, int right)
        {
            ListNode prevNode = null, leftNode = head, rightNode = head;
            int loopCount = right - left, flag = 0;
            for (int i = 0; i < left - 1; i++)
            {
                prevNode = leftNode;
                leftNode = leftNode.next;
            }

            for (int i = 0; i < right - 1; i++)
            {
                rightNode = rightNode.next;
            }

            if (prevNode != null)
                prevNode.next = rightNode;
            else
                flag = 1;

            prevNode = rightNode.next;

            while (loopCount >= 0)
            {
                ListNode next = leftNode.next;
                leftNode.next = prevNode;
                prevNode = leftNode;
                leftNode = next;
                loopCount--;
            }

            if (flag == 1)
                head = prevNode;

            return head;
        }
    }
}
