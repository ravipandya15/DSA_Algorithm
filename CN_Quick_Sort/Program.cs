using System;
using System.Collections.Generic;

namespace CN_Quick_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Quick_Sort");
        }

        private static int partition(List<int> arr, int s, int e)
        {
            int pivot = arr[s];

            //count no. of element which are smaller than or equal to s;
            int count = 0;
            for (int index = s + 1; index <= e; index++)
            {
                if (arr[index] <= pivot) count++;
            }

            //find proper index;
            int pivotIndex = s + count;

            // swap
            int temp = arr[s];
            arr[s] = arr[pivotIndex];
            arr[pivotIndex] = temp;

            int i = s, j = e;
            while (i < pivotIndex && j > pivotIndex)
            {
                while (arr[i] <= pivot) i++;
                while (arr[j] > pivot) j--;

                if (i < pivotIndex && j > pivotIndex)
                {
                    // swap
                    int tempData = arr[i];
                    arr[i] = arr[j];
                    arr[j] = tempData;
                    i++;
                    j--;
                }
            }

            return pivotIndex;
        }

        private static void solve(List<int> arr, int s, int e)
        {
            if (s >= e) return;

            //do partition
            int p = partition(arr, s, e);

            // Sort left part
            solve(arr, s, p - 1);

            // Sort right part
            solve(arr, p + 1, e);
        }

        public static List<int> quickSort(List<int> arr)
        {
            solve(arr, 0, arr.Count - 1);
            return arr;
        }
    }
}
