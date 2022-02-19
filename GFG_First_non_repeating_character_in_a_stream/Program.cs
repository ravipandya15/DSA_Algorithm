using System;
using System.Collections.Generic;
using System.Text;

namespace GFG_First_non_repeating_char_in_a_stream
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GFG_First_non_repeating_char_in_a_stream");
        }

        public string FirstNonRepeating(string A)
        {
            StringBuilder sb = new StringBuilder();
            Queue<char> q = new Queue<char>();
            Dictionary<char, int> count = new Dictionary<char, int>();

            for (int i = 0; i < A.Length; i++)
            {
                // increase count;
                if (count.ContainsKey(A[i]))
                {
                    int temp = count[A[i]];
                    temp++;
                    count[A[i]] = temp;
                }
                else
                {
                    count.Add(A[i], 1);
                }

                // add it in queue
                q.Enqueue(A[i]);

                while (q.Count > 0)
                {
                    if (count[q.Peek()] > 1)
                    {
                        q.Dequeue();
                    }
                    else
                    {
                        sb.Append(q.Peek());
                        break;
                    }
                }

                if (q.Count == 0)
                {
                    sb.Append('#');
                }
            }

            return sb.ToString();
        }
    }
}
