using System;
using System.Collections.Generic;

namespace _46._Permutations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("46. Permutations");
            int[] arr = { 1, 2, 3 };
            var result = Permute(arr);
            Console.ReadLine();
        }

        // Approach 1
        public static void RecurPermute1(int[] nums, bool[] freq, IList<int> ds, IList<IList<int>> res)
        {
            // base case
            if (ds.Count == nums.Length)
            {
                res.Add(new List<int>(ds));
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if(!freq[i])
                {
                    freq[i] = true;
                    ds.Add(nums[i]);
                    RecurPermute1(nums, freq, ds, res);
                    ds.RemoveAt(ds.Count - 1);
                    freq[i] = false;
                }
            }
        }

        //Approach 1
        public static IList<IList<int>> Permute1(int[] nums)
        {
            IList<IList<int>> res = new List<IList<int>>();
            IList<int> ds = new List<int>();
            bool[] freq = new bool[nums.Length];
            RecurPermute1(nums, freq, ds, res);
            return res;
        }

        // Approach 2
        public static void RecurPermute(int index, int[] nums, IList<IList<int>> ans)
        {
            // base case
            if (index == nums.Length)
            {
                IList<int> ds = new List<int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    ds.Add(nums[i]);
                }
                ans.Add(new List<int>(ds));
                return;
            }

            for (int i = index; i < nums.Length; i++)
            {
                Swap(index, i, nums);
                RecurPermute(index + 1, nums, ans);
                Swap(index, i, nums);
            }
        }

        private static void Swap(int i, int j, int[] nums)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }

        // Approach 2
        public static IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> ans = new List<IList<int>>();
            RecurPermute(0, nums, ans);
            return ans;
        }
    }
}
