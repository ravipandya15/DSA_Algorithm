using System;
using System.Collections.Generic;

namespace _1207._Unique_Number_of_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1207. Unique Number of Occurrences");
            int[] arr = new int[] { -3, 0, 1, -3, 1, 1, 1, 10, 0 };
            Console.WriteLine($"Answer is {UniqueOccurrences(arr)}");
            Console.ReadLine();
        }

        public static bool UniqueOccurrences(int[] arr)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (int i in arr)
            {
                if (dict.TryGetValue(i, out int temp))
                    dict[i] = temp + 1;
                else
                    dict.Add(i, 1);
            }

            return dict.Count == new HashSet<int>(dict.Values).Count;
        }
    }
}
