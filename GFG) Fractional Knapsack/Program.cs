using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace GFG__Fractional_Knapsack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GFG) Fractional Knapsack");
            int[] W = new int[] { 10, 20, 30 };
            int[] val = new int[] { 60, 100, 120 };
            Item[] items = new Item[] { new Item(10, 60),
                                        new Item(20, 100),
                                        new Item(30, 120)};
            Console.WriteLine($"maximun knapsack value is {FractionalKnapsack(50, items, 3)}");
            Console.ReadLine();
        }

        public class Item
        {
            public int weight;
            public int value;
            public Item(int weight, int value)
            {
                this.weight = weight;
                this.value = value;
            }
        }

        public class ItemComparer : IComparer<Item>
        {
            public int Compare(Item x, Item y)
            {
                double r1 = (double)x.value / (double)x.weight;
                double r2 = (double)y.value / (double)y.value;

                if (r1 > r2) return -1; // don't swap
                else if (r1 < r2) return 1; // swap
                else return 0;
            }
        }

        public static double FractionalKnapsack(int W, Item[] arr, int n)
        {
            Array.Sort(arr, new ItemComparer());
            int currentWeight = 0;
            double finalValue = 0;

            for (int i = 0; i < n; i++)
            {
                if (currentWeight + arr[i].weight <= W)
                {
                    currentWeight += arr[i].weight;
                    finalValue += arr[i].value;
                }
                else
                {
                    int remainingWeight = W - currentWeight;
                    finalValue += ((double)arr[i].value / (double)arr[i].weight) * (double)remainingWeight;
                    break; // as now knapsack is full so no need to iterate.
                }
            }
            return finalValue;
        }
    }
}
