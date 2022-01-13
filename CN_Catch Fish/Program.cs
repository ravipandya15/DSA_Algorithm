using System;

namespace CN_Catch_Fish
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Catch Fish");
            int[] arr = new int[] { 1, 0, 1, 1, 0, 0,1, 1 };
            int k = 3;
            int ans = minimumNet(8, 3, arr);
            Console.ReadLine();
        }

        public static int minimumNet(int n, int k, int[] fish)
        {
            int ans = Int32.MaxValue;
            for (int i = 0; i < n; i++)
            {
                int count = 0;
                int size = 0;
                if (fish[i] == 1)
                {
                    for (int j = i; j < n; j++)
                    {
                        size++;
                        if (fish[j] == 1) count++;
                        if (count == k)
                        {
                            break;
                        }
                    }
                }
                if (count == k)
                {
                    ans = Math.Min(ans, size);
                }
            }
            if (ans == Int32.MaxValue) return -1;
            else return ans;
        }
    }
}
