using System;

namespace GFG_Add_two_numbers_represented_by_linked_lists
{
    public class Node
    {
        public int data;
        public Node next;

        public Node(int d)
        {
            data = d;
            next = null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GFG_Add_two_numbers_represented_by_linked_lists");
            Node head1 = new Node(4);
            Node node2 = new Node(5);
            head1.next = node2;

            Node head2 = new Node(3);
            Node node3 = new Node(4);
            Node node4 = new Node(5);
            head2.next = node3;
            node3.next = node4;

            Node result = addTwoLists(head1, head2);
        }

        public static Node reverse(Node head)
        {
            Node cur = head;
            Node prev = null;
            Node next = null;

            while (cur != null)
            {
                next = cur.next;
                cur.next = prev;
                prev = cur;
                cur = next;
            }

            return prev;
        }

        public static void insertAtTail(ref Node head, ref Node tail, int data)
        {
            Node temp = new Node(data);
            if (head == null)
            {
                head = temp;
                tail = temp;
            }
            else
            {
                tail.next = temp;
                tail = temp;
            }
        }

        public static Node add(Node first, Node second)
        {
            int carry = 0;
            Node ansHead = null;
            Node ansTail = null;

            while (first != null || second != null || carry != 0)
            {
                int sum = 0;
                if (first != null)
                    sum += first.data;

                if (second != null)
                    sum += second.data;

                sum += carry;

                int digit = sum % 10;
                insertAtTail(ref ansHead, ref ansTail, digit);

                carry = sum / 10;

                if (first != null)
                    first = first.next;

                if (second != null)
                    second = second.next;
            }

            return ansHead;
        }

        static Node addTwoLists(Node first, Node second)
        {
            // step 1: reverse both linked List
            Node newFirst = reverse(first);
            Node newSecond = reverse(second);

            // add numbers from both linkedList
            Node result = add(newFirst, newSecond);

            // reverse resultant Linked List
            Node newResult = reverse(result);

            // reverse first and second linkedList again
            Node oldfirst = reverse(newFirst);
            Node oldsecond = reverse(newSecond);

            return newResult;
        }
    }
}
