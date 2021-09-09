using System;
using System.Collections.Generic;

namespace BackSpace_String_Compare
{
    class Program
    {

        public static string build(string inputString)
        {
            Stack<char> ans = new Stack<char>();
            foreach (char c in inputString)
            {
                if (c != '#')
                {
                    ans.Push(c);
                }
                else if (ans.Count != 0)
                {
                    ans.Pop();
                }
            }
            return new string(ans.ToArray());
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Backspacing String Compare... here # indicates backspace");
            int a = 0;
            Console.WriteLine("Enter -1 to terminate or continue.... :");
            a = Convert.ToInt32(Console.ReadLine());
            while (a != -1)
            {
                Console.WriteLine("Enter string s :");
                string s = Console.ReadLine();
                Console.WriteLine("Enter string t :");
                string t = Console.ReadLine();
                string outputS = build(s);
                string outputT = build(t);
                bool result = outputS.Equals(outputT);
                Console.WriteLine("Output is : " + result);
            }
            
        }
    }
}
