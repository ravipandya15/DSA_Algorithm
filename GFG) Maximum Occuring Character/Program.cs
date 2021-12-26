using System;

namespace GFG__Maximum_Occuring_Character
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GFG) Maximum Occuring Character");
            while (true)
            {
                Console.WriteLine("Enter string");
                string str = Console.ReadLine();
                Console.WriteLine($"Maximum occuring character is {getMaxOccuringChar(str)}");
            }
        }

        public static char getMaxOccuringChar(string s)
        {
            int[] arr = new int[26];

            for (int i = 0; i < s.Length; i++)
            {
                int ch = s[i] - 'a'; // will get number from 0 to 25
                arr[ch]++;
            }

            int maxi = -1;
            int ans = 0;
            for (int i = 0; i < 26; i++)
            {
                if (arr[i] > maxi)
                {
                    maxi = arr[i];
                    ans = i; // get number [0-25] for which count is maximum
                }
            }

            return (char)(ans + 'a');
        }
    }
}
