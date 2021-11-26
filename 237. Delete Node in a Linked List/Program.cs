using System;

namespace _237._Delete_Node_in_a_Linked_List
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("237. Delete Node in a Linked List");
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

        // TC -> O(1)
        // SC -> O(1)
        public static void DeleteNode(ListNode node)
        {
            // simple ans -> as problem says that node will not be tail node
            node.val = node.next.val;
            node.next = node.next.next;

            // if node is tail node
            // if else condition

            if (node.next == null)
            {
                node = null;
            }
            else
            {
                // above solution
            }
        }
    }
}
