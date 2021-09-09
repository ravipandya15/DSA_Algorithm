using System;
using System.Collections.Generic;

namespace Telephone_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            IDictionary<char, string> dictinary = new Dictionary<char, string>();
            dictinary.Add('2', "abc");
            dictinary.Add('3', "def");
            dictinary.Add('4', "ghi");
            dictinary.Add('5', "jkl");
            dictinary.Add('6', "mno");
            dictinary.Add('7', "pqrs");
            dictinary.Add('8', "tuv");
            dictinary.Add('9', "wxyz");

            Console.WriteLine("Enter digit : ");
            string digit = "23";
        }
    }
}
