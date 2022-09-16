using System;

namespace Remove_Element_27
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Remove_Element_27");
            int[] nums = { 0, 1, 2, 2, 3, 0, 2, 4 };
            int ans = removeElement_1(nums, 2);
            Console.WriteLine($"Answer is {ans}");

        }

        public static int removeElement_1(int[] nums, int val)
        {
            int n = nums.Length;
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                if (nums[i] != val) count++;
            }
            int j = 0;
            bool flag = false;
            for (int i = 0; i < n; i++)
            {
                if (nums[i] == val)
                {
                    if (flag == true) continue;
                    else
                    {
                        j = i;
                        flag = true;
                    }
                }
                else if (flag == true)
                {
                    nums[j] = nums[i];
                    j++;
                }
            }

            return count;
        }
    }
}
