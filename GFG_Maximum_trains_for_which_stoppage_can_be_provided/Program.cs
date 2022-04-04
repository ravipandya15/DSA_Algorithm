using System;
using System.Collections.Generic;

namespace GFG_Maximum_trains_for_which_stoppage_can_be_provided
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GFG_Maximum_trains_for_which_stoppage_can_be_provided");
            int[][] trains = new int[][]
            {
                new int[] {1000, 1030, 1},
                new int[] {1010, 1030, 1},
                new int[] {1000, 1020, 2},
                new int[] {1030, 1230, 2},
                new int[] {1200, 1230, 3},
                new int[] {9000, 1005, 1},
            };

            int maxTrainsCanStop = maxStop(trains, 3, 6);
            Console.WriteLine($"answer is {maxTrainsCanStop}");
        }

        public class Item
        {
            public int arrivalTime;
            public int departureTime;
            public int plateformNumber;

            public Item(int aTime, int dTime, int pNum)
            {
                this.arrivalTime = aTime;
                this.departureTime = dTime;
                this.plateformNumber = pNum;
            }
        };

        public class ItemCompare : IComparer<Item>
        {
            public int Compare(Item x, Item y)
            {
                if (y.departureTime == x.departureTime)
                {
                    if (y.arrivalTime < x.arrivalTime) return 1;
                }
                else if (y.departureTime < x.departureTime) return 1;
                return -1;
            }
        }

        public static int maxStop(int[][] trains, int n, int m)
        {
            List<int> v = new List<int>(n + 1);
            for (int i = 0; i < n + 1; i++)
            {
                v.Add(-1);
            }
            List<Item> items = new List<Item>();

            for (int i = 0; i < trains.Length; i++)
            {
                Item item = new Item(trains[i][0], trains[i][1], trains[i][2]);
                items.Add(item);
            }

            items.Sort(new ItemCompare());

            int count = 0;

            for (int i = 0; i < m; i++)
            {
                if (v[items[i].plateformNumber] == -1)
                {
                    count++;
                    v[items[i].plateformNumber] = i;
                }
                else
                {
                    if (items[v[items[i].plateformNumber]].departureTime <= items[i].arrivalTime)
                    {
                        count++;
                        v[items[i].plateformNumber] = i;
                    }
                }
            }

            return count;
        }
    }
}
