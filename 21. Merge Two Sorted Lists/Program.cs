using System;

namespace _21._Merge_Two_Sorted_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("21. Merge Two Sorted Lists");
            ListNode node6 = new ListNode(6, null);
            ListNode node4 = new ListNode(4, node6);
            ListNode head2 = new ListNode(2, node4);
            ListNode node5 = new ListNode(5, null);
            ListNode node3 = new ListNode(3, node5);
            ListNode head1 = new ListNode(1, node3);

            ListNode ans = MergeTwoLists(head1, head2);
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

        // TC -> O(n1 + n2)
        // SC -> O(1)
        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            // another code is below for same TC and same SC
            if (l1 == null) return l2;
            if (l2 == null) return l1;

            if (l2.val < l1.val)
            {
                // swap
                ListNode temp = l1;
                l1 = l2;
                l2 = temp;
            }

            ListNode resultNode = l1;

            ListNode tmp = null;

            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    tmp = l1;
                    l1 = l1.next;
                }
                else
                {
                    tmp.next = l2;
                    // swap
                    ListNode temp = l1;
                    l1 = l2;
                    l2 = temp;

                    tmp = null;
                }
            }

            tmp.next = l2;

            return resultNode;
        }

        public static ListNode MergeTwoLists2(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;

            if (l2.val < l1.val)
            {
                // swap
                ListNode temp = l1;
                l1 = l2;
                l2 = temp;
            }

            ListNode resultNode = l1;

            

            while (l1 != null && l2 != null)
            {
                ListNode tmp = null;
                while (l1 != null && l1.val <= l2.val)
                {
                    tmp = l1;
                    l1 = l1.next;
                }

                tmp.next = l2;

                //swap
                ListNode temp = l1;
                l1 = l2;
                l2 = temp;
            }

            return resultNode;
        }


        // TC -> O(n1 + n2)
        // SC -> O(n1 + n2)
        public static ListNode MergeTwoLists1(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;

            ListNode dummy = new ListNode(0, null);
            ListNode dummyTemp = dummy;

            while (l1 != null && l2 != null)
            {
                ListNode temp = null;
                if (l1.val <= l2.val)
                {
                    temp = new ListNode(l1.val, null);
                    l1 = l1.next;
                }
                else
                {
                    temp = new ListNode(l2.val, null);
                    l2 = l2.next;
                }
                dummyTemp.next = temp;
                dummyTemp = temp;
            }

            while (l1 != null)
            {
                ListNode temp = new ListNode(l1.val, null);
                dummyTemp.next = temp;
                dummyTemp = temp;
                l1 = l1.next;
            }

            while (l2 != null)
            {
                ListNode temp = new ListNode(l2.val, null);
                dummyTemp.next = temp;
                dummyTemp = temp;
                l2 = l2.next;
            }

            return dummy.next;
        }
    }
}
