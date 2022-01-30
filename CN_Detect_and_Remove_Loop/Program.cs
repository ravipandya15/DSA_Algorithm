using System;

namespace CN_Detect_and_Remove_Loop
{
    public class Node
    {

        public int data;
        public Node next;

        public Node(int data)
        {
            this.data = data;
            this.next = null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        // Floyd's Cycle delection Algo -> using 2 pointer approach
        // TC -> O(N)
        // SC -> O(1)
        public static Node floydDetectCycle(Node head)
        {
            if (head == null) return null;

            Node slow = head;
            Node fast = head;

            while (slow != null && fast != null)
            {
                fast = fast.next;
                if (fast != null)
                {
                    fast = fast.next;
                }

                slow = slow.next;

                if (slow == fast)
                    return slow;
            }

            return null;
        }

        public static Node getStartingNodeOfLoop(Node head)
        {
            if (head == null) return null;

            Node intersactionNode = floydDetectCycle(head);
            if (intersactionNode == null) return null;

            Node slow = head;

            while (slow != intersactionNode)
            {
                slow = slow.next;
                intersactionNode = intersactionNode.next;
            }

            return slow;
        }

        public static Node removeLoop(Node head)
        {

            if (head == null) return null;

            Node startingOfLoop = getStartingNodeOfLoop(head);

            if (startingOfLoop == null) return head;

            Node temp = startingOfLoop;
            while (temp.next != startingOfLoop)
            {
                temp = temp.next;
            }

            temp.next = null;
            return head;
        }
    }
}
