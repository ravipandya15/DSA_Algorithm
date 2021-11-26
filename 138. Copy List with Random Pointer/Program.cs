using System;

namespace _138._Copy_List_with_Random_Pointer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("138. Copy List with Random Pointer");
            Console.ReadLine();
        }

        public class Node
        {
            public int val;
            public Node next;
            public Node random;
            public Node(int val = 0)
            {
                this.val = val;
                next = null;
                random = null;
            }
        }

        public static Node CopyRandomList(Node head)
        {
            Node item = head;
            Node front = head;

            // First round: make copy of each node,
            // and link them together side-by-side in a single list.
            while (item != null)
            {
                front = item.next;
                Node copy = new Node(item.val);
                item.next = copy;
                copy.next = front;

                item = front;
            }

            // Second round: assign random pointers for the copy nodes.
            item = head;
            while (item != null)
            {
                if (item.random != null)
                {
                    item.next.random = item.random.next;
                }
                item = item.next.next;
            }

            // Third round: restore the original list, and extract the copy list.
            item = head;
            Node psudoNode = new Node(0);
            Node dummy = psudoNode;

            while (item != null)
            {
                front = item.next.next;

                // extract the copy
                dummy.next = item.next;
                dummy = dummy.next;

                // restore the original list
                item.next = front;

                item = front;
            }

            return psudoNode.next;
        }
    }
}
