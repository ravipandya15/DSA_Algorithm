using System;
using System.Text;

namespace _1108._Defanging_an_IP_Address
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1108._Defanging_an_IP_Address");
            string resultString = DefangIPaddr("255.100.50.0");
            Console.WriteLine($"Result String is {resultString}");
            Console.ReadLine();
        }

        public static string DefangIPaddr(string address)
        {
            StringBuilder resultString = new StringBuilder();
            foreach (char value in address)
            {
                if (value == '.')
                {
                    resultString.Append($"[{value}]");
                }
                else
                {
                    resultString.Append(value);
                }
            }
            return resultString.ToString();
        }
    }
}
