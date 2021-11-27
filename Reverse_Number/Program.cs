using System;

namespace Reverse_Number
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int input = 0;

            Console.WriteLine("result is : " + Reverse(input));
            Console.ReadLine();
        }

        public static int Reverse(int x)
        {
            int ans = 0;
            while (x != 0)
            {
                int digit = x % 10;
                if ((ans > (Int32.MaxValue / 10)) || (ans < (Int32.MinValue / 10)))
                {
                    return 0;
                }
                ans = (ans * 10) + digit;
                x = x / 10;
            }

            return ans;
        }

        public static int Reverse1(int input)
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
