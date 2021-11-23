using System;
using System.Collections.Generic;

namespace _18._4Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("18. 4Sum");
            int[] nums = new int[] { 4, 3, 3, 4, 4, 2, 1, 2, 1, 1 };
            int target = 9;
            var resultList = FourSum(nums, target);
            foreach (var innerlist in resultList)
            {
                foreach (int num in innerlist)
                {
                    Console.Write($"{num} ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        // time complexity -> O(N^3)
        // space complexity -> O(1)
        public static IList<IList<int>> FourSum(int[] nums, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();
            //IList<int> temp = new List<int>(); // just for referance for above line
            Array.Sort(nums);

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    int remainingSum = target - nums[i] - nums[j];
                    int start = j + 1;
                    int end = nums.Length - 1;
                    while(start < end)
                    {
                        int tempSum = nums[start] + nums[end];
                        if (tempSum < remainingSum)
                        {
                            start++;
                        }
                        else if (tempSum > remainingSum)
                        {
                            end--;
                        }
                        else
                        {
                            IList<int> quad = new List<int>();
                            quad.Add(nums[i]);
                            quad.Add(nums[j]);
                            quad.Add(nums[start]);
                            quad.Add(nums[end]);
                            result.Add(quad);

                            while(start < end && nums[start] == quad[2])
                            {
                                start++;
                            }
                            while(start < end && nums[end] == quad[3])
                            {
                                end--;
                            }
                        }
                    }

                    // increse j to avoid duplicate
                    //2 2 2 3 -> make sure j will point to last 2 because it will be incremented by 1 due to for loop increment step.
                    while( j + 1 < nums.Length && nums[j+1] == nums[j])
                    {
                        j++;
                    }
                } 

                while(i + 1 < nums.Length && nums[i+1] == nums[i])
                {
                    i++;
                }
            }
            return result;
        }
    }
}
