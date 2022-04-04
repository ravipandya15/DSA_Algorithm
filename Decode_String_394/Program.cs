using System;
using System.Collections.Generic;

namespace Decode_String_394
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Decode_String_394");
            string str = "3[a]2[bc]";
            string str2 = "3[a2[c]]";
            string str3 = "2[abc]3[cd]ef";

            string ans1 = decodeString(str);
            string ans2 = decodeString(str2);
            string ans3 = decodeString(str3);
        }

        public static string repeat(string s, int num)
        {
            string ans = "";
            for (int i = 0; i < num; i++)
            {
                ans = ans + s;
            }
            return ans;
        }

        public static string decodeString(string s)
        {
            int curNum = 0;
            string curString = "";
            Stack<int> stInt = new Stack<int>();
            Stack<string> stString = new Stack<string>();

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '[')
                {
                    stInt.Push(curNum);
                    stString.Push(curString);
                    curNum = 0;
                    curString = "";
                }
                else if (s[i] == ']')
                {
                    int prevNum = stInt.Peek();
                    string prevString = stString.Peek();
                    stInt.Pop();
                    stString.Pop();
                    curString = prevString + repeat(curString, prevNum);
                }
                else if (Char.IsDigit(s[i]))
                {
                    curNum = curNum * 10 + (s[i] - '0');
                }
                else
                {
                    curString = curString + s[i];
                }
            }

            return curString;
        }
    }
}
