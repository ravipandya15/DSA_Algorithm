using System;

namespace CN__Allocate_Books
{
    class Program
    {
        // IMP question -> Google, FaceBook, Microsoft, CodeNation
        static void Main(string[] args)
        {
            Console.WriteLine("Allocate Books");
            //int[] arr = { 10, 20, 30, 40 };
            //int[] arr = { 20, 10, 30, 40 };
            int[] arr = { 20, 10, 40, 30 };
            int n = 4; // no of books -> Length of array
            int m = 2; // no. of student
            Console.WriteLine($"Answer is {allocateBooks(arr, n, m)}");
            Console.ReadLine();
        }

        public static bool IsPossible(int[] arr, int n, int m, int mid)
        {
            int studentCount = 1;
            int pageSum = 0;
            for (int i = 0; i < n; i++)
            {
                if (pageSum + arr[i] <= mid)
                {
                    pageSum += arr[i];
                }
                else
                {
                    studentCount++;
                    if (studentCount > m || arr[i] > mid)
                    {
                        return false;
                    }
                    pageSum = 0;
                    pageSum += arr[i]; // instead of that directly we can write pageSum = arr[i]; 
                }
            }

            return true;
        }

        public static int allocateBooks(int[] arr, int n, int m)
        {
            int start = 0;
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += arr[i];
            }
            int end = sum;
            int ans = -1;
            int mid = start + (end - start) / 2;

            while (start <= end)
            {
                if (IsPossible(arr, n, m, mid))
                {
                    ans = mid;
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
                mid = start + (end - start) / 2;
            }
            return ans;
        }
    }
}
