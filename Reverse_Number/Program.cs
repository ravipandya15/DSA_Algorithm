using System;

namespace Reverse_Number
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int input = 0;

            Console.WriteLine("result is : " + Program.Reverse(input));
            Console.ReadLine();
        }

        public static int Reverse(int input)
        {
            string inputString = string.Empty;
            bool isNegative = false;
            int carry = 0, result;
            if (input == 0)
            {
                return 0;
            }
            if (input < 0)
            {
                input = -input;
                isNegative = true;
            }

            while (input > 0)
            {
                carry = input % 10;
                input = input / 10;
                inputString = inputString.Insert(inputString.Length, carry.ToString());
            }

            if (!string.IsNullOrWhiteSpace(inputString) && inputString[0] == '0')
            {
                inputString = inputString.Substring(1);
            }

            try
            {
                result = Convert.ToInt32(inputString);
                if (isNegative)
                {
                    result = -result;
                }
            }
            catch (Exception e)
            {
                result = 0;
            }

            return result;
        }
    }
}
