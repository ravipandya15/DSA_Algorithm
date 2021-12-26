using System;
using System.Collections.Generic;

namespace Median_of_Row_wise_Sorted_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("From Interview Bit");
            Console.WriteLine("Median_of_Row_wise_Sorted_Matrix");
            Console.WriteLine("Check java code");
			//java code link
			//https://github.com/striver79/SDESheet/blob/main/matrixMedianJava

			List<List<int>> arr = new List<List<int>>();
			List<int> temp = new List<int>();
			temp.Add(1);
			temp.Add(3);
			temp.Add(6);

			List<int> temp2 = new List<int>();
			temp.Add(2);
			temp.Add(6);
			temp.Add(9);

			List<int> temp3 = new List<int>();
			temp.Add(3);
			temp.Add(6);
			temp.Add(9);

			arr.Add(temp);
			arr.Add(temp2);
			arr.Add(temp3);
            Console.WriteLine("find median Note : every row is sorted");
			int ans = findMedian(arr);
            Console.WriteLine("Median is " + ans);
		}

		public static int findMedian(List<List<int>> arr)
		{
			int low = Int32.MinValue;
			int high = Int32.MaxValue;
			int n = arr.Count;
			int m = arr[0].Count;
			while (low <= high)
			{
				int mid = (low + high) >> 1;
				// or mid = (low + high)/2;
				// or mid = (low + high) >> 1;
				int count = 0;
				for (int i = 0; i < n; i++)
				{
					count += countSmallerThanMid(arr[i], mid);
				}
				if (count <= (n * m) / 2)
					low = mid + 1;
				else
					high = mid - 1;
			}
			return low;
		}

		private static int countSmallerThanMid(List<int> arr, int val)
		{
			int low = 0;
			int high = arr.Count - 1;
			while (low <= high)
			{
				int mid = (low + high) >> 1;
				if (arr[mid] <= val)
					low = mid + 1;
				else
					high = mid - 1;
			}

			return low;
		}
	}
}
