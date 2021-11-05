using System;
using System.Collections.Generic;

namespace _1496._Path_Crossing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1496. Path Crossing");
            Console.WriteLine($"result is {IsPathCrossing("NESWW")}");
            Console.ReadLine();
        }

        public static bool IsPathCrossing(string path)
        {
            (int x, int y) current = (0, 0);
            // In C#, HashSet is an unordered collection of unique elements.
            HashSet<(int x, int y)> set = new HashSet<(int x, int y)>();
            set.Add(current);
            foreach (char c in path)
            {
                if (c == 'N')
                {
                    current.y++;
                }
                else if (c == 'S')
                {
                    current.y--;
                }
                else if (c == 'E')
                {
                    current.x++;
                }
                else if (c == 'W')
                {
                    current.x--;
                }

                if (!set.Add(current))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
