using System;
using System.Collections.Generic;

namespace GFG_Clone_a_linked_list_with_next_and_random_pointer
{
    public class Node
    {
        public int data;
        public Node next, arb;
        public Node(int d)
        {
            data = d;
            next = arb = null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GFG_Clone_a_linked_list_with_next_and_random_pointer");
            Node head = new Node(1);
            Node node2 = new Node(2);
            Node node3 = new Node(3);
            Node node4 = new Node(4);
            Node node5 = new Node(5);

            head.next = node2;
            node2.next = node3;
            node3.next = node4;
            node4.next = node5;

            head.arb = node3;
            node2.arb = head;
            node3.arb = node5;
            node4.arb = node3;
            node5.arb = node2;

            Node cloneList = copyList2(head);
        }

        static void insertAtTail(ref Node head, ref Node tail, int data)
        {
            Node newNode = new Node(data);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.next = newNode;
                tail = newNode;
            }
        }

        // TC -> O(N)
        // SC -> O(N)
        static Node copyList1(Node head)
        {
            Node cloneHead = null;
            Node cloneTail = null;
            Node temp = head;

            while (temp != null)
            {
                insertAtTail(ref cloneHead, ref cloneTail, temp.data);
                temp = temp.next;
            }

            // use of HashMap
            Dictionary<Node, Node> map = new Dictionary<Node, Node>();
            temp = head;
            Node temp2 = cloneHead;
            while (temp != null)
            {
                map[temp] = temp2;
                temp = temp.next;
                temp2 = temp2.next;
            }

            temp = head;
            temp2 = cloneHead;
            while (temp != null)
            {
                temp2.arb = map[temp.arb];
                temp = temp.next;
                temp2 = temp2.next;
            }

            return cloneHead;
        }

        // TC -> O(N)
        // SC -> O(1)
        static Node copyList2(Node head)
        {
            // step 1 -> clone original list (with help of next pointer)
            Node cloneHead = null;
            Node cloneTail = null;
            Node temp = head;

            while (temp != null)
            {
                insertAtTail(ref cloneHead, ref cloneTail, temp.data);
                temp = temp.next;
            }

            Node originalNode = head;
            Node cloneNode = cloneHead;
            // step 2 -> cloneNodes add inbetween original linkedList
            while (originalNode != null && cloneNode != null)
            {
                // next is commonly used for both originalNode and cloneNode
                Node next = originalNode.next;
                originalNode.next = cloneNode;
                originalNode = next;

                next = cloneNode.next;
                cloneNode.next = originalNode;
                cloneNode = next;
            }

            originalNode = head;
            cloneNode = cloneHead;
            // step 3 -> set Random pointer
            while (originalNode != null)
            {
                if (originalNode.arb != null)
                {
                    originalNode.next.arb = originalNode.arb.next;
                }
                originalNode = originalNode.next.next;
            }

            originalNode = head;
            cloneNode = cloneHead;
            // step 4 -> revert changes done in step2
            while (originalNode != null && cloneNode != null)
            {
                originalNode.next = cloneNode.next;
                originalNode = originalNode.next;

                if (originalNode != null)
                {
                    cloneNode.next = originalNode.next;
                }
                
                cloneNode = cloneNode.next;
            }

            // step 5 -> return ans
            return cloneHead;
        }
    }
}

