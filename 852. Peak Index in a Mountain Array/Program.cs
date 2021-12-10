using System;

namespace _852._Peak_Index_in_a_Mountain_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("852. Peak Index in a Mountain Array");
            int[] arr = { 3, 4, 5, 1 };
            Console.WriteLine($"Peak index is {PeakIndexInMountainArray(arr)}");
            Console.ReadLine();
        }

        public static int PeakIndexInMountainArray(int[] arr)
        {
            int start = 0;
            int end = arr.Length - 1;
            int mid = start + (end - start) / 2;

            while (start < end)
            {
                if (arr[mid] < arr[mid + 1])
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid;
                }
                // update mid
                mid = start + (end - start) / 2;
            }

            return start;
        }
    }
}
