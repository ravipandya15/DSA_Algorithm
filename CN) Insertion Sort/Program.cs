using System;

namespace CN__Insertion_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN) Insertion Sort");
            int[] arr = { 10, 1, 7, 4, 8, 2, 11 };
            int n = 7;
            InsertionSort(n, arr);
            Console.ReadLine();
        }

        public static void InsertionSort(int n, int[] arr)
        {
            for (int i = 1; i < n; i++)
            {
                int temp = arr[i];
                int j = i - 1;
                for (; j>= 0; j--)
                {
                    if (arr[j] > temp)
                    {
                        // shift
                        arr[j + 1] = arr[j];
                    }
                    else
                    {
                        break;
                    }
                }
                arr[j + 1] = temp;
            }
        }
    }
}
