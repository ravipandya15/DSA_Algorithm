using System;

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

namespace Singly_Linked_List
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Singly linkedList");

            Node node1 = new Node(10);
            Node head = node1;
            Node tail = node1;

            insertAtHead(12, ref head);
            print(head);

            insertAtHead(15, ref head);
            print(head);

            insertAtTail(20, ref tail);
            print(head);

            insertAtPosition(1, 50, ref head, ref tail);
            print(head);

            insertAtPosition(6, 60, ref head, ref tail);
            print(head);

            insertAtPosition(3, 100, ref head, ref tail);
            print(head);

            insertAtPosition(9, 100, ref head, ref tail);
            print(head);

            insertAtPosition(19, 100, ref head, ref tail);
            print(head);

            //deleteNode_At_Position(1, ref head, ref tail);
            //print(head);

            //deleteNode_At_Position(7, ref head, ref tail);
            //print(head);

            //deleteNode_At_Position(5, ref head, ref tail);
            //print(head);

            //deleteNode_By_Value(10, ref head, ref tail);
            //print(head);

            //deleteNode_By_Value(50, ref head, ref tail);
            //print(head);

            //deleteNode_By_Value(60, ref head, ref tail);
            //print(head);

            Console.WriteLine($"head is {head.data}, tail is {tail.data}");
        }

        public static void insertAtHead(int data, ref Node head)
        {
            Node newNode = new Node(data);
            newNode.next = head;
            head = newNode;
        }

        public static void insertAtPosition(int position, int data, ref Node head, ref Node tail)
        {
            if (position == 1)
            {
                insertAtHead(data, ref head);
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
                insertAtTail(data, ref tail);
                return;
            }
            else
            {
                if (temp == null) return;
            }
                

            // insert at middle
            Node nodeToInsert = new Node(data);
            nodeToInsert.next = temp.next;
            temp.next = nodeToInsert;
        }

        public static void insertAtTail(int data, ref Node tail)
        {
            Node newNode = new Node(data);
            tail.next = newNode;
            tail = newNode;
        }

        // Deleting Node by Position
        public static void deleteNode_At_Position(int position, ref Node head, ref Node tail)
        {
            if (position == 1)
            {// delete 1st Node
                Node cur = head;
                head = head.next;
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
                if (prev.next == null)
                    tail = prev;
            }
        }

        // Delete Node by value
        public static void deleteNode_By_Value(int value, ref Node head, ref Node tail)
        {
            int count = 1;
            Node cur = head, prev = null;
            while (cur.data != value)
            {
                prev = cur;
                cur = cur.next;
                count++;
            }

            if (count == 1)
            {// deleting 1st Node
                cur = head;
                head = head.next;
                cur.next = null;
            }
            else
            {
                prev.next = cur.next;
                if (prev.next == null)
                    tail = prev;
            }
        }

        public static void print(Node head)
        {
            Node temp = head;
            while (temp != null)
            {
                Console.Write(temp.data + " ");
                temp = temp.next;
            }

            Console.WriteLine();
        }
    }
}
