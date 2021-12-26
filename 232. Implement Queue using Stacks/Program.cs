using System;
using System.Collections.Generic;

namespace _232._Implement_Queue_using_Stacks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("232. Implement Queue using Stacks");
            MyQueue obj = new MyQueue();
            obj.Push(2);
            obj.Push(5);
            obj.Push(3);
            int o1 = obj.Peek();
            int o2 = obj.Pop();
            obj.Push(6);
            int o3 = obj.Pop();
            int o4 = obj.Pop();
            int o5 = obj.Peek();
            bool o6 = obj.Empty();
            Console.ReadLine();
        }

        public class MyQueue
        {
            // approach 1;
            Stack<int> s1 = new Stack<int>();
            Stack<int> s2 = new Stack<int>();

            // approach 2;
            Stack<int> input = new Stack<int>();
            Stack<int> output = new Stack<int>();
            public MyQueue()
            {

            }

            //approach 2
            public void Push(int x)
            {
                input.Push(x);
            }

            //approach 2
            public int Pop()
            {
                if (output.Count > 0)
                    return output.Pop();
                else
                {
                    // empty stack
                    while (input.Count > 0)
                    {
                        output.Push(input.Peek());
                        input.Pop();
                    }
                    return output.Pop();
                }
            }

            //approach 2
            public int Peek()
            {
                if (output.Count > 0)
                    return output.Peek();
                else
                {
                    // empty stack
                    while (input.Count > 0)
                    {
                        output.Push(input.Peek());
                        input.Pop();
                    }
                    return output.Peek();
                }
            }

            //approach 1
            public void Push1(int x)
            {
                while (s1.Count > 0)
                {
                    s2.Push(s1.Peek());
                    s1.Pop();
                }
                s1.Push(x);
                while (s2.Count > 0)
                {
                    s1.Push(s2.Peek());
                    s2.Pop();
                }
            }

            //approach 1
            public int Pop1()
            {
                return s1.Pop();
            }

            //approach 1
            public int Peek1()
            {
                return s1.Peek();
            }

            public bool Empty()
            {
                // approach 1
                return s1.Count == 0;
                // approach 2
                return (input.Count == 0 && output.Count == 0);
            }
        }


    }
}
