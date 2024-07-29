using System;

namespace _GFG___Medium__Flattening_a_Linked_List
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("(GFG - Medium )Flattening a Linked List");

            ListNode bottom3 = new ListNode(30);
            ListNode bottom2 = new ListNode(8, bottom3);
            ListNode bottom1 = new ListNode(7, bottom2);
            ListNode head1 = new ListNode(5, bottom1);

            ListNode bottom4 = new ListNode(20);
            ListNode head2 = new ListNode(10, bottom4);

            ListNode bottom6 = new ListNode(50);
            ListNode bottom5 = new ListNode(22, bottom6);
            ListNode head3 = new ListNode(19, bottom5);

            ListNode bottom9 = new ListNode(45);
            ListNode bottom8 = new ListNode(40, bottom9);
            ListNode bottom7 = new ListNode(35, bottom8);
            ListNode head4 = new ListNode(28, bottom7);

            head1.next = head2;
            head2.next = head3;
            head3.next = head4;

            ListNode result = Flatten(head1);
            Console.ReadLine();
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode bottom;

            public ListNode(int d, ListNode bottom = null, ListNode next = null)
            {
                val = d;
                this.bottom = bottom;
                this.next = next;
            }
        }


        public static ListNode MergeTwoList(ListNode a, ListNode b)
        {
            ListNode temp = new ListNode(0);
            ListNode result = temp;

            while (a != null && b!= null)
            {
                if (a.val < b.val)
                {
                    temp.bottom = a;
                    temp = temp.bottom;
                    a = a.bottom;
                }
                else
                {
                    temp.bottom = b;
                    temp = temp.bottom;
                    b = b.bottom;
                }
            }

            if (a != null)
                temp.bottom = a;
            else
                temp.bottom = b;

            return result.bottom;
        }

        // TC -> O(Sum of nodes)
        // SC -> O(1)
        // having one doubt -> next is still there for some of the nodes
        public static ListNode Flatten(ListNode root)
        {
            if (root == null || root.next == null)
                return root;

            // recur for list in right
            root.next = Flatten(root.next);

            // might need to set root.next = null;
            // ListNode nextNode = root.next;
            // root.next = null;
            // root = MergeTwoList(root, nextNode);

            // now merge
            root = MergeTwoList(root, root.next);

            // return the root
            // it will be in turn merged with it's left
            return root;
        }
    }
}
