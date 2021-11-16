using System;
using System.Collections.Generic;

namespace _493._Reverse_Pairs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("493. Reverse Pairs");
            int[] nums = new int[] { 40, 25, 19, 12, 9, 6, 2};
            Console.WriteLine($"Answer is {ReversePairs(nums)}");
            Console.ReadLine();
        }

        public static int Merge(int[] nums, int low, int mid, int high)
        {
            int count = 0;
            int j = mid + 1;

            for (int i = low; i <= mid; i++)
            {
                while(j <= high && nums[i] > (2 * (long)nums[j])) // here we need to convert it in long any how otherwise 2,147,483,647 will not work as we multiple it by 2 so ArrayIndexOutOfBoundException occurs.
                {
                    j++;
                }
                count += j - (mid + 1);
            }

            List<int> temp = new List<int>();
            int left = low, right = mid + 1;
            while(left <= mid && right <= high)
            {
                if (nums[left] <= nums[right])
                    temp.Add(nums[left++]);
                else
                    temp.Add(nums[right++]);
            }

            while (left <= mid)
                temp.Add(nums[left++]);

            while (right <= high)
                temp.Add(nums[right++]);

            for (int i = low; i <= high; i++)
            {
                nums[i] = temp[i - low];
            }

            return count;
        }

        public static int MergeSort(int[] nums, int low, int high)
        {
            if (low >= high) // for array containing only 1 element
                return 0;

            int mid = (low + high) / 2;

            int count = MergeSort(nums, low, mid);
            count += MergeSort(nums, mid+1, high);
            count += Merge(nums, low, mid, high);
            return count;
        }

        public static int ReversePairs(int[] nums)
        {
            return MergeSort(nums, 0, nums.Length - 1);
        }
    }
}
