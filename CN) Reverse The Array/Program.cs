using System;
using System.Collections.Generic;

namespace CN__Reverse_The_Array
{
    class Program
    {
        // Revserse array from specific index
        static void Main(string[] args)
        {
            Console.WriteLine("Reverse The Array");
            List<int> arr = new List<int>();
            arr.Add(1);
            arr.Add(2);
            arr.Add(3);
            arr.Add(4);
            arr.Add(5);
            arr.Add(6);

            ReverseArray(arr, 2); // consider 0 based indexing -> so from index 3
            Console.ReadLine();
        }

        public static void ReverseArray(List<int> arr, int m)
        {
            int s = m + 1, e = arr.Count - 1;

            while (s <= e)
            {
                // swap arr[s] with arr[e]
                int temp = arr[s];
                arr[s] = arr[e];
                arr[e] = temp;
                s++;
                e--;
            }
        }
    }
}
