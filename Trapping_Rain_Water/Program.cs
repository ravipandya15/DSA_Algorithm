using System;

namespace Trapping_Rain_Water
{
    class Program
    {
        //Input: height = [0,1,0,2,1,0,1,3,2,1,2,1]
        //Output: 6
        //Explanation: The above elevation map(black section) is represented by 
        //array[0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1]. In this case, 
        //6 units of rain water (blue section) are being trapped.

        //using array to store left_max and right_max
        //time_complexity = O(n), space_complexity O(n)
        public static int Trap1(int[] height)
        {
            if (height.Length == 0)
            {
                return 0;
            }
            int ans = 0;
            int[] left_max = new int[height.Length];
            int[] right_max = new int[height.Length];
            left_max[0] = height[0];
            right_max[height.Length - 1] = height[height.Length - 1];
            for (int i = 1; i < height.Length; i++)
            {
                left_max[i] = Math.Max(height[i], left_max[i - 1]);
            }
            for (int i = height.Length - 2; i >= 0; i--)
            {
                right_max[i] = Math.Max(height[i], right_max[i + 1]);
            }
            for (int i = 0; i < height.Length; i++)
            {
                ans += Math.Min(left_max[i], right_max[i]) - height[i];
            }
            return ans;
        }

        // using dynamic programming
        //time_complexity = O(n), space_complexity O(1)
        public static int Trap(int[] height)
        {
            if (height.Length == 0)
            {
                return 0;
            }
            int ans = 0;
            int left = 0, right = height.Length - 1;
            int left_max = 0, right_max = 0;
            while (left <= right)  // only < will also works
            {
                if (height[left] <= height[right])  // only < will also works
                {
                    if (height[left] >= left_max)
                    {
                        left_max = height[left];
                    }
                    else
                    {
                        ans += (left_max - height[left]);
                    }
                    left++;
                }
                else
                {
                    if (height[right] >= right_max)
                    {
                        right_max = height[right];
                    }
                    else
                    {
                        ans += (right_max - height[right]);
                    }
                    right--;
                }
            }
            return ans;
        }



        static void Main(string[] args)
        {
            Console.WriteLine("Trapping Rain Water");
            //Console.WriteLine("Enter length of an array..");
            //int n = Convert.ToInt32(Console.ReadLine());
            //int[] height = new int[n];
            int[] height = { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            //for (int i = 0; i< height.Length; i++)
            //{
            //    height[i] = Convert.ToInt32(Console.ReadLine());
            //}
            Console.WriteLine("height array is...");
            for (int i = 0; i < height.Length; i++)
            {
                Console.WriteLine($"{height[i]}  ");
            }
            Console.WriteLine();
            Console.WriteLine($"answer is {Trap(height)}");
        }
    }
}
