using System;

namespace Arithmetic_Progression_From_Sequence
{
    class Program
    {
        public static bool CanMakeArithmeticProgression(int[] arr)
        {
            bool result = true;
            if (arr.Length == 0)
                return false;
            if (arr.Length == 1)
                return true;
            Array.Sort(arr);
            int j = 0;
            for (j = 0; j < arr.Length; j++)
            {
                if (arr[j] != 0)
                {
                    break;
                }
            }
            if (j == arr.Length)
            {
                return true;
            }
            int diffrence = arr[0] - arr[1];
            if (diffrence == 0)
                return false;
            for (int i = 1; i < arr.Length -1 ; i++)
            {
                int tempDiff = arr[i] - arr[i + 1];
                if (tempDiff != diffrence)
                    return false;
            }
            return result;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Arithmetic Progression from sequence");
            int[] arr = new int[2] { 3, 6 };
            Console.WriteLine($"result is {CanMakeArithmeticProgression(arr)}");
        }
    }
}