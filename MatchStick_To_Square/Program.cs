using System;
using System.Linq;

namespace MatchStick_To_Square
{
    class Program
    {
        public static bool isSquare = false;
        public static bool DFS(int[] matchStick, int[] currentArray, int pointer)
        {
            if (currentArray.All(x => x == 0))
            {
                return true;
            }
            int cursor = matchStick[pointer];

            for (int i = 0; i < 4; i++)
            {
                if (currentArray[i] - cursor >= 0)
                {
                    currentArray[i] = currentArray[i] - cursor;
                    isSquare = DFS(matchStick, currentArray, pointer + 1);
                    if (isSquare) return true;   
                    currentArray[i] = currentArray[i] + cursor;
                }
            }
            return false;
        }
        public static bool Makesquare(int[] matchsticks)
        {
            int length = matchsticks.Length;
            int sum = matchsticks.Sum();
            if (sum % 4 != 0)
            {
                return false;
            }
            int size = sum / 4;
            if (matchsticks.Any(x => x > size))
            {
                return false;
            }

            Array.Sort(matchsticks);
            Array.Reverse(matchsticks);

            int[] currentArray =  { size, size, size, size };
            return DFS(matchsticks, currentArray, 0);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Matchstick to square");
            while (true)
            {
                Console.WriteLine("Enter length of matchstick array");
                int n = Convert.ToInt32(Console.ReadLine());
                int[] matchStrick = new int[n];
                Console.WriteLine($"Enter {n} times...");
                for (int i = 0; i < n; i++)
                {
                    matchStrick[i] = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine($"matchstick array is...");
                for (int i = 0; i < n; i++)
                {
                    Console.Write(matchStrick[i] + " ");
                }
                bool ans = Makesquare(matchStrick);
                Console.WriteLine($"MatchStrick is possible ? : {ans}");
            }
            Console.ReadLine();
        }
    }
}
