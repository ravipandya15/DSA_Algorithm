using System;

namespace Smallest_Value_of_the_Rearranged_Number_2165
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Smallest_Value_of_the_Rearranged_Number_2165");
        }

        private static void reverse(char[] ch)
        {
            int i = 0;
            int j = ch.Length - 1;
            while (i <= j)
            {
                char temp = ch[i];
                ch[i] = ch[j];
                ch[j] = temp;
                i++;
                j--;
            }
        }

        public static long SmallestNumber(long num)
        {
            char[] str = Math.Abs(num).ToString().ToCharArray();
            Array.Sort(str);
            if (num < 0)
            {
                reverse(str);
            }

            if (num > 0)
            {
                int index = 0;
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] != '0')
                    {
                        index = i;
                        break;
                    }
                }
                char temp = str[0];
                str[0] = str[index];
                str[index] = temp;
            }

            long ans = long.Parse(str);
            if (num < 0)
            {
                ans = ans * -1;
            }

            return ans;
        }
    }
}
