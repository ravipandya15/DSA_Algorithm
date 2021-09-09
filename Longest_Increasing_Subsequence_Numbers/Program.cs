using System;
using System.Collections.Generic;
using System.Linq;

namespace Longest_Increasing_Subsequence_Numbers
{
    class Program
    {
        //time complexity - O(n^2)
        // space complexity - O(n)
        //public static int LengthOfLIS(int[] nums)
        //{
        //    int[] dp = new int[nums.Length];
        //    Array.Fill(dp, 1);
        //    for (int i = 1; i < nums.Length; i++)
        //    {
        //        for (int j = 0; j < i; j++)
        //        {
        //            if (nums[j] < nums[i])
        //            {
        //                dp[i] = Math.Max(dp[i], dp[j] + 1);
        //            }
        //        }
        //    }
        //    return dp.Max();
        //}

        //time complexity - O(n^2)
        // space complexity - O(n)
        //public static int LengthOfLIS(int[] nums)
        //{
        //    if (nums.Length == 0)
        //        return 0;
        //    //ArrayList sub = new ArrayList();
        //    List<int> sub = new List<int>();
        //    sub.Add(nums[0]);

        //    for (int i = 1; i < nums.Length; i++)
        //    {
        //        int num = nums[i];
        //        if (num > sub[sub.Count - 1])
        //        {
        //            sub.Add(num);
        //        }
        //        else
        //        {
        //            int j = 0;
        //            while(num > sub[j])
        //            {
        //                j = j + 1;
        //            }
        //            sub[j] = num;
        //        }
        //    }

        //    return sub.Count;
        //}

        //time complexity - O(n * Log(n)) - Binary search takes O(Log(n))
        // space complexity - O(n)
        public static int LengthOfLIS(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            List<int> sub = new List<int>();
            sub.Add(nums[0]);

            for (int i = 1; i < nums.Length; i++)
            {
                int num = nums[i];
                if (num > sub[sub.Count - 1])
                {
                    sub.Add(num);
                }
                else
                {
                    int j = BinarySearch(num, sub);
                    sub[j] = num;
                }
            }

            return sub.Count;
        }
        public static int BinarySearch(int num, List<int> sub)
        {
            int left = 0, right = sub.Count - 1;
            while(left < right)
            {
                int mid = (left + right) / 2;
                if (num == sub[mid])
                {
                    return mid;
                }
                else if (num > sub[mid])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return left;
        }

        //public static int TestMethod(int a)
        //{
        //    int ans = 1;
        //    try
        //    {
        //        int b = 100, c = 0;
        //        //throws error at run time
        //        float d = b / c;
        //    }
        //    catch (DivideByZeroException ex)
        //    {
        //        Console.WriteLine($"Exception is {ex.Message.ToString()}");
        //    }
        //    finally
        //    {
        //        Console.WriteLine("Inside finally block");
        //        try
        //        {
        //            int b = 100, c = 0;
        //            //throws error at run time
        //            float d = b / c;
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine($"exception is {ex.Message.ToString()}");
        //        }
        //        finally
        //        {
        //            Console.WriteLine("Inside sub finally block");
        //        }
        //    }
        //    return ans;
        //}

        // destruction in C#
        public static (string name, int id) GetEmployee(int id)
        {
            string employeeName = "Ravi Pandya";
            int employeeId = 33;

            return (employeeName, employeeId);
        }

        static void Main(string[] args)
        {
            //TestMethod(100);
            (string employeeName, int employeeId) = GetEmployee(11);
            //string employeeName = GetEmployee(11);
            Console.WriteLine($"employeee details is {employeeName} {employeeId}");
            Console.WriteLine("Longest Increasing Subsequence");
            //int[] nums = new int[8] { 10, 9, 2, 5, 3, 7, 101, 18 };
            //int[] nums = new int[6] { 0, 1, 0, 3, 2, 3 };
            int[] nums = new int[7] { 7, 7, 7, 7, 7, 7, 7 };
            Console.WriteLine($"Longest Increasing Subsequence is {LengthOfLIS(nums)}");
        }
    }
}
