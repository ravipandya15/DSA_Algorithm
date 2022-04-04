using System;

namespace GFG_Find_Missing_And_Repeating
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GFG_Find_Missing_And_Repeating ");
            int[] arr = { 1, 3, 3 };
            int[] ans = findTwoElement(arr, 3);
            Console.WriteLine($"repeating number is {ans[0]}");
            Console.WriteLine($"missing number is {ans[1]}");
        }



        // Also in CN

        public static int[] findTwoElement(int[] arr, int n)
        {
            int num = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                num = num ^ arr[i];
            }

            for (int i = 1; i <= n; i++)
            {
                num = num ^ i;
            }

            // find right most set bit
            int temp = num;
            int bit = 0; // right most bit
            int k = 0;
            while (temp > 0)
            {
                if ((temp & 1) == 1)
                {
                    bit = k;
                    break;
                }
                temp = temp >> 1;
                k++;
            }

            int setBitsNumber = 0, unSetBitsNumber = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (((arr[i] >> bit) & 1) == 1)
                {
                    setBitsNumber = setBitsNumber ^ arr[i];
                }
                else
                {
                    unSetBitsNumber = unSetBitsNumber ^ arr[i];
                }
            }

            for (int i = 1; i <= n; i++)
            {
                if (((i >> bit) & 1) == 1)
                {
                    setBitsNumber = setBitsNumber ^ i;
                }
                else
                {
                    unSetBitsNumber = unSetBitsNumber ^ i;
                }
            }

            // now either of setBitsNumber is missing or repeating
            // or unSetBitsNumber is missing or repeating
            int repeating = 0, missing = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (setBitsNumber == arr[i])
                {
                    repeating = setBitsNumber;
                    missing = unSetBitsNumber;
                    break;
                }
                else if (unSetBitsNumber == arr[i])
                {
                    repeating = unSetBitsNumber;
                    missing = setBitsNumber;
                    break;
                }
            }

            int[] ans = { repeating, missing };
            return ans;
        }
    }
}
