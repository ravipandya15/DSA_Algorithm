using System;
using System.Collections.Generic;

namespace _229._Majority_Element_II
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("229. Majority Element II");
            int[] nums = new int[] { 1, 1, 1, 3, 3, 2, 2, 2 };
            IList<int> ans = MajorityElement(nums);
            Console.ReadLine();
        }

        public static IList<int> MajorityElement(int[] nums)
        {
            IList<int> ans = new List<int>();
            int number1 = -1, number2 = -1, count1 = 0, count2 = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == number1)
                    count1++;
                else if (nums[i] == number2)
                    count2++;
                else if (count1 == 0)
                {
                    number1 = nums[i];
                    count1 = 1;
                }
                else if (count2 == 0)
                {
                    number2 = nums[i];
                    count2 = 1;
                }
                else
                {
                    count1--;
                    count2--;
                }
            }
            count1 = 0;
            count2 = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == number1)
                    count1++;
                else if (nums[i] == number2)
                    count2++;
            }

            if (count1 > nums.Length / 3)
                ans.Add(number1);
            if (count2 > nums.Length / 3)
                ans.Add(number2);

            return ans;
        }
    }
}
