using System;

namespace _50._Pow_x__n_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("50. Pow(x, n)");
            Console.WriteLine($"answer is {MyPow(2, -2)}");
            Console.ReadLine();
        }

        // time complexity -> O(log2 N) as we are dividing n by 2 for even and for odd we are reducing but in next step again it becomes even so we divide.
        // space complexity -> O(1)
        public static double MyPow(double x, int n)
        {
            double ans = 1.0;
            long nn = n;
            if (nn < 0)
                nn = -1 * nn;

            while(nn > 0)
            {
                if (nn % 2 == 1)
                {
                    ans = ans * x;
                    nn = nn - 1;
                }
                else
                {
                    x = x * x;
                    nn = nn / 2;
                }
            }

            if (n < 0)
            {
                ans = (double)(1.0) / (double)ans;
            }
            return ans;
        }
    }
}
