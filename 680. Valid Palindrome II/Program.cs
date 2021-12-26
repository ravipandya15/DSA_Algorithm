using System;

namespace _680._Valid_Palindrome_II
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("680. Valid Palindrome II");
            string s = "cbbcc";
            string s1 = "bbccb";
            string s2 = "eccer";
            string s3 = "eeccccbebaeeabebccceea";
            string s4 = "abc";
            string s5 = "abca";
            Console.WriteLine($"is String is Palindrome or not? {ValidPalindrome(s5)}");
            Console.ReadLine();
        }

        public static bool Recursion(string str, int s, int e, int count)
        {
            if (count > 1) return false;
            while (s <= e)
            {
                if (str[s] != str[e])
                {
                    count++;
                    if (Recursion(str, s, e - 1, count) || Recursion(str, s + 1, e, count))
                        return true;
                    else
                        return false;
                }
                else
                {
                    s++;
                    e--;
                }
            }
            return true;
        }

        public static bool ValidPalindrome(string str)
        {
            return Recursion(str, 0, str.Length - 1, 0);
        }
    }
}
