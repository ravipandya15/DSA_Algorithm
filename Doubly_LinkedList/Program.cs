using System;

namespace Doubly_LinkedList
{
    public class Node
    {
        public int data;
        public Node next;
        public Node prev;

        public Node(int _d)
        {
            this.data = _d;
            this.next = null;
            this.prev = null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Doubly_LinkedList");

            Node node1 = new Node(10);
            Node head = node1;
            Node tail = node1;

            printLinkedList(head);
            int length = lengthOfLinkedList(head);
            Console.WriteLine($"length of linkedList is {length}");

            insertAtHead(12, ref head, ref tail);
            printLinkedList(head);

            insertAtHead(15, ref head, ref tail);
            printLinkedList(head);

            insertAtTail(20, ref head, ref tail);
            printLinkedList(head);

            insertAtPosition(1, 50, ref head, ref tail);
            printLinkedList(head);

            insertAtPosition(6, 60, ref head, ref tail);
            printLinkedList(head);

            insertAtPosition(3, 100, ref head, ref tail);
            printLinkedList(head);

            insertAtPosition(8, 110, ref head, ref tail);
            printLinkedList(head);

            insertAtPosition(19, 100, ref head, ref tail);
            printLinkedList(head);

            deleteNode_At_Position(1, ref head, ref tail);
            printLinkedList(head);

            deleteNode_At_Position(7, ref head, ref tail);
            printLinkedList(head);

            deleteNode_At_Position(5, ref head, ref tail);
            printLinkedList(head);

            deleteNode_By_Value(10, ref head, ref tail);
            printLinkedList(head);

            deleteNode_By_Value(50, ref head, ref tail);
            printLinkedList(head);

            deleteNode_By_Value(60, ref head, ref tail);
            printLinkedList(head);

        }

        public static void insertAtHead(int data, ref Node head, ref Node tail)
        {
            Node newNode = new Node(data);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.next = head;
                head.prev = newNode;
                head = newNode;
            }
        }

        public static void insertAtPosition(int position, int data, ref Node head, ref Node tail)
        {
            if (position == 1)
            {
                insertAtHead(data, ref head, ref tail);
                return;
            }

            int count = 1;
            Node temp = head;

            while (count < position - 1)
            {
                if (temp != null)
                {
                    temp = temp.next;
                    count++;
                }
                else
                {
                    return;
                }
            }

            if (temp != null && temp.next == null)
            {
                insertAtTail(data, ref head, ref tail);
                return;
            }
            else
            {
                if (temp == null) return;
            }


            // insert at middle
            Node nodeToInsert = new Node(data);
            nodeToInsert.next = temp.next;
            temp.next.prev = nodeToInsert;

            nodeToInsert.prev = temp;
            temp.next = nodeToInsert;
        }

        public static void insertAtTail(int data, ref Node head, ref Node tail)
        {
            Node newNode = new Node(data);
            if (tail == null)
            {
                tail = newNode;
                head = newNode;
            }
            else
            {
                tail.next = newNode;
                newNode.prev = tail;
                tail = newNode;
            }
            
        }

        // Deleting Node by Position
        public static void deleteNode_At_Position(int position, ref Node head, ref Node tail)
        {
            if (position == 1)
            {// delete 1st Node
                Node cur = head;
                cur.next.prev = null;
                head = cur.next;
                cur.next = null;
            }
            else
            {// deleting middle or last node
                int count = 1;
                Node prev = null, cur = head;
                while (count < position)
                {
                    prev = cur;
                    cur = cur.next;
                    count++;
                }

                prev.next = cur.next;
                if (cur.next != null)
                {
                    cur.next.prev = prev;
                }
                cur.next = null;
                cur.prev = null;
                if (prev.next == null)
                    tail = prev;
            }
        }

        // Delete Node by value
        public static void deleteNode_By_Value(int value, ref Node head, ref Node tail)
        {
            int count = 1;
            Node cur = head, prev = null;
            while (cur != null && cur.data != value)
            {
                prev = cur;
                cur = cur.next;
                count++;
            }

            if (cur == null)
                return;

            if (count == 1)
            {// deleting 1st Node
                cur = head;
                cur.next.prev = null;
                head = cur.next;
                cur.next = null;
            }
            else
            {
                prev.next = cur.next;
                if (cur.next != null)
                {
                    cur.next.prev = prev;
                }
                cur.next = null;
                cur.prev = null;
                if (prev.next == null)
                    tail = prev;
            }
        }

        public static void printLinkedList(Node head)
        {
            Node cur = head;
            while (cur != null)
            {
                Console.Write(cur.data + " ");
                cur = cur.next;
            }
            Console.WriteLine();
        }

        // gives Length of LinkedList
        public static int lengthOfLinkedList(Node head)
        {
            int count = 0;
            Node cur = head;
            while (cur != null)
            {
                count++;
                cur = cur.next;
            }
            return count;
        }
    }
}
