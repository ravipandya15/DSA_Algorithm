using System;

namespace Search_and_Element_in_Sorted_and_Rotated_Array
{
    class Program
    {
        // from Coding Ninja's
        static void Main(string[] args)
        {
            // leetcode problem no 33)
            Console.WriteLine("CN) Search_and_Element_in_Sorted_and_Rotated_Array");
            int[] arr = { 7, 8, 1, 3, 5 };
            Console.WriteLine($"ans is {FindPosition(arr, 5, 7)}");

            int[] nums = { 4, 5, 6, 7, 0, 1, 2 };
            Console.WriteLine($"ans is {Search(nums, 0)}");
            Console.ReadLine();
        }

        //technique 2 -> striver
        public static int Search(int[] nums, int target)
        {
            int low = 0;
            int high = nums.Length - 1;
            while (low <= high)
            {
                int mid = (low + high) >> 1;
                if (nums[mid] == target)
                    return mid;

                // either left or right part is sorted (always true)
                //check left part is sorted or not
                if (nums[low] <= nums[mid])
                {
                    if (target >= nums[low] && target <= nums[mid])
                        high = mid - 1;
                    else
                        low = mid + 1;
                }
                else // right part is sorted
                {
                    if (target >= nums[mid] && target <= nums[high])
                        low = mid + 1;
                    else
                        high = mid - 1;
                }
            }
            return -1;
        }

        // technique 1 -> Love bubber
        public static int BinarySearch(int[] arr, int start, int end, int k)
        {
            int mid = start + (end - start) / 2;
            while (start <= end)
            {
                if (arr[mid] == k)
                {
                    return mid;
                }
                else if (arr[mid] < k)
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
                mid = start + (end - start) / 2;
            }
            return -1;
        }

        public static int FindPivot(int[] arr)
        {
            int start = 0;
            int end = arr.Length - 1;
            int mid = start + (end - start) / 2;

            while (start < end)
            {
                if (arr[mid] >= arr[0])
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid;
                }
                mid = start + (end - start) / 2;
            }
            return start;
        }

        public static int FindPosition(int[] arr, int n, int k)
        {
            int pivot = FindPivot(arr);
            if (k >= arr[pivot] && k <= arr[n - 1])
            {// B.S on 2nd Line
                return BinarySearch(arr, pivot, n - 1, k);
            }
            else
            {//B.S on 1st Line
                return BinarySearch(arr, 0, pivot - 1, k);
            }
        }
    }
}
