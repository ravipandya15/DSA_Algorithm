using System;
using System.Collections.Generic;
using System.Linq;

namespace _40._Combination_Sum_II
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("40. Combination Sum II");
            int[] arr = { 1, 1, 1, 2, 2 };
            int target = 4;
            var resultList = CombinationSum2(arr, target);
            Console.ReadLine();
        }

        // TC -> O(2^N * K * Log(something)) here something is size of hashSet
        // SC -> O(k * x)
        public static void FindCombination1(int index, int target, int[] arr, HashSet<IList<int>> ans, List<int> ds)
        {
            // base condition
            if (index == arr.Length)
            {
                if (target == 0)
                {
                    ans.Add(new List<int>(ds)); 
                }
                return;
            }

            if (arr[index] <= target)
            {
                //pick element
                ds.Add(arr[index]);
                FindCombination1(index + 1, target - arr[index], arr, ans, ds);
                ds.RemoveAt(ds.Count - 1);
            }

            // not pick
            FindCombination1(index + 1, target, arr, ans, ds);
        }

        // TC -> O(2^N * k)
        // SC -> O(k * x) here x is no. of combinations
        public static void FindCombination(int index, int[] arr, int target,
                                           IList<IList<int>> ans, IList<int> ds)
        {
            if (target == 0)
            {
                if (!ans.Contains(ds))
                {
                    ans.Add(new List<int>(ds));
                }
                return;
            }

            for (int i = index; i < arr.Length; i++)
            {
                // to remove duplicates 
                if (i > index && arr[i] == arr[i - 1]) continue;
                if (arr[i] > target) break;

                ds.Add(arr[i]);
                FindCombination(i + 1, arr, target - arr[i], ans, ds);
                ds.RemoveAt(ds.Count - 1);
            }
        }

        public static IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            // Not working -> 1st Solution
            // 1st solution -> brute force -> inspired from Combination Sum 1 problem
            //HashSet<IList<int>> ans = new HashSet<IList<int>>();
            //List<int> ds = new List<int>();
            //FindCombination1(0, target, candidates, ans, ds);
            //var result = ans;
            //return result.ToList();

            //2nd solution -> Main solution
            IList<IList<int>> ans = new List<IList<int>>();
            IList<int> ds = new List<int>();
            Array.Sort(candidates);
            FindCombination(0, candidates, target, ans, ds);
            return ans;
        }
    }
}
