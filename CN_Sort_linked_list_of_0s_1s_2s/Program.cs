using System;

namespace CN_Sort_linked_list_of_0s_1s_2s
{
    public class Node<T>
    {
        public T data;
        public Node<T> next;

        public Node(T data)
        {
            this.data = data;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Node<int> head = new Node<int>(1);
            Node<int> node2 = new Node<int>(0);
            Node<int> node3 = new Node<int>(2);
            Node<int> node4 = new Node<int>(1);
            Node<int> node5 = new Node<int>(2);

            head.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;

            Node<int> result = sortList2(head);
        }

        public static Node<int> sortList1(Node<int> head)
        {
            int zeroCount = 0, oneCount = 0, twoCount = 0;
            Node<int> temp = head;

            while (temp != null)
            {
                if (temp.data == 0)
                    zeroCount++;
                else if (temp.data == 1)
                    oneCount++;
                else if (temp.data == 2)
                    twoCount++;

                temp = temp.next;
            }

            temp = head;
            while (temp != null)
            {
                if (zeroCount != 0)
                {
                    temp.data = 0;
                    zeroCount--;
                }
                else if (oneCount != 0)
                {
                    temp.data = 1;
                    oneCount--;
                }
                else if (twoCount != 0)
                {
                    temp.data = 2;
                    twoCount--;
                }

                temp = temp.next;
            }

            return head;
        }

        public static Node<int> insertAtTail(Node<int> tail, Node<int> node)
        {
            tail.next = node;
            tail = node;
            return tail;
        }

        // if Data replacement is not allowed.
        public static Node<int> sortList2(Node<int> head)
        {
            Node<int> zeroHead = new Node<int>(-1);
            Node<int> zeroTail = zeroHead;
            Node<int> oneHead = new Node<int>(-1);
            Node<int> oneTail = oneHead;
            Node<int> twoHead = new Node<int>(-1);
            Node<int> twoTail = twoHead;

            Node<int> cur = head;
            while (cur != null)
            {
                int data = cur.data;
                if (data == 0)
                    zeroTail = insertAtTail(zeroTail, cur);
                else if (data == 1)
                    oneTail = insertAtTail(oneTail, cur);
                else if (data == 2)
                    twoTail = insertAtTail(twoTail, cur);

                cur = cur.next;
            }

            if (oneHead.next != null)
            {
                zeroTail.next = oneHead.next;
            }
            else
            {
                zeroTail.next = twoHead.next;
            }

            oneTail.next = twoHead.next;
            twoTail.next = null;

            head = zeroHead.next;
            return head;
        }
    }
}
