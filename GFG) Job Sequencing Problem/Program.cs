using System;

namespace GFG__Job_Sequencing_Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GFG) Job Sequencing Problem");
            Job[] jobs = new Job[] { new Job(1,4,20),
                                     new Job(2,5,60),
                                     new Job(3,6,70),
                                     new Job(4,6,65),
                                     new Job(5,4,25),
                                     new Job(6,2,80),
                                     new Job(7,2,10),
                                     new Job(8,2,22)};
            int[] ans = JobScheduling(jobs, 8);
            Console.WriteLine($"Job count is {ans[0]} with maxProfit of {ans[1]}");
            Console.ReadLine();
        }

        public class Job
        {
            public int jobId;
            public int deadline;
            public int profit;

            public Job(int jobId, int deadline, int profit)
            {
                this.jobId = jobId;
                this.deadline = deadline;
                this.profit = profit;
            }
        }

        // TC -> O(nlogn) + O(N * M) -> M is deadline of perticular job
        // SC -> O(M) -> M is max Deadline of job
        // incase if interviewer ask to print sequence of job Id then print result array for which value is not -1. from index 1 as it is 1 based indexing array.
        public static int[] JobScheduling(Job[] arr, int n)
        {
            Array.Sort(arr, (a, b) => (b.profit - a.profit)); // 2nd argument is comparator.
                                                              // if its value is > 1 then it will swap otherwise not.
            int maxDeadline = 0;
            for (int i = 0; i < n; i++)
            {
                if (arr[i].deadline > maxDeadline)
                    maxDeadline = arr[i].deadline;
            }

            int[] result = new int[maxDeadline + 1]; // for 1 based indexing
            for (int i = 1; i <= maxDeadline; i++)
            {
                result[i] = -1;
            }

            int jobCount = 0;
            int maxProfit = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = arr[i].deadline; j > 0; j--)
                {
                    if (result[j] == -1)
                    {
                        result[j] = arr[i].jobId;
                        maxProfit += arr[i].profit;
                        jobCount++;
                        break;
                    }
                }
            }

            int[] ans = new int[2];
            ans[0] = jobCount;
            ans[1] = maxProfit;
            return ans;
        }
    }
}
