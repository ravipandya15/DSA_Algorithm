using System;
using System.Collections.Generic;
using System.Linq;

namespace GFG__Subset_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GFG) Subset Sum");
            int[] arr = new int[] { 3, 1, 2 };
            var answer = FindSubsetSum(arr, 3);
            Console.ReadLine();
        }

        // TC -> O(2^N) + O(2^Nlog(2^N))
        // SC-> O(2^N)
        public static void function(int index, int sum, int[] arr, int n, List<int> resultList)
        {
            if (index == n)
            {
                resultList.Add(sum);
                return;
            }
            // pick the element
            function(index + 1, sum + arr[index], arr, n, resultList);

            // not pick element
            function(index + 1, sum, arr, n, resultList);
        }

        public static List<int> FindSubsetSum(int[] arr, int n)
        {
            List<int> resultList = new List<int>();
            function(0, 0, arr, n, resultList);
            resultList.Sort();
            return resultList.Distinct().ToList();
        }
    }
}
