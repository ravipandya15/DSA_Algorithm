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
            //var resultList = Subsets1(nums);
            var resultList = Subsets(nums);
            Console.ReadLine();
        }

        //code help approach
        //using Recursion
        private static void Solve(int[] nums, int index, List<int> output, IList<IList<int>> result)
        {
            if (index >= nums.Length)
            {
                result.Add(new List<int>(output));
                return;
            }

            // exclude
            Solve(nums, index + 1, output, result);

            //include
            output.Add(nums[index]);
            Solve(nums, index + 1, output, result);
            // output ne as a reference pass nathi karyo etle C++ ma remove na lakhiye to chale
            output.RemoveAt(output.Count - 1);
        }

        public static IList<IList<int>> Subsets(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            List<int> output = new List<int>();
            Solve(nums, 0, output, result);
            return result;
        }

        // Striver approach
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

        public static IList<IList<int>> Subsets1(int[] nums)
        {
            IList<IList<int>> resultList = new List<IList<int>>();
            List<int> curList = new List<int>();
            FindSubSet(0, nums, curList, resultList);
            return resultList;
        }
    }
}
