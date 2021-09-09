using System;
using System.Collections.Generic;
using System.Linq;

namespace Two_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = new int[3] { 3, 2, 4};
            int target = 6;
            int[] resultArray;
            Dictionary<int, int> result = new Dictionary<int, int>();

            for (int i = 0; i < input.Length; i++)
            {
                int complement = target - input[i];
                if (result.TryGetValue(complement, out int temp))
                {
                    resultArray = new int[2] { temp, i};
                }
                result.Add(input[i], i);
            }

            //Console.WriteLine(resultArray[0]);
            //Console.WriteLine(resultArray[1]);

            Console.ReadLine();
        }
    }
}
