using System;

namespace Circular_Singly_LinkedList
{
    public class Node
    {
        public int data;
        public Node next;

        public Node(int _d)
        {
            this.data = _d;
            this.next = null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Circular_Singly_LinkedList");
            Node tail = null;
            insertNode(ref tail, 5, 3);
            print(ref tail);

            insertNode(ref tail, 3, 5);
            print(ref tail);

            insertNode(ref tail, 5, 7);
            print(ref tail);
            insertNode(ref tail, 7, 9);
            print(ref tail);
            insertNode(ref tail, 5, 6);
            print(ref tail);

            insertNode(ref tail, 9, 10);
            print(ref tail);
            insertNode(ref tail, 3, 4);
            print(ref tail);

            deleteNode(ref tail, 3);
            print(ref tail);
        }

        public static void print(ref Node tail)
        {
            if (tail == null)
            {
                Console.WriteLine("List is empty");
                return;
            }

            Node temp = tail;
            do
            {
                Console.Write(temp.data + " ");
                temp = temp.next;
            } while (temp != tail);

            Console.WriteLine();
        }

        public static void insertNode(ref Node tail, int element, int d)
        {
            Node newNode = new Node(d);
            if (tail == null)
            {// empty list
                tail = newNode;
                newNode.next = newNode;
            }
            else
            {
                Node cur = tail;
                while (cur.data != element)
                {
                    cur = cur.next;
                }

                newNode.next = cur.next;
                cur.next = newNode;
            }
        }

        public static void deleteNode(ref Node tail, int value)
        {
            if (tail == null)
            {
                Console.Write("cannot delete as list is empty");
                return;
            }

            Node prev = tail;
            Node cur = prev.next;

            while (cur.data != value)
            {
                prev = cur;
                cur = cur.next;
            }

            prev.next = cur.next;

            //only 1 Node linkedList
            if (cur == prev)
            {
                tail = null;
            }
            // LL contails 2 or more element
            else if (tail == cur)
            {
                tail = prev;
            }

            cur.next = null;
            // delete cur
        }

    }
}
