using System;

namespace _1221._Split_a_String_in_Balanced_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1221. Split a String in Balanced Strings");
            Console.WriteLine($"Answer is {BalancedStringSplit("RLRRRLLRLL")}");
            Console.ReadLine();
        }

        public static int BalancedStringSplit(string s)
        {
            int result = 0;
            int rCount = 0, lCount = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'R')
                {
                    rCount++;
                }
                else if (s[i] == 'L')
                {
                    lCount++;
                }

                if (rCount == lCount)
                {
                    result++;
                    rCount = 0;
                    lCount = 0;
                }
            }
            return result;
        }
    }
}
