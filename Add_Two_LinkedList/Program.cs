using System;

namespace Add_Two_LinkedList
{
    class Program
    {
        ListNode head;
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x = 0, ListNode next = null)
            {
                val = x;
                next = null;
            }
        }

        public void Push(int new_data)
        {
            ListNode newNode = new ListNode(new_data);
            newNode.next = head;
            head = newNode;
        }
        public void PrintList(ListNode head)
        {
            Console.WriteLine("Printing Linked List");
            while (head != null)
            {
                Console.Write(head.val + "-->");
                head = head.next;
            }
        }

        // better way
        // TC -> O(max(n1 + n2))
        // SC -> O(n) -> n is length of new linked List
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode dummy = new ListNode(0);
            ListNode tmp = dummy;
            int carry = 0;

            while (l1 != null || l2 != null || carry == 1)
            {
                int sum = 0;
                if (l1 != null)
                {
                    sum += l1.val;
                    l1 = l1.next;
                }

                if (l2 != null)
                {
                    sum += l2.val;
                    l2 = l2.next;
                }

                sum += carry;
                carry = sum / 10;
                ListNode next = new ListNode(sum % 10);
                tmp.next = next;
                tmp = next;
            }

            return dummy.next;
        }

        public static ListNode AddTwoNumbers1(ListNode l1, ListNode l2)
        {
            ListNode resultNode = new ListNode();
            ListNode prevNode = null;
            int sum = 0, carry = 0;
            int prevSum = 0;
            bool flag = false;
            while (l1 != null || l2 != null)
            {
                if (carry != 0)
                {
                    sum = sum + carry;
                }
                if (l1 != null)
                {
                    sum = sum + l1.val;
                    l1 = l1.next;
                }
                if (l2 != null)
                {
                    sum = sum + l2.val;
                    l2 = l2.next;
                }
                if (sum >= 10)
                {
                    prevSum = sum;
                    sum = sum % 10;
                    carry = prevSum / 10;
                    flag = true;
                }
                ListNode tempNode = new ListNode();
                tempNode.val = sum;
                tempNode.next = null;

                if (prevNode != null)
                {
                    prevNode.next = tempNode;
                }
                else
                {
                    resultNode = tempNode;
                }
                prevNode = tempNode;
                if (!flag)
                {
                    sum = 0;
                    carry = 0;
                }
                else
                {
                    sum = 0;
                    flag = false;
                }
                
            }
            if (carry > 0)
            {
                ListNode tempNode = new ListNode();
                tempNode.val = carry;
                tempNode.next = null;
                if (prevNode != null)
                {
                    prevNode.next = tempNode;
                }
                prevNode = tempNode;
            }
            return resultNode;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Adding Two LinkedList");
            Program linkedList1 = new Program();
            linkedList1.Push(0);
            //linkedList1.Push(9);
            //linkedList1.Push(9);
            //linkedList1.Push(9);
            //linkedList1.Push(9);
            //linkedList1.Push(9);
            //linkedList1.Push(9);
            //linkedList1.Push(9);
            Console.WriteLine(linkedList1.head.val);
            linkedList1.PrintList(linkedList1.head);
            Program linkedList2 = new Program();
            linkedList2.Push(0);
            //linkedList2.Push(9);
            //linkedList2.Push(9);
            //linkedList2.Push(9);
            //linkedList2.Push(9);
            Console.WriteLine();
            Console.WriteLine(linkedList2.head.val);
            linkedList1.PrintList(linkedList2.head);
            ListNode resultNode = AddTwoNumbers(linkedList1.head, linkedList2.head);
            Console.WriteLine();
            Console.WriteLine(resultNode.val);
            linkedList1.PrintList(resultNode);
            Console.ReadLine();
        }
    }
}
