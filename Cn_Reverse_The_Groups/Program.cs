using System;
using System.Collections.Generic;

namespace Cn_Reverse_The_Groups
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Cn_Reverse_The_Groups");
            Stack<int> st = new Stack<int>();
            st.Push(1);
            st.Push(2);
            st.Push(3);
            st.Push(4);
            st.Push(5);
            st.Push(6);

            Stack<int> result = reverseTheGroups(st, 6, 4);

        }

        static void reverse(int[] v, int start, int end)
        {
            while (start <= end)
            {
                int temp = v[start];
                v[start] = v[end];
                v[end] = temp;
                start++;
                end--;
            }
        }

        // working
        static Stack<int> reverseTheGroups(Stack<int> s, int n, int k)
        {

            int[] v = new int[n];
            int index = 0;
            while (s.Count > 0)
            {
                v[index] = s.Peek();
                s.Pop();
                index++;
            }

            int a = v.Length / k;
            int j = 0;

            while (a > 0)
            {
                reverse(v, j, j + k - 1);
                j = j + k;
                a--;
            }

            Array.Reverse(v);

            for (int i = 0; i < v.Length; i++)
            {
                s.Push(v[i]);
            }
            return s;
        }
    }
}
