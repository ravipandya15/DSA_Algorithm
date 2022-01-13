using System;

namespace CN_Merge_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Merge_Sort");
        }

        private static void merge(int[] arr, int s, int e)
        {
            int mid = s + (e - s) / 2;
            int len1 = mid - s + 1;
            int len2 = e - mid;

            int[] first = new int[len1];
            int[] second = new int[len2];

            int mainArrayIndex = s;
            for (int i = 0; i < len1; i++)
            {
                first[i] = arr[mainArrayIndex++];
            }

            mainArrayIndex = mid + 1;
            for (int i = 0; i < len2; i++)
            {
                second[i] = arr[mainArrayIndex++];
            }

            int index1 = 0;
            int index2 = 0;
            mainArrayIndex = s;
            // merge 2 sorted arrays
            while (index1 < len1 && index2 < len2)
            {
                if (first[index1] < second[index2])
                    arr[mainArrayIndex++] = first[index1++];
                else
                    arr[mainArrayIndex++] = second[index2++];
            }

            while (index1 < len1)
                arr[mainArrayIndex++] = first[index1++];
            while (index2 < len2)
                arr[mainArrayIndex++] = second[index2++];
        }

        private static void solve(int[] arr, int s, int e)
        {
            // base case
            if (s >= e) return;

            int mid = s + (e - s) / 2;
            // Recursion
            // sort left part
            solve(arr, s, mid);
            //sort right part
            solve(arr, mid + 1, e);

            // post processing
            merge(arr, s, e);
        }

        public static void mergeSort(int[] arr, int n)
        {
            solve(arr, 0, n - 1);
        }
    }
}
