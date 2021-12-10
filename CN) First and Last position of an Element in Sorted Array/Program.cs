using System;
using System.Collections.Generic;

namespace CN__First_and_Last_position_of_an_Element_in_Sorted_Array
{
    class Program
    {
        // Amazon, Google, Microsoft
        static void Main(string[] args)
        {
            Console.WriteLine("CN__First_and_Last_position_of_an_Element_in_Sorted_Array");
            List<int> arr = new List<int>();
            arr.Add(1);
            arr.Add(2);
            arr.Add(3);
            arr.Add(3);
            arr.Add(3);
            arr.Add(3);
            arr.Add(3);
            arr.Add(3);
            arr.Add(3);
            arr.Add(3);
            arr.Add(4);
            var ans = FirstAndLastPosition(arr, 11, 3);
            Console.ReadLine();
        }

        public static int FindFirstOccurance(List<int> arr, int n, int k)
        {
            int start = 0, end = n - 1;
            int ans = -1;
            int mid = start + (end - start) / 2;

            while(start <= end)
            {
                if (arr[mid] == k)
                {
                    ans = mid;
                    end = mid - 1;
                }
                else if (k > arr[mid])
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }

                mid = start + (end - start) / 2;
            }
            return ans;
        }

        public static int FindLastOccurance(List<int> arr, int n, int k)
        {
            int start = 0, end = n - 1;
            int ans = -1;
            int mid = start + (end - start) / 2;

            while (start <= end)
            {
                if (arr[mid] == k)
                {
                    ans = mid;
                    start = mid + 1;
                }
                else if (k > arr[mid])
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }

                mid = start + (end - start) / 2;
            }
            return ans;
        }

        public static Tuple<int, int> FirstAndLastPosition(List<int> arr, int n, int k)
        {
            return new Tuple<int, int>(FindFirstOccurance(arr, n, k), FindLastOccurance(arr, n, k));
            // to find all occurance of key
            // occuarance = last index - start index + 1;
        }
    }
}
