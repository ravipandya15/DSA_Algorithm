using System;

namespace GFG_K_Queue_In_Single_Array
{

    public class NQueue
    {
        public int[] arr;
        public int[] front;
        public int[] rear;
        public int[] next;
        public int freespot;

        public NQueue(int n, int k)
        {
            arr = new int[n];
            next = new int[n];

            for (int i = 0; i < n; i++)
            {
                next[i] = i + 1;
            }
            next[n - 1] = -1;

            front = new int[k];
            rear = new int[k];

            for (int i = 0; i < k; i++)
            {
                front[i] = -1;
                rear[i] = -1;
            }

            freespot = 0;
        }

        public void enqueue(int data, int qn)
        {
            // check overflow condition
            if (freespot == -1)
            {
                Console.WriteLine("Overflow");
                return;
            }

            // find index;
            int index = freespot;
            freespot = next[index];

            // if first element
            if (front[qn - 1] == -1)
            {
                front[qn - 1] = index;
            }
            else
            {// not first element
                next[rear[qn - 1]] = index;
            }

            next[index] = -1;
            rear[qn - 1] = index;
            arr[index] = data;
        }

        public int dequeue(int qn)
        {
            // check inderflow condition
            if (front[qn - 1] == -1)
            {
                Console.WriteLine("Underflow");
                return -1;
            }

            // find index;
            int index = front[qn - 1];
            front[qn - 1] = next[index];
            next[index] = freespot;
            freespot = index;

            return arr[index];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GFG_K_Queue_In_Single_Array");
            NQueue nQueue = new NQueue(4, 2);
            nQueue.enqueue(10, 1);
            nQueue.enqueue(20, 2);
            nQueue.enqueue(30, 1);
            nQueue.enqueue(40, 2);

            Console.WriteLine(nQueue.dequeue(1));
            Console.WriteLine(nQueue.dequeue(1));
            Console.WriteLine(nQueue.dequeue(2));
            Console.WriteLine(nQueue.dequeue(2));
            Console.WriteLine(nQueue.dequeue(2));
        }
    }
}
