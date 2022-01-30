using System;
using System.Text;

namespace CN_Rearrange_String
{
    class Program
    {

        // -> AMAZON


        static void Main(string[] args)
        {
            Console.WriteLine("CN_Rearrange_String");
            string str = "aaaabbccc";
            Console.WriteLine($"resultant string is {rearrangeString(str)}");
        }

        public static string rearrangeString(string str)
        {
            int[] hash = new int[26];
            int n = str.Length;
            int mostFreq = 0; // index maintains which character is most frequent
            for (int i = 0; i < n; i++)
            {
                int index = str[i] - 'a';
                hash[index]++;
                if (hash[index] > hash[mostFreq])
                {
                    mostFreq = index;
                }
            }

            if (hash[mostFreq] > (n + 1) / 2)
                return "NO SOLUTION";

            char[] result = new char[n];
            int position = 0;
            // start filling most freq. character in even positions (start from 0 based indexing)
            while (hash[mostFreq] > 0)
            {
                result[position] = (char)(mostFreq + (int)'a');
                hash[mostFreq]--;
                position += 2;
            }

            for (int i = 0; i < 26; i++)
            {
                while (hash[i] > 0)
                {
                    if (position >= n) // re- initialize index to fill at odd indexes
                        position = 1;

                    result[position] = (char)(i + (int)'a');
                    hash[i]--;
                    position += 2;
                }
            }

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                builder.Append(result[i]);
            }

            return builder.ToString();
        }
    }
}
