using System;

namespace CN__Binary_Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string s = "100";
            string result = binaryShopping(s, 3);
            Console.ReadLine();
        }

        public static string binaryShopping(string S, int P)
        {
            int time = 0, count = 0;
            int n = S.Length - 1;
            char[] ch = S.ToCharArray();
            for (int i = 0; i < n; i++)
            {
                if (ch[i] == '1')
                    count++;
            }
            if (count == 0) return S;
            if (count == 1)
            {
                int i = 0, j = n;
                while (i < j)
                {
                    if (ch[j] =='1')
                    {
                        ch[j] = '0';
                        ch[i] = '1';
                        break;
                    }
                    i++;
                    j--;
                }
            }
            if (count >= 2)
            {
                for (int i = n; i >= 0; i--)
                {
                    if (time >= 2)
                        break;

                    if (ch[i] == '1')
                    {
                        ch[i] = '0';
                        time++;
                    }
                }
            }
            

            return new string(ch);
        }
    }
}
