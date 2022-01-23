using System;
using System.Collections.Generic;

namespace All_Kind_Of_Recursion_Pattens
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Print_All_Recursion_Whose_Sum_is_K");
            int[] arr = new int[] { 1, 2, 1 };
            int sum = 2;

            var result1 = printAllRecursion(arr, sum);

            var result2 = printAnyOneRecursion(arr, sum);

            var result3 = countSubSeqencesWithSumK(arr, sum);

        }

        public static void solve1(int index, int[] arr, int sum, int s, IList<IList<int>> output,
                                List<int> result, int n)
        {
            // base condition
            if (index == n)
            {
                if (sum == s)
                    output.Add(new List<int>(result));
                return;
            }


            // include
            s += arr[index];
            result.Add(arr[index]);
            solve1(index + 1, arr, sum, s, output, result, n);
            result.RemoveAt(result.Count - 1);
            s -= arr[index];

            // exclude
            solve1(index + 1, arr, sum, s, output, result, n);
        }

        //Print_All_Recursion_Whose_Sum_is_K
        //patern 1
        public static IList<IList<int>> printAllRecursion(int[] arr, int sum)
        {
            IList<IList<int>> output = new List<IList<int>>();
            List<int> result = new List<int>();
            solve1(0, arr, sum, 0, output, result, arr.Length);
            return output;
        }

        public static bool solve2(int index, int[] arr, int sum, int s, IList<IList<int>> output,
                                List<int> result, int n)
        {
            // base condition
            if (index == n)
            {
                if (sum == s)
                {
                    output.Add(new List<int>(result));
                    return true;
                }
                return false;
            }


            // include
            s += arr[index];
            result.Add(arr[index]);
            if (solve2(index + 1, arr, sum, s, output, result, n) == true)
                return true;

            result.RemoveAt(result.Count - 1);
            s -= arr[index];

            // exclude
            if (solve2(index + 1, arr, sum, s, output, result, n) == true)
                return true;

            return false;
        }

        //Print_Any_One_Recursion_Whose_Sum_is_K
        // patern 2
        public static IList<IList<int>> printAnyOneRecursion(int[] arr, int sum)
        {
            IList<IList<int>> output = new List<IList<int>>();
            List<int> result = new List<int>();
            solve2(0, arr, sum, 0, output, result, arr.Length);
            return output;
        }

        public static int solve3(int index, int[] arr, int sum, int s, int n)
        {
            // base condition
            if (index == n)
            {
                // condition satisfied
                if (sum == s)
                {
                    return 1;
                }
                // condition not satisfied
                return 0;
            }


            // include
            s += arr[index];
            int left = solve3(index + 1, arr, sum, s, n);
            s -= arr[index];

            // exclude
            int right = solve3(index + 1, arr, sum, s, n);

            return left + right;
        }

        // Count the subsequences with sum k
        // patern 3
        public static int countSubSeqencesWithSumK(int[] arr, int sum)
        {
            return solve3(0, arr, sum, 0, arr.Length);
        }
    }
}
