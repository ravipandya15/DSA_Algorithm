using System;
using System.Text;

namespace Check_If_The_String_Is_A_Palindrome
{
    class Program
    {
        // 125. Valid Palindrome -> LeetCode
        static void Main(string[] args)
        {
            // Stirng is case in sensative
            // if ignore symbols and white space
            Console.WriteLine("Check If The String Is A Palindrome");
            string s = "A man, a plan, a canal: Panama";
            string s1 = "race a car";
            string s3 = ".,";
            Console.WriteLine($"is String is Palindrome or not? {CheckPalindrome(s3)}");
            Console.ReadLine();
        }

        public static char ConvertToLower(char ch)
        {
            if ((ch >= 'a' && ch <= 'z') || ch >= '0' && ch <= '9')
                return ch;
            else
            {
                return (char)(ch - 'A' + 'a');
            }
        }

        public static bool Check(char ch)
        {
            if ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z') || (ch >= '0' && ch <= '9'))
                return true;
            else
                return false;
        }

        public static bool CheckPalindrome(string str)
        {
            StringBuilder s = new StringBuilder();
            int n = str.Length;
            for (int i = 0; i < n; i++)
            {
                if (Check(str[i])) s.Append(str[i]);
            }

            for (int i = 0; i < s.Length; i++)
            {
                s[i] = ConvertToLower(s[i]);
            }

            int l = 0, r = s.Length-1;
            while (l <= r)
            {
                if (s[l] != s[r])
                    return false;
                else
                {
                    l++;
                    r--;
                }
            }
            return true;
        }

        public static bool CheckPalindrome1(string str)
        {
            int s = 0;
            int n = str.Length - 1;
            int e = n;

            while (s <= e)
            {
                while (s <= n && (str[s] < 'a' || str[s] > 'z') &&
                    (str[s] < 'A' || str[s] > 'Z') &&
                    (str[s] < '0' || str[s] > '9'))
                {
                    s++;
                }
                while (e >= 0 && (str[e] < 'a' || str[e] > 'z') &&
                    (str[e] < 'A' || str[e] > 'Z') &&
                    (str[e] < '0' || str[e] > '9'))
                {
                    e--;
                }

                //if ((s > n) || e < 0)
                //    return true;
                if (s > n)
                    break;

                if (ConvertToLower(str[s]) != ConvertToLower(str[e]))
                {
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
    }
}
