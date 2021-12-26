using System;
using System.Collections.Generic;

namespace CN__Sum_Of_Two_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sum Of Two Arrays");
            int[] a = { 9, 9, 9 };
            int[] b = { 9, 9, 9 };
            var ans = FindArraySum(a,3,b,3);

            int[] a1 = { 1,2,3,4 };
            int[] b1 = { 6 };
            var ans1 = FindArraySum(a1, 4, b1, 1);
            Console.ReadLine();
        }

        public static List<int> FindArraySum(int[] a, int n, int[] b, int m)
        {
            List<int> ans = new List<int>();
            int i = n - 1, j = m - 1;
            int carry = 0;
            while (i >= 0 && j >= 0)
            {
                int sum = a[i] + b[j] + carry; // carry is privous carry
                carry = sum / 10;
                sum = sum % 10;
                ans.Add(sum);
                i--;
                j--;
            }

            while (i >= 0)
            {
                int sum = a[i] + carry; // carry is privous carry
                carry = sum / 10;
                sum = sum % 10;
                ans.Add(sum);
                i--;
            }

            while (j >= 0)
            {
                int sum = b[j] + carry; // carry is privous carry
                carry = sum / 10;
                sum = sum % 10;
                ans.Add(sum);
                j--;
            }

            if (carry > 0)
            {
                int sum = carry;
                carry = sum / 10;
                sum = sum % 10;

                ans.Add(sum);
            }

            Reverse(ans, 0, ans.Count - 1);
            return ans;
        }

        private static void Reverse(List<int> ans, int start, int end)
        {
            while (start < end)
            {
                int temp = ans[start];
                ans[start] = ans[end];
                ans[end] = temp;
                start++;
                end--;
            }
        }
    }
}
