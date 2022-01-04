using System;

namespace Say_Digit
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Say_Digit");
        }

        // Normal question from Cpdehelp -> Love bubber -> Lecture 32 -> Recursion
        // string[] contains {"One", "Two", "Three", .........., "Nine"}
        void sayDigit(int n, string[] arr)
        {
            if (n == 0) return;
            int digit = n % 10;
            n /= 10;
            sayDigit(n, arr);
            Console.WriteLine(arr[digit] + " ");
        }
    }
}
