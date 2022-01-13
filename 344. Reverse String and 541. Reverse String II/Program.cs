using System;
using System.Text;

namespace _344._Reverse_String_and_541._Reverse_String_II
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("344._Reverse_String_and_541._Reverse_String_II");
            string s = "abcdefg";
            int k = 2;
            string outputString = ReverseStr(s, k);
            ReverseString_Recursion("abcde");
            Console.ReadLine();
        }

        private static void Recursion(StringBuilder str, int i, int j)
        {
            Console.WriteLine(str.ToString());
            // base case
            if (i > j) return;

            //proccessing
            // swap
            char temp = str[i];
            str[i] = str[j];
            str[j] = temp;
            i++;
            j--;

            //recursive call
            Recursion(str, i, j);
        }

        //using recursion
        public static void ReverseString_Recursion(string str)
        {
            StringBuilder sb = new StringBuilder(str);
            Recursion(sb, 0, str.Length - 1);
            Console.WriteLine($"string is {sb.ToString()}");
        }

        public static void ReverseString(char[] s)
        {
            int left = 0;
            int right = s.Length - 1;

            while (left <= right)
            {
                // swap
                char temp = s[left];
                s[left] = s[right];
                s[right] = temp;
                left++;
                right--;
            }
        }

        public static string ReverseStr(string s, int k)
        {
            if (s == null) return s;
            char[] arr = s.ToCharArray();
            int left = 0;
            int right = k > s.Length ? s.Length - 1 : k-1;

            while (left <= right)
            {
                // swap
                char temp = arr[left];
                arr[left] = arr[right];
                arr[right] = temp;
                left++;
                right--;
            }

            return new string(arr);
        }
    }
}
