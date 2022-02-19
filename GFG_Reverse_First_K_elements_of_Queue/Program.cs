using System;
using System.Collections.Generic;

namespace GFG_Reverse_First_K_elements_of_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GFG_Reverse_First_K_elements_of_Queue");
        }

        Queue<int> modifyQueue(Queue<int> q, int k)
        {
            Stack<int> st = new Stack<int>();
            for (int i = 0; i < k; i++)
            {
                st.Push(q.Peek());
                q.Dequeue();
            }

            while (st.Count > 0)
            {
                q.Enqueue(st.Peek());
                st.Pop();
            }

            int t = q.Count - k;

            while (t > 0)
            {
                int data = q.Peek();
                q.Dequeue();
                q.Enqueue(data);
                t--;
            }

            return q;
        }

    }
}
