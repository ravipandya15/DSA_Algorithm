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

            int[] arr = { 1, 0, 1, 1, 0, 0, 1, 1 };
            int kk = 3;
            int result = minimumNet_1(arr, kk);
        }

        public static int minimumNet_1(int[] fish, int k)
        {
            int n = fish.Length;
            int i = 0, j = 0;
            int mini = Int32.MaxValue;

            while (j < n)
            {
                k -= fish[j];

                if (k > 0)
                {
                    j++;
                }
                else if (k == 0)
                {
                    mini = Math.Min(mini, j - i + 1);
                    j++;
                }
                else if (k < 0)
                {
                    while (k < 0)
                    {
                        k += fish[i];
                        i++;
                    }
                    j++;
                }
            }

            if (mini == Int32.MaxValue) return -1;
            return mini;
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
                while (r < n - 1 && count < k)
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

        public static int minLengthRoof_1(int[] cars, int k)
        {
            int n = cars.Length;
            Array.Sort(cars);
            int i = 1, j = 1;
            int mini = Int32.MaxValue;
            int temp = 0;
            while (j < n)
            {
                temp = temp + cars[j] - cars[j - 1];
                if (j - i + 1 < k)
                {
                    j++;
                }
                else if (j - i + 1 == k)
                {
                    mini = Math.Min(mini, temp);
                    temp = temp - (cars[i] - cars[i - 1]);
                    i++;
                    j++;
                }
            }
            return mini;
        }

    }
}
