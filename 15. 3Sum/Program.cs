using System;
using System.Collections.Generic;
using System.Linq;

namespace _15._3Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("15. 3Sum");
            //var list1 = new List<int> { 1, 2, 3, 1 };
            //var list2 = new List<int> { 2, 1, 3, 1 };
            //var list3 = new List<int> { 1, 2, 3, 1 };
            ////bool areTheSame1 = list1.SequenceEqualsIgnoreOrder(list2); //True
            //bool areTheSame2 = list1.SequenceEqual(list2); //True
            //bool areTheSame3 = list1.SequenceEqual(list3); //False
            int[] nums = new int[] { -1, 0, 1, 2, -1, -4 };
            //int[] nums = new int[] { 0 };
            var resultList = ThreeSum(nums);
            foreach (var innerlist in resultList)
            {
                foreach (int num in innerlist)
                {
                    Console.Write($"{num} ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> resultList = new List<IList<int>>();
            if (nums.Length < 3)
            {
                return resultList;
            }
            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i == 0 || (i > 0 && nums[i] != nums[i - 1]))
                {
                    int start = i + 1, end = nums.Length - 1;
                    while (start < end)
                    {
                        int sum = nums[i] + nums[start] + nums[end];
                        if (sum == 0)
                        {
                            List<int> tempList = new List<int> { nums[i], nums[start], nums[end] };
                            resultList.Add(new List<int> { nums[i], nums[start], nums[end] });
                            while (start < end && nums[start] == nums[start + 1])
                            {
                                start++;
                            }
                            while (start < end && nums[end] == nums[end - 1])
                            {
                                end--;
                            }
                            start++;
                            end--;
                        }
                        else if (sum > 0)
                        {
                            end--;
                        }
                        else
                        {
                            start++;
                        }
                    }
                }
            }
            return resultList;
        }
    }
}
