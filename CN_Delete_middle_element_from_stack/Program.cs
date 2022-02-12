using System;
using System.Collections.Generic;

namespace CN_Delete_middle_element_from_stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Delete_middle_element_from_stack");
            Stack<int> st = new Stack<int>();

            st.Push(1);
            st.Push(2);
            st.Push(3);
            st.Push(4);
            st.Push(5);

            deleteMiddle(st, 5);
        }

        public static void solve(Stack<int> stack, int count, int size)
        {
            // base case
            if (count == size / 2)
            {
                stack.Pop();
                return;
            }

            int num = stack.Peek();
            stack.Pop();

            // recursive call
            solve(stack, count + 1, size);

            stack.Push(num);
        }

        public static void deleteMiddle(Stack<int> inputStack, int N)
        {
            int count = 0;
            solve(inputStack, count, N);
        }
    }
}
