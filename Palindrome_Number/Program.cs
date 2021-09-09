using System;

namespace Palindrome_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Print -1 to exit....");
            //while(Console.ReadLine() != "-1")
            //{
                Console.WriteLine("Enter a number");
                int number = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Answer is : " + Program.IsPalindrome(number));
            //}
        }

        public static bool IsPalindrome(int x)
        {
            if (x < 0)
            {
                return false;
            }

            int temp = x;
            int reverse = 0;
            while(temp > 0)
            {
                reverse = reverse * 10 + temp % 10;
                temp /= 10;
            }

            return x == reverse ? true : false;
        }
    }
}
