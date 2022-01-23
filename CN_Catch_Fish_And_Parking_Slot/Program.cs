using System;

namespace CN_Catch_Fish_And_Parking_Slot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Catch_Fish_And_Parking_Slot");
            Console.WriteLine("Cache fish in Love bubber contest 3 Parking_Slot Asked in Swiggy");

            int[] cars = { 2, 10, 8, 17 };
            int k = 3;
            //int[] cars = { 1,2,3,10 };
            //int k = 4;
            //var result = minLengthRoof(cars, k);
        }

        // love bubber contest 3 
        // TC -> O(N) + O(N)
        public static int minimumNet(int n, int k, bool[] fish)
        {
            int r = -1;
            int count = 0;
            int ans = Int32.MaxValue;

            for (int l = 0; l < n; l++)
            {
                while (r < n - 1 && count < k)
                {
                    r++;

                    if (fish[r])
                        count++;
                }

                if (count == k)
                    ans = Math.Min(ans, r - l + 1);

                if (fish[l])
                    count--;
            }

            if (ans == Int32.MaxValue)
                return -1;

            return ans;
        }

        // asked in swiggy
        // TC -> O(N) + O(N)
        public static int minLengthRoof(int[] cars, int k)
        {
            Array.Sort(cars);
            // to reverse
            //Array.Reverse();
            int n = cars.Length;
            int ans = Int32.MaxValue;
            int count = 0;
            int r = -1;

            for (int l = 0; l < n; l++)
            {
                while (r < n-1 && count < k)
                {
                    r++;
                    count++;
                }

                if (count == k)
                    ans = Math.Min(ans, cars[r] - cars[l] + 1);

                count--;
            }
            return ans;
        }

    }
}
