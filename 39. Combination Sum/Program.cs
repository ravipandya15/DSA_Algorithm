using System;
using System.Collections.Generic;

namespace _39._Combination_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("39. Combination Sum");
            int[] arr = { 2, 3, 6, 7 };
            int target = 7;
            var resultList = CombinationSum(arr, target);
            Console.ReadLine();
        }

        public static void FindCombination(int index, int target, int[] arr, IList<IList<int>> ans, IList<int> ds)
        {
            // base condition
            if (index == arr.Length)
            {
                if (target == 0)
                {
                    ans.Add(new List<int>(ds)); // if I change ds value after this statement,
                                                // it will not change data in this ds (as it is typecaseted to new List<int>)
                }
                return;
            }

            if (arr[index] <= target)
            {
                //pick element
                ds.Add(arr[index]);
                FindCombination(index, target - arr[index], arr, ans, ds);
                ds.RemoveAt(ds.Count - 1);
            }

            // not pick
            FindCombination(index + 1, target, arr, ans, ds);
        }

        public static IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            IList<IList<int>> ans = new List<IList<int>>();
            IList<int> ds = new List<int>();
            FindCombination(0, target, candidates, ans, ds);
            return ans;
        }
    }
}
