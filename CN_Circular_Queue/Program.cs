using System;

namespace CN_Circular_Queue
{
    public class CircularQueue
    {
        public int[] arr;
        public int front;
        public int rear;
        public int size;
        public CircularQueue(int n)
        {
            size = n;
            arr = new int[n];
            front = rear = -1;
        }

        /*
           Enqueues 'X' into the queue. Returns true if it gets pushed into the stack,
           and false otherwise.
        */
        public bool enqueue(int value)
        {
            if ((front == 0 && rear == size - 1) || (rear == front - 1))
            {
                // queue is full
                return false;
            }
            else if (front == -1) // first element to push
            {
                front = rear = 0;
            }
            else if (rear == size - 1 && front != 0)
            { // to maintian cyclic nature
                rear = 0;
            }
            else
            {// normal flow
                rear++;
            }
            arr[rear] = value;
            return true;
        }

        /*
          Dequeues top element from queue. Returns -1 if the stack is empty, otherwise
          returns the popped element.
        */
        public int dequeue()
        {
            if (front == -1)
            {
                // queue is empty;
                return -1;
            }

            int ans = arr[front];
            arr[front] = -1;

            if (front == rear) // single element is present
            {
                front = rear = -1;
            }
            else if (front == size - 1)
            {// to maintian cyclic nature
                front = 0;
            }
            else
            {// normal flow
                front++;
            }
            return ans;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Circular_Queue");
        }
    }
}
