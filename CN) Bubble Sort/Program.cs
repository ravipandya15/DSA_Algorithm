using System;

namespace CN__Bubble_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bubble Sort");
            int[] arr = { 3, 4, 1, 9, 12, 2, 6 };
            bubbleSort(arr, 7);
            Console.ReadLine();
        }

        public static void bubbleSort(int[] arr, int n)
        {
            for (int i = 1; i < n; i++)
            {
                // improvement for best time complexity O(N)
                bool swapped = false;
                for (int j = 0; j < n - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        // swap
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;

                        // update flag
                        swapped = true;
                    }
                }

                if (swapped == false)
                    break;
            }
        }
    }
}
