using System;

namespace _540._Single_Element_in_a_Sorted_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("540. Single Element in a Sorted Array");
            int[] arr = { 1, 1, 2, 3, 3, 4, 4, 8, 8 };
            Console.WriteLine($"value is {SingleNonDuplicate(arr)}");
            Console.ReadLine();
        }

        // TC -> O(N)
        // SC -> O(1)
        public static int SingleNonDuplicate(int[] nums)
        {
            int low = 0;
            int high = nums.Length - 2;

            while (low <= high)
            {
                int mid = (low + high) >> 1;
                if (nums[mid] == nums[mid ^ 1])
                    low = mid + 1;
                else
                    high = mid - 1;
            }
            return nums[low];
        }
    }
}
