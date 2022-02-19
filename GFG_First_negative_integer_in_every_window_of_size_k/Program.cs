using System;
using System.Collections.Generic;

namespace GFG_First_negative_int_in_every_window_of_size_k
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GFG_First_negative_int_in_every_window_of_size_k");
        }

        public long[] printFirstNegativeint(long[] A, int N, int K)
        {
            LinkedList<int> deque = new LinkedList<int>();
            long[] ans = new long[N - K + 1];
            int index = 0;

            // for 1st K sized window
            for (int i = 0; i < K; i++)
            {
                if (A[i] < 0)
                {
                    deque.AddLast(i);
                }
            }

            // store ans for 1st window
            if (deque.Count > 0)
            {
                ans[index] = A[deque.First.Value];
            }
            else
            {
                ans[index] = 0;
            }
            index++;

            // for remaining K sized Window
            for (int i = K; i < N; i++)
            {
                // removal code
                if (deque.Count > 0 && i - deque.First.Value >= K)
                {
                    deque.RemoveFirst();
                }

                // adding code
                if (A[i] < 0)
                {
                    deque.AddLast(i);
                }

                // store ans
                if (deque.Count > 0)
                {
                    ans[index] = A[deque.First.Value];
                }
                else
                {
                    ans[index] = 0;
                }
                index++;
            }
            return ans;
        }
    }
}
