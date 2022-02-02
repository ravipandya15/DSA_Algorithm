using System;

namespace CN_Merge_Two_Sorted_Linked_Lists
{
    public class LinkedListNode<T>
    {
        public T data;
        public LinkedListNode<T> next;

        public LinkedListNode(T data)
        {
            this.data = data;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Merge_Two_Sorted_Linked_Lists");
        }

        public static LinkedListNode<int> solve(LinkedListNode<int> first, LinkedListNode<int> second)
        {
            // check if fist list only contails 1 node
            if (first.next == null)
            {
                first.next = second;
                return first;
            }

            LinkedListNode<int> cur1 = first;
            LinkedListNode<int> next1 = first.next; // as we already check empty list cases
            LinkedListNode<int> cur2 = second;
            LinkedListNode<int> next2 = second.next;

            while (next1 != null && cur2 != null)
            {
                if (cur2.data >= cur1.data && cur2.data <= next1.data)
                {
                    cur1.next = cur2;
                    next2 = cur2.next;
                    cur2.next = next1;

                    cur1 = cur2; // or cur1 = cur1.next;
                    cur2 = next2;
                }
                else
                {
                    cur1 = next1;
                    next1 = next1.next;
                }
            }

            if (next1 == null)
            {
                cur1.next = cur2;
            }

            return first;
        }

        public static LinkedListNode<int> sortTwoLists(LinkedListNode<int> first, LinkedListNode<int> second)
        {
            if (first == null) return second;
            if (second == null) return first;

            if (first.data <= second.data)
            {
                return solve(first, second);
            }
            else
            {
                return solve(second, first);
            }
        }
    }
}
