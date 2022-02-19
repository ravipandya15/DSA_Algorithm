using System;
using System.Collections.Generic;

namespace GFG_Queue_Reversal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GFG_Queue_Reversal");
        }

        public Queue<int> rev(Queue<int> q)
        {
            Stack<int> st = new Stack<int>();
            while (q.Count > 0)
            {
                st.Push(q.Peek());
                q.Dequeue();
            }

            while (st.Count > 0)
            {
                q.Enqueue(st.Peek());
                st.Pop();
            }
            return q;
        }
    }
}
