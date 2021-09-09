using System;

namespace Container_With_Most_Water
{
    class Program
    {
        public static int MaxArea(int[] height)
        {
            int maxArea = 0, left = 0, right = height.Length - 1;
            while (left < right)
            {
                maxArea = Math.Max(maxArea, Math.Min(height[left], height[right]) * (right - left));
                if (height[left] > height[right])
                {
                    right--;
                }
                else
                {
                    left++;
                }
            }

            return maxArea;
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Container with Most water");
            while(true)
            {
                Console.WriteLine("Enter length of array");
                int n = Convert.ToInt32(Console.ReadLine());
                int[] hight = new int[n];
                Console.WriteLine("Enter value one by one");
                for (int i = 0; i < n; i++)
                {
                    hight[i] = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine("Water array is...");
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine(hight[i] + " ");
                }
                Console.WriteLine();
                Console.WriteLine($"max area covered is {MaxArea(hight)}");
            }
        }
    }
}
