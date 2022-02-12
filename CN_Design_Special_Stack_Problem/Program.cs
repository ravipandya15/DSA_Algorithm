using System;
using System.Collections.Generic;

namespace CN_Design_Special_Stack_Problem
{
    public class SpecialStack
    {
        Stack<int> st = new Stack<int>();
        int mini; // here mini = INT_MAX will work but it's not required as in Push operation for 1st element we are updating mini.


        /*----------------- Public Functions of SpecialStack -----------------*/

        public void Push(int data)
        {
            // for 1st element
            if (st.Count == 0)
            {
                st.Push(data);
                mini = data;
            }
            else
            {
                if (data < mini)
                {
                    int val = 2 * data - mini;
                    st.Push(val);
                    mini = data;
                }
                else
                {
                    st.Push(data);
                }
            }
        }

        public int Pop()
        {
            // underflow condition
            if (st.Count == 0) return -1;

            int cur = st.Peek();
            st.Pop();
            if (cur > mini)
            {
                return cur;
            }
            else
            {
                int prevMin = mini;
                int val = 2 * mini - cur;
                mini = val;
                return prevMin;
            }
        }

        public int top()
        {
            if (st.Count == 0) return -1;

            int cur = st.Peek();
            if (cur < mini)
            {
                return mini;
            }
            else
            {
                return cur;
            }
        }

        public bool isEmpty()
        {
            return st.Count == 0;
        }

        public int getMin()
        {
            if (st.Count == 0) return -1;
            return mini;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Design_Special_Stack_Problem");
        }
    }
}
