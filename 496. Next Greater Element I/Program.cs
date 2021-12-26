using System;
using System.Collections.Generic;

namespace _496._Next_Greater_Element_I
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("496. Next Greater Element I");
            Console.ReadLine();
        }

        public int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            int[] ans = new int[nums1.Length];
            Stack<int> stack = new Stack<int>();

            // as array is dictinct as per question
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = nums2.Length - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && stack.Peek() <= nums2[i])
                    stack.Pop();

                if (stack.Count == 0)
                    dict.Add(nums2[i], -1);
                else
                    dict.Add(nums2[i], stack.Peek());

                stack.Push(nums2[i]);
            }

            for (int i = 0; i < nums1.Length; i++)
            {
                if (dict.TryGetValue(nums1[i], out int temp))
                    ans[i] = temp;
                else
                    ans[i] = -1;
            }
            return ans;
        }
    }
}
