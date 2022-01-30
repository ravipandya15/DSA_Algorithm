using System;

namespace CN_Reverse_List_In_K_Groups
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
            Console.WriteLine("Reverse List In K Groups");
        }

        // TC -> O(N)
        // SC -> O(N) -> recursive stack space
        // here in last block if elements are less than k then reverse them too.
        public static Node kReverse(Node head, int k)
        {
            // write your code here
            // step 1 : Reverse first K nodes
            Node next = null;
            Node cur = head;
            Node prev = null;
            int count = 0;

            while (cur != null && count < k)
            {
                next = cur.next;
                cur.next = prev;
                prev = cur;
                cur = next;
                count++;
            }

            // step 2: for remaing list recursion will take care
            if (next != null)
            {
                head.next = kReverse(next, k);
            }

            // step 3: return head of reversed LinkedList
            return prev;

        }
    }
}
