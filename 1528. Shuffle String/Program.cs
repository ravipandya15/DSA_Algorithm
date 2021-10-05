using System;

namespace _1528._Shuffle_String
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1528. Shuffle String");
            int[] indices = new int[] { 4, 0, 2, 6, 7, 3, 1, 5 };
            Console.WriteLine($"result string is {RestoreString("aaiougrt", indices)}");
            Console.ReadLine();
        }
            
        public static string RestoreString(string s, int[] indices)
        {
            char[] resultArray = new char[s.Length];
            int i = 0;
            foreach (char value in s)
            {
                resultArray[indices[i]] = value;
                i++;
            }
            return string.Concat(resultArray);
        }
    }
}
