using System;

namespace Find_Pivot_in_an_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Find Pivot in an Array");
            int[] arr = { 3, 8, 0, 17, 1 };
            Console.WriteLine($"Pivot element (index) is {FindPivotElement(arr)}");
            Console.ReadLine();
        }

        // TC -> O(Log(n))
        // will return index of minimum value
        public static int FindPivotElement(int[] arr)
        {
            int start = 0;
            int end = arr.Length - 1;
            int mid = start + (end - start) / 2;
            while(start < end)
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
    }
}
