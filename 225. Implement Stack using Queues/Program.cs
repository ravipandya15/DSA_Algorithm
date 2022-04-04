using System;
using System.Collections.Generic;

namespace _225._Implement_Stack_using_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("225. Implement Stack using Queues");
            MyStack obj = new MyStack();
            obj.Push(1);
            obj.Push(2);
            int param_2 = obj.Top();
            int param_5 = obj.Pop();
            //int param_3 = obj.Top();
            bool param_4 = obj.Empty();
            Console.ReadLine();
        }

        public class MyStack
        {
            Queue<int> q1 = new Queue<int>();
            public MyStack()
            {

            }

            // using 1 queue
            public void Push(int x)
            {
                q1.Enqueue(x);
                for (int i = 0; i < q1.Count - 1; i++)
                {
                    //q1.Enqueue(q1.Dequeue());
                    q1.Enqueue(q1.Peek());
                    q1.Dequeue();
                }
            }

            // using 2 queue
            public void Push1(int x)
            {
                Queue<int> q2 = new Queue<int>();
                q2.Enqueue(x);
                while (q1.Count > 0)
                {
                    q2.Enqueue(q1.Dequeue());
                }
                q1 = q2;
            }

            public int Pop()
            {
                return q1.Dequeue();
            }

            public int Top()
            {
                return q1.Peek();
            }

            public bool Empty()
            {
                return (q1.Count == 0);
            }
        }


    }
}
