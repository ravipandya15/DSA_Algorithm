using System;

namespace _75._Sort_Colors
{
    class Program
    {
        //Given an array nums with n objects colored red, white, or blue, sort them in-place so that objects of the same color are adjacent, with the colors in the order red, white, and blue.
        //We will use the integers 0, 1, and 2 to represent the color red, white, and blue, respectively.
        //You must solve this problem without using the library's sort function.
        static void Main(string[] args)
        {
            Console.WriteLine("75. Sort Colors");
            int[] nums = new int[] { 2, 0, 2, 1, 1, 0 };
            SortColors1(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write($"{nums[i]} ");
            }
            Console.ReadLine();
        }

        // O(N ^ 2)
        //public static void SortColors(int[] nums)
        //{
        //     2 for loop
        //}

        // O(N*LogN)
        // using quick or merge sort

        // O(N) + O(N) == O(2N)
        public static void SortColors1(int[] nums)
        {
            int countOfZero = 0, countOfOne = 0, countOfTwo = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                switch (nums[i])
                {
                    case 0:
                        countOfZero++;
                        break;
                    case 1:
                        countOfOne++;
                        break;
                    case 2:
                        countOfTwo++;
                        break;
                }
            }
            int j = 0;
            while (countOfZero > 0)
            {
                nums[j] = 0;
                j++;
                countOfZero--;
            }
            while (countOfOne > 0)
            {
                nums[j] = 1;
                j++;
                countOfOne--;
            }
            while (countOfTwo > 0)
            {
                nums[j] = 2;
                j++;
                countOfTwo--;
            }
        }

        // Dutch National Flag Algorithm
        // from index 0 to low -1 => all are 0
        // from index low to high => all are 1
        // from index high+1 to nums.Length -1 => all are two
        public static void SortColors(int[] nums)
        {
            int low = 0, mid = 0, high = nums.Length - 1;
            int temp;
            while (mid <= high)
            {
                switch (nums[mid])
                {
                    case 0:
                        temp = nums[low];
                        nums[low] = nums[mid];
                        nums[mid] = temp;
                        low++;
                        mid++;
                        break;
                    case 1:
                        mid++;
                        break;
                    case 2:
                        temp = nums[mid];
                        nums[mid] = nums[high];
                        nums[high] = temp;
                        high--;
                        break;
                }
            }
        }
    }
}
