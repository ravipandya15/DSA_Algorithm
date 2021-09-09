using System;

namespace Implement_strStr__
{
    class Program
    {
        public static int StrStr(string haystack, string needle)
        {
            int result = -1;
            if (!haystack.Contains(needle))
                return result;

            //result = 0;
            int index = haystack.IndexOf(needle);
            //int count = needle.Length;
            //int i = 0;
            //while (count > 0)
            //{
            //    if (haystack[index] == needle[i])
            //    {
            //        result++;
            //        i++;
            //    }
            //    else
            //    {
            //        return result;
            //    }

            //    count--;
            //}

            return index;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Implement_strStr");
            string str1 = "";
            string str2 = "";
            Console.WriteLine($"result is {StrStr(str1, str2)}");
            Console.ReadLine();
        }
    }
}
