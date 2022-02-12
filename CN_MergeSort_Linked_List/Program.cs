using System;

namespace CN_MergeSort_Linked_List
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
            Console.WriteLine("CN_MergeSort_Linked_List");
        }

        private static Node<int> findMid(Node<int> head)
        {
            Node<int> slow = head;
            Node<int> fast = head.next;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            return slow;
        }

        private static Node<int> mergeSortedList(Node<int> left, Node<int> right)
        {
            if (left == null) return right;
            if (right == null) return left;

            Node<int> ans = new Node<int>(-1);
            Node<int> temp = ans;

            while (left != null && right != null)
            {
                if (left.data < right.data)
                {
                    temp.next = left;
                    temp = left; // or temp = temp.next
                    left = left.next;
                }
                else
                {
                    temp.next = right;
                    temp = right;
                    right = right.next;
                }
            }

            if (left != null)
            {
                temp.next = left;
            }
            else if (right != null)
            {
                temp.next = right;
            }

            return ans.next;
        }

        public static Node<int> mergeSort(Node<int> head)
        {

            if (head == null || head.next == null) return head;

            // find mid;
            Node<int> mid = findMid(head);
            Node<int> left = head;
            Node<int> right = mid.next;
            mid.next = null;

            // recursively sort left and right part
            left = mergeSort(left);
            right = mergeSort(right);

            // merge sorted List
            Node<int> result = mergeSortedList(left, right);

            return result;
        }
    }
}
