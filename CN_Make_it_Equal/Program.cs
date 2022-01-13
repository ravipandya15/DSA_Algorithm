using System;

namespace CN_Make_it_Equal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Make_it_Equal");
            int move = makeItEqual(2,3,5);
            Console.ReadLine();
        }

        public static int makeItEqual(int a, int b, int c)
        {
            int move = 0;
            while (a != 0 || b != 0 || c != 0)
            {
                int mask = c & 1;
                if ((a & 1) == 1 && (b & 1) == 1)
                {
                    if (mask == 0)
                    {
                        move = move + 1;
                    }
                }
                else if (((a & 1) == 1 && (b & 1) == 0) ||
                         ((a & 1) == 0 && (b & 1) == 1))
                {
                    if (mask == 1)
                    {
                        move = move + 1;
                    }
                }
                else if ((a & 1) == 0 && (b & 1) == 0)
                {
                    if (mask == 1)
                    {
                        move = move + 2;
                    }
                }
                c = c >> 1;
                b = b >> 1;
                a = a >> 1;
            }

            while (a != 0 || b != 0)
            {

            }
            return move;
        }
    }
}
