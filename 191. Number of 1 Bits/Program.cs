using System;

namespace _191._Number_of_1_Bits
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("191. Number of 1 Bits");
            Console.ReadLine();
        }

        public static int HammingWeight(uint n)
        {
            int count = 0;

            while (n != 0)
            {
                //bool temp = Convert.ToBoolean(n & 1);
                count = count + Convert.ToInt32(n & 1);
                n = n >> 1;
            }
            return count;
        }
    }
}
