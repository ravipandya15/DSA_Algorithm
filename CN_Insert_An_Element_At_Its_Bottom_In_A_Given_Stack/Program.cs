using System;
using System.Collections.Generic;

namespace CN_Insert_An_Element_At_Its_Bottom_In_A_Given_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Insert_An_Element_At_Its_Bottom_In_A_Given_Stack");
        }

        public static void solve(Stack<int> myStack, int x)
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
            solve(myStack, x);

            myStack.Push(element);
        }

        public static Stack<int> pushAtBottom(Stack<int> myStack, int x)
        {
            solve(myStack, x);
            return myStack;
        }
    }
}
