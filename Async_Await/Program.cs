using System;
using System.Threading;
using System.Threading.Tasks;

namespace Async_Await
{
    class Program
    {
        public static string result;
        static void Main(string[] args)
        {
            if (null > 0)
            {
                Console.WriteLine("this will not be executed");
            }
            SaySomething();
            //printSeries(2, 1, 3);
            Console.WriteLine($"Result is {result}");
        }

        public static async Task<string> SaySomething()
        {
            //await Task.Delay(5000);
            //Task.Delay(5000);
            //Thread.Sleep(5000);
            result = "Hello";
            return "World";
        }

        public static void printSeries(int start, int stepSize, int stepCount)
        {
            Console.Write($"{ Math.Pow(start, 3)}");
            stepCount--;
            if (stepCount == 0)
            {
                return;
            }
            Console.Write(",");
            start = start + stepSize;
            printSeries(start, stepSize, stepCount);
        }
    }
}
