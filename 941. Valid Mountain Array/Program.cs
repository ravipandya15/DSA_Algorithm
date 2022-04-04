using System;

namespace _941._Valid_Mountain_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("941. Valid Mountain Array");
            int[] arr = { 1, 3, 2 };
            int n = 3;
            bool result = ValidMountainArray(arr);

        }

        public static bool ValidMountainArray(int[] arr)
        {
            int i = 0;
            int n = arr.Length;

            //walk up
            while (i + 1 < n && arr[i] < arr[i + 1])
                i++;

            // peak can't be first or last
            if (i == 0 || i == n - 1) return false;

            // walk down
            while (i + 1 < n && arr[i] > arr[i + 1])
                i++;

            return i == n - 1;
        }



        public static bool ValidMountainArray_1(int[] arr)
        {
            int i = 0;
            int n = arr.Length;
            bool flag = false;
            for (i = 1; i < n; i++)
            {
                if (arr[i] == arr[i - 1]) return false;
                if (arr[i] > arr[i - 1]) flag = true;
                else break;
            }

            if (flag == false || i == n)
            {
                return false;
            }

            flag = false;

            while (i < n)
            {
                if (arr[i] > arr[i - 1] || arr[i] == arr[i - 1])
                {
                    return false;
                }
                i++;
            }

            return true;
        }
    }
}
