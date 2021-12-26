using System;

namespace _443._String_Compression
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("443. String Compression");
            char[] arr = { 'a', 'a', 'b', 'b', 'c', 'c', 'c'};
            Console.WriteLine($"result array length is {Compress(arr)}");
            Console.ReadLine();
        }

        // TC -> O(N)
        // SC -> O(1)
        public static int Compress(char[] chars)
        {
            int i = 0;
            int ansIndex = 0;
            int n = chars.Length;

            while (i < n)
            {
                int j = i + 1;
                while (j < n && chars[i] == chars[j])
                {
                    j++;
                }

                // when we comes here j have some diff character or traversal of full array is completed
                
                // store old character
                chars[ansIndex++] = chars[i];

                int count = j - i;

                if (count > 1)
                {
                    // convert count in string
                    string str = Convert.ToString(count);
                    foreach (char ch in str)
                    {
                        chars[ansIndex++] = ch;
                    }
                }
                // moving to new diff. character
                i = j;
            }
            return ansIndex;
        }
    }
}
