using System;
using System.Collections.Generic;

namespace CN_Reverse_Stack_Using_Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Reverse_Stack_Using_Recursion");
        }

        public static void insertAtBottom(Stack<int> myStack, int x)
        {
            // base case
            if (myStack.Count == 0)
            {
                myStack.Push(x);
                return;
            }

            int element = myStack.Peek();
            myStack.Pop();

            // recursive call
            insertAtBottom(myStack, x);

            myStack.Push(element);
        }

        // TC -> O(N^2)
        // SC -> ?
        public static void reverseStack(Stack<int> stack)
        {
            // base case
            if (stack.Count == 0)
            {
                return;
            }

            int element = stack.Peek();
            stack.Pop();

            // recursive call
            reverseStack(stack);

            insertAtBottom(stack, element);
        }
    }
}
