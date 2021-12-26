using System;
using System.Collections.Generic;

namespace _503._Next_Greater_Element_II
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("503. Next Greater Element II");
            Console.ReadLine();
        }

        public int[] NextGreaterElements(int[] nums)
        {
            int n = nums.Length;
            int[] ans = new int[n];
            Stack<int> stack = new Stack<int>();

            for (int i = 2*n - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && stack.Peek() <= nums[i%n])
                    stack.Pop();

                if (i < n)
                {
                    if (stack.Count == 0)
                        ans[i] = -1;
                    else
                        ans[i] = stack.Peek();
                }
                stack.Push(nums[i%n]);
            }
            return ans;
        }
    }
}
