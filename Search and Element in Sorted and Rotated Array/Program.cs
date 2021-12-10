using System;

namespace Search_and_Element_in_Sorted_and_Rotated_Array
{
    class Program
    {
        // from Coding Ninja's
        static void Main(string[] args)
        {
            Console.WriteLine("CN) Search_and_Element_in_Sorted_and_Rotated_Array");
            int[] arr = { 7, 8, 1, 3, 5 };
            Console.WriteLine($"ans is {FindPosition(arr, 5, 7)}"); 
            Console.ReadLine();
        }

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
