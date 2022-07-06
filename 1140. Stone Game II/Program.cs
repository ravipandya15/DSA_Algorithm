using System;

namespace _1140._Stone_Game_II
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] piles = { 2, 7, 9, 4, 4 };
            int ans = stoneGameII(piles);
            Console.WriteLine($"ans is {ans}");
        }

        public static int solve(int index, int M, bool flag, int[] piles)
        {
            if (index >= piles.Length) return 0;

            int stones = Int32.MinValue;

            for (int i = 1; i <= 2 * M; i++)
            {
                int temp = 0;
                for (int j = index; j < piles.Length && j < i + index; j++)
                {
                    temp += piles[j];
                }

                temp = temp + solve(index + i, Math.Max(M, i), !flag, piles);
                stones = Math.Max(stones, temp);
            }
            return flag == true ? stones : 0;
        }

        public static int stoneGameII(int[] piles)
        {
            int M = 1;
            bool flag = true;
            return solve(0, M, flag, piles);
        }
    }
}
