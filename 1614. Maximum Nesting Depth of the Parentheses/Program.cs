using System;

namespace _1614._Maximum_Nesting_Depth_of_the_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1614. Maximum Nesting Depth of the Parentheses");
            Console.WriteLine($"Result is {MaxDepth("(1+(2*3)+((8)/4))+1")}");
            Console.ReadLine();
        }

        public static int MaxDepth(string s)
        {
            int max = 0;
            int currentMax = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    max = Math.Max(max, ++currentMax);
                }
                else if (s[i] == ')')
                {
                    currentMax--;
                }
            }
            return max;
        }
    }
}