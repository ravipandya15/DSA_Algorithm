using System;

namespace CN__Selection_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN__Selection_Sort");
            int[] arr = { 64, 25, 12, 22, 11 };
            SelectionSort(arr, arr.Length);
            Console.WriteLine("After sorting");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }
            Console.ReadLine();
        }

        public static void SelectionSort(int[] arr, int n)
        {
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[minIndex])
                        minIndex = j;
                }
                // swap minIndex with i;
                int temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;
            }
        }
    }
}
