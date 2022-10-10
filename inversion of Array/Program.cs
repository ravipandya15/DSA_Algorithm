using System;

namespace inversion_of_Array
{
    class Program
    {
        // not there in Leetcode
        // available in CodeNinjas
        static void Main(string[] args)
        {
            Console.WriteLine("inversion of Array");
            int[] arr = { 5, 3, 2, 4, 1 };
            Console.WriteLine($"result is {getInversions(arr, 5)}");
            Console.ReadLine();
        }

        // time complexity -> O(N*logN)
        // space complexity -> O(N)
        public static int merge(int[] arr,int[] temp, int left, int mid, int right)
        {
            // we passed mid + 1
            // so left to mid - 1 is left-array and mid to right is right-array
            int inv_Count = 0;
            int i = left;
            int j = mid;
            int k = left; // pointer to add data in temp array and at last we copy data from temp to original arr array.

            while ((i <= mid - 1) && (j <= right))
            {
                if (arr[i] <= arr[j])
                {
                    temp[k++] = arr[i++];
                }
                else
                {
                    temp[k++] = arr[j++];
                    inv_Count += mid - i;
                }
            }

            while (i <= mid - 1)
            {
                temp[k++] = arr[i++];
            }

            while (j <= right)
            {
                temp[k++] = arr[j++];
            }

            for (i = left; i <= right; i++)
            {
                arr[i] = temp[i];
            }

            return inv_Count;
        }

        public static int mergeSort(int[] arr, int[] temp, int left, int right)
        {
            int inv_Count = 0;

            if (right > left) // left <= right
            {
                int mid = (left + right) / 2; // left + (right - left) / 2;
                inv_Count = mergeSort(arr,temp, left, mid);
                inv_Count += mergeSort(arr,temp, mid + 1, right);
                inv_Count += merge(arr, temp, left, mid + 1, right);
            }

            return inv_Count;
        }
        public static int getInversions(int[] arr, int n)
        {
            // Write your code here.
            int[] temp = new int[n];
            return mergeSort(arr, temp, 0, n - 1);
        }
    }
}
