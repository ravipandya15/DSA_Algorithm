using System;
using System.Text;

namespace _1678._Goal_Parser_Interpretation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1678. Goal Parser Interpretation");
            Console.WriteLine($"Result string is {Interpret("G()()()()(al)")}");
            Console.ReadLine();
        }

        public static string Interpret(string command)
        {
            StringBuilder resultString = new StringBuilder();
            for (int i = 0; i < command.Length; i++)
            {
                if (command[i] == 'G')
                {
                    resultString.Append('G');
                }
                else if (command[i] == '(' && command[i+1] == ')')
                {
                    resultString.Append('o');
                    i++;
                }
                else if (command[i] == '(' && command[i+1] == 'a' && command[i + 2] == 'l' && command[i + 3] == ')')
                {
                    resultString.Append("al");
                    i = i + 3;
                }
            }
            return resultString.ToString();
        }
    }
}
