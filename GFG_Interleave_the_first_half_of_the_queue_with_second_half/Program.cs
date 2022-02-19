using System;
using System.Collections.Generic;

namespace GFG_Interleave_the_first_half_of_the_queue_with_second_half
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GFG_Interleave_the_first_half_of_the_queue_with_second_half");
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            IntervalChange(ref queue);

            while (queue.Count > 0)
            {
                Console.Write(queue.Peek() + " ");
                queue.Dequeue();
            }
            Console.WriteLine();
        }

        public static void IntervalChange(ref Queue<int> queue)
        {
            int n = queue.Count;
            // step 1
            Stack<int> st = new Stack<int>();
            for (int i = 0; i < n/2; i++)
            {
                int val = queue.Peek();
                queue.Dequeue();
                st.Push(val);
            }

            //step 2
            while (st.Count > 0)
            {
                int val = st.Peek();
                st.Pop();
                queue.Enqueue(val);
            }

            // step 3
            for (int i = 0; i < n / 2; i++)
            {
                int val = queue.Peek();
                queue.Dequeue();
                queue.Enqueue(val);
            }

            // step 4
            for (int i = 0; i < n / 2; i++)
            {
                int val = queue.Peek();
                queue.Dequeue();
                st.Push(val);
            }

            // step 5
            while (st.Count > 0)
            {
                int val = st.Peek();
                st.Pop();
                queue.Enqueue(val);

                val = queue.Peek();
                queue.Dequeue();
                queue.Enqueue(val);
            }
        }
    }
}
