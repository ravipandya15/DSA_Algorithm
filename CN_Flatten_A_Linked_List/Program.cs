using System;

namespace CN_Flatten_A_Linked_List
{
    public class Node
    {
        public int data;
        public Node next;
        public Node child;

        public Node(int data)
        {
            this.data = data;
            this.next = null;
            this.child = null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Flatten_A_Linked_List");
            //Node head = new Node(1);
            //Node next2 = new Node(4);
            //Node next3 = new Node(7);
            //Node next4 = new Node(9);
            //Node next5 = new Node(20);

            //Node down1 = new Node(2);
            //Node down2 = new Node(3);
            //Node down3 = new Node(5);
            //Node down4 = new Node(6);
            //Node down5 = new Node(8);
            //Node down6 = new Node(12);

            //head.next = next2;
            //next2.next = next3;
            //next3.next = next4;
            //next4.next = next5;

            //head.child = down1;
            //down1.child = down2;

            //next2.child = down3;
            //down3.child = down4;

            //next3.child = down5;

            //next4.child = down6;

            Node head = new Node(3);
            Node next2 = new Node(5);
            Node next3 = new Node(22);
            Node next4 = new Node(26);
            Node next5 = new Node(39);

            Node down1 = new Node(4);
            Node down2 = new Node(6);
            Node down3 = new Node(11);
            Node down4 = new Node(14);
            Node down5 = new Node(25);
            Node down6 = new Node(28);

            //head.next = next2;
            //next2.next = next3;
            //next3.next = next4;
            //next4.next = next5;

            head.child = down1;
            down1.child = down2;

            next2.child = down3;
            down3.child = down4;

            next3.child = down5;

            next4.child = down6;

            Node result = flattenLinkedList(head);
        }

        public static Node merge(Node down, Node right)
        {
            Node ans = new Node(-1);
            Node temp = ans;

            while (down != null && right != null)
            {
                if (down.data < right.data)
                {
                    temp.next = down;
                    temp = temp.next;
                    down = down.child;
                    temp.child = null;
                }
                else
                {
                    temp.next = right;
                    temp = temp.next;
                    right = right.next;
                }
            }

            while (down != null)
            {
                temp.next = down;
                temp = temp.next;
                down = down.child;
                temp.child = null;
            }

            while (right != null)
            {
                temp.next = right;
                temp = temp.next;
                right = right.next;
            }

            return ans.next;
        }

        public static Node flattenLinkedList(Node start)
        {
            if (start == null) return start;

            Node down = start;

            Node right = flattenLinkedList(down.next);
            down.next = null;

            Node result = merge(down, right);

            return result;
        }
    }
}
