using System;

namespace CN_Implement_a_Queue
{
    public class Queue
    {

        public int[] arr;
        public int size;
        public int qfront;
        public int rear;

        public Queue()
        {
            size = 100001;
            arr = new int[size];
            qfront = 0;
            rear = 0;
        }

        /*----------------- Public Functions of Queue -----------------*/

        public bool isEmpty()
        {
            return (qfront == rear);
        }

        public void enqueue(int data)
        {
            // check if queue is full or not
            if (rear == size) return;

            arr[rear] = data;
            rear++;
        }

        public int dequeue()
        {

            if (qfront == rear) return -1;
            else
            {
                int ans = arr[qfront];
                arr[qfront] = -1;
                qfront++;

                if (qfront == rear)
                {
                    qfront = 0;
                    rear = 0;
                }

                return ans;
            }
        }

        public int front()
        {
            if (qfront == rear) return -1;
            return arr[qfront];
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Implement_a_Queue");
        }


    }
}
