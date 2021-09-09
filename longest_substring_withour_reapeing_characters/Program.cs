using System;
using System.Collections.Generic;
using System.Linq;

namespace longest_substring_withour_reapeing_characters
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string inputString = "dvdf";
            Dictionary<char, int> result = new Dictionary<char, int>();
            HashSet<string> tempSet = new HashSet<string>();
            int max = 0, i = 0, j = 0;
            for (j = 0; j < inputString.Length; j++)
            {
                if (result.TryGetValue(inputString[j], out int tempResult))
                {
                    i = Math.Max(i, tempResult);
                    result[inputString[j]] = j + 1;
                }
                else
                {
                    result.Add(inputString[j], j + 1);
                }

                max = Math.Max(max, j- i + 1);
            }

            
            Console.WriteLine("Max Count is " + max);
            Console.ReadLine();
        }
    }
}
