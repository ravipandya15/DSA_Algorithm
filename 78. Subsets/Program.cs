using System;
using System.Collections.Generic;

namespace _78._Subsets
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("78. Subsets");
            int[] nums = new int[] { 1, 2, 3 };
            var resultList = Subsets(nums);
            Console.ReadLine();
        }

        public static void FindSubSet(int index, int[] nums, List<int> curList, IList<IList<int>> resultList)
        {
            resultList.Add(new List<int>(curList));
            for (int i = index; i < nums.Length; i++)
            {
                curList.Add(nums[i]);
                FindSubSet(i + 1, nums, curList, resultList);
                curList.RemoveAt(curList.Count - 1);
            }
        }

        public static IList<IList<int>> Subsets(int[] nums)
        {
            IList<IList<int>> resultList = new List<IList<int>>();
            List<int> curList = new List<int>();
            FindSubSet(0, nums, curList, resultList);
            return resultList;
        }
    }
}
