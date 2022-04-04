using System;

namespace Implementation_of_Stack_using_Array
{
    public class Stack
    {
        public int size;
        public int top;
        public int[] arr;

        public Stack(int s)
        {
            this.size = s;
            arr = new int[this.size];
            top = -1;
        }

        public void push(int data)
        {
            if (size - top > 1) // or top < size - 1
            {
                top++;
                arr[top] = data;
            }
            else
            {
                Console.WriteLine("Stack overflow");
            }
        }

        public void pop()
        {
            if (top >= 0)
            {
                top--;
            }
            else
            {
                Console.WriteLine("Stack underflow");
            }
        }

        public int peek()
        {
            if (top >= 0 && top < size)
            {
                return arr[top];
            }
            else
            {
                Console.WriteLine("Stack is empty");
                return -1;
            }
        }

        public bool isEmpty()
        {
            return (top == -1);
        }

        public int stackSize()
        {
            return top + 1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
