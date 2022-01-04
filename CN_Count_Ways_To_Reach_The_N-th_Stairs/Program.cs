using System;

namespace CN_Count_Ways_To_Reach_The_N_th_Stairs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CN_Count_Ways_To_Reach_The_N-th_Stairs");
        }


        // famous question -> Adobe, Microsoft, Morgan Stanley, Expedia group
        // will give TLE -> need to do DP.
        public static int countDistinctWayToClimbStair(long nStairs)
        {
            if (nStairs < 0) return 0;
            if (nStairs == 0) return 1;
            return countDistinctWayToClimbStair(nStairs - 1) + countDistinctWayToClimbStair(nStairs - 2);
        }
    }
}
