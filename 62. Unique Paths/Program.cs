using System;

namespace _62._Unique_Paths
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("62. Unique Paths");
            //Console.WriteLine($"answer is {UniquePaths1(3, 7)}");
            //Console.WriteLine($"answer is {UniquePaths(3, 7)}");
            int[][] nums = new int[3][]
            {
                new int[] {0,0,0},
                new int[] {0,0,0},
                new int[] {0,0,1},
            };
            //int[][] nums = new int[2][]
            //{
            //    new int[] {0,0},
            //    new int[] {0,1}
            //};
            Console.WriteLine($"answer is {UniquePathsII(nums)}");
            Console.ReadLine();
        }

        // where 1 is present 
        public static int UniquePathsII(int[][] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums[0].Length; j++)
                {
                    if (nums[i][j] == 1)
                    {
                        nums[i][j] = -1;
                    }
                }
            }

            return UniquePathsIISolution(0, 0, nums.Length, nums[0].Length, nums);
        }

        public static int UniquePathsIISolution(int i, int j, int n, int m, int[][] dp)
        {
            if (i == n - 1 && j == m - 1)
            {
                if (dp[i][j] == -1)
                    return 0;
                else
                    return 1;
            }
            if (i >= n || j >= m || dp[i][j] == -1)
            {
                return 0;
            }
            if (dp[i][j] != 0)
            {
                return dp[i][j];
            }
            else
            {
                dp[i][j] = UniquePathsIISolution(i + 1, j, n, m, dp) + UniquePathsIISolution(i, j + 1, n, m, dp);
                return dp[i][j];
            }
        }

        public static int RecursionSolution(int i, int j, int n, int m)
        {
            if (i == n - 1 && j == m - 1)
            {
                return 1;
            }
            if (i >= n || j >= m)
            {
                return 0;
            }
            else
            {
                return RecursionSolution(i + 1, j, n, m) + RecursionSolution(i, j + 1, n, m);
            }
        }

        public static int DynamicProgrammingSolution(int i, int j, int n, int m, int[,] dp)
        {
            if (i == n - 1 && j == m - 1)
            {
                return 1;
            }
            if (i >= n || j >= m)
            {
                return 0;
            }
            if (dp[i, j] != -1)
            {
                return dp[i, j];
            }
            else
            {
                dp[i, j] = DynamicProgrammingSolution(i + 1, j, n, m, dp) + DynamicProgrammingSolution(i, j + 1, n, m, dp);
                return dp[i, j];
            }
        }

        public static int UniquePaths1(int n, int m)
        {
            return RecursionSolution(0, 0, n, m);
            int[,] dp = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    dp[i, j] = -1;
                }
            }
            return DynamicProgrammingSolution(0, 0, n, m, dp);
        }

        public static int UniquePaths(int m, int n)
        {
            double ans = 1;
            int N = m + n - 2;
            int r = m - 1; // or r = n - 1; -> use which ever is less so for loop run for lesser time.

            for (int i = 1; i <= r; i++)
            {
                ans = ans * (N - r + i) / i;
            }
            return (int)ans;
        }
    }
}
