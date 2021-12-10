using System;
using System.Collections.Generic;

namespace _90._Subsets_II
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("90. Subsets II");
            int[] nums = new int[] { 1, 2, 2, 2, 3, 3 };
            var resultList = SubsetsWithDup(nums);
            Console.ReadLine();
        }

        public static void FindSubSet(int index, int[] nums, List<int> curList, IList<IList<int>> resultList)
        {
            resultList.Add(new List<int>(curList));
            for (int i = index; i < nums.Length; i++)
            {
                if (i != index && nums[i] == nums[i - 1]) continue;
                curList.Add(nums[i]);
                FindSubSet(i + 1, nums, curList, resultList);
                curList.RemoveAt(curList.Count - 1);
            }
        }

        public static IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            Array.Sort(nums);
            IList<IList<int>> resultList = new List<IList<int>>();
            List<int> curList = new List<int>();
            FindSubSet(0, nums, curList, resultList);
            return resultList;
        }
    }
}
