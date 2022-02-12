using System;

namespace CN_Two_Stacks
{
	public class TwoStack
	{
        int size;
        int top1;
        int top2;
        int[] arr;
        // Initialize TwoStack.
        public TwoStack(int s)
        {
            this.size = s;
            arr = new int[s];
            top1 = -1;
            top2 = s;
        }

        // Push in stack 1.
        public void push1(int num)
        {
            // check if atleast 1 space is there
            if (top2 - top1 > 1)
            {
                top1++;
                arr[top1] = num;
            }
        }

        // Push in stack 2.
        public void push2(int num)
        {
            if (top2 - top1 > 1)
            {
                top2--;
                arr[top2] = num;
            }
        }

        // Pop from stack 1 and return popped element.
        public int pop1()
        {
            if (top1 >= 0)
            {
                int ans = arr[top1];
                top1--;
                return ans;
            }
            else
            {
                return -1;
            }
        }

        // Pop from stack 2 and return popped element.
        public int pop2()
        {
            if (top2 < size)
            {
                int ans = arr[top2];
                top2++;
                return ans;
            }
            else
            {
                return -1;
            }
        }
    }

	class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Two_Stacks");
        }


    }
}
