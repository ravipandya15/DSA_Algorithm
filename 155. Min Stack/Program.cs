using System;
using System.Collections.Generic;

namespace _155._Min_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("155. Min Stack");
        }

        public class MinStack
        {
            long mini;
            Stack<long> st = new Stack<long>();
            public MinStack()
            {
                mini = long.MaxValue;
            }

            public void Push(int value)
            {
                long val = Convert.ToInt64(value);
                if (st.Count == 0)
                {
                    // first element
                    mini = val;
                    st.Push(val);
                }
                else
                {
                    if (val < mini)
                    {
                        // update mini and push modified value
                        st.Push(2 * val - mini);
                        mini = val;
                    }
                    else
                    {
                        st.Push(val);
                    }
                }
            }

            public void Pop()
            {
                if (st.Count == 0) return;
                long val = st.Peek();
                st.Pop();

                if (val < mini)
                {
                    // it means it's modified value so roll back mini to prevMin.
                    mini = 2 * mini - val;
                }
            }

            public int Top()
            {
                long val = st.Peek();

                if (val < mini)
                {
                    return (int)mini;
                }
                return (int)val;
            }

            public int GetMin()
            {
                return (int)mini;
            }
        }
    }
}
