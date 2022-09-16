using System;
using System.Collections.Generic;

namespace _842._Split_Array_into_Fibonacci_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("842. Split Array into Fibonacci Sequence");
            String num = "1101111";
            var ans = splitIntoFibonacci(num);
            Console.WriteLine("ans");
        }

        public static bool solve(int index, int[] count, String num, IList<int> ans, int n)
        {
            if (index == n)
            {
                if (count[0] == n-1 && ans.Count >= 3) return true;
                return false;
            }

            int data = 0;
            for (int i = index; i < n; i++)
            {
                //count[0]++;
                data = data * 10 + (num[i] - '0');
                // if (ans.size() < 2)
                // {
                //     ans.add(data);
                //     if (solve(i + 1, count, num, ans, n)) return true;
                //     ans.remove(ans.size() - 1);
                //     if (data == 0) return false;
                // }
                //else
                //{
                if (ans.Count < 2 || data == ans[ans.Count - 1] + ans[ans.Count - 2])
                {
                    ans.Add(data);
                    count[0] = i;
                    if (solve(i + 1, count, num, ans, n)) return true;
                    ans.RemoveAt(ans.Count - 1);
                    if (data == 0) return false;
                }
                else if (data > ans[ans.Count - 1] + ans[ans.Count - 2])
                {
                    return false;
                }
                else if (data == 0)
                {
                    return false;
                }
                //}
            }

            return false;
        }

        public static IList<int> splitIntoFibonacci(String num)
        {
            int n = num.Length;
            int[] count = { 0 };
            IList<int> ans = new List<int>();
            if (solve(0, count, num, ans, n))
            {
                if (count[0] == n-1 && ans.Count >= 3) return ans;
            }
            return new List<int>();
        }
    }
}
