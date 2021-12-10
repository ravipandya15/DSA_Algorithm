using System;
using System.Collections.Generic;

namespace Find_Array_Intersection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Find Intersection of Array");
            Console.ReadLine();
        }

        public static List<int> FindIntersectionOfArray(int[] arr1, int[] arr2)
        {
            List<int> ans = new List<int>();

            int i = 0, j = 0;
            while (i < arr1.Length && j < arr2.Length)
            {
                if (arr1[i] == arr2[j])
                {
                    ans.Add(arr1[i]);
                    i++;
                    j++;
                }
                else if (arr1[i] < arr2[j])
                {
                    i++;
                }
                else
                {
                    j++;
                }
            }

            return ans;
        }
    }
}
