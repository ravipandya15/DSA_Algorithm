using System;
using System.Collections.Generic;

namespace CN_Sort_a_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Sort_a_Stack");
        }

        public static void sortInsert(Stack<int> stack, int num)
        {
            if (stack.Count == 0 || stack.Peek() < num)
            {
                stack.Push(num);
                return;
            }

            int element = stack.Peek();
            stack.Pop();

            // recursive call
            sortInsert(stack, num);

            stack.Push(element);
        }

        public static void sortStack(Stack<int> stack)
        {
            if (stack.Count == 0)
            {
                return;
            }

            int num = stack.Peek();
            stack.Pop();

            // recursive call
            sortStack(stack);

            sortInsert(stack, num);
        }
    }
}
