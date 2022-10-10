using System;

namespace GFG__Minimum_Platforms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Minimum Platforms");
            int[] arr = new int[] { 120, 50, 550, 200, 700, 850 };
            int[] dep = new int[] { 600, 550, 700, 500, 900, 1000 };
            Console.WriteLine($"minimum platform required are {findPlatForm(arr, dep, arr.Length)}");
            Console.ReadLine();
        }

        public static int findPlatForm(int[] arr, int[] dep, int n)
        {
            Array.Sort(arr);
            Array.Sort(dep);

            int platform = 1, result = 1; // platform indicates at a time how many patforms are required.
            int i = 1, j = 0;

            while (i < n && j < n)
            {
                if (arr[i] <= dep[j])
                {
                    platform++;
                    i++;
                }
                else if (arr[i] > dep[j])
                {
                    platform--;
                    j++;
                }

                if (platform > result)
                    result = platform;
            }
            return result;
        }
    }
}
