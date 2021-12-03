using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace GFG__N_meetings_in_one_room
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GFG) N meetings in one room");
            int[] start = new int[] { 1, 0, 3, 8, 5, 8 };
            int[] end = new int[] { 2, 6, 4, 9, 7, 9 };
            MaxMeetings(start, end, start.Length);
            Console.ReadLine();
        }

        public class Meeting
        {
            public int start;
            public int end;
            public int pos;

            public Meeting(int start, int end, int pos)
            {
                this.start = start;
                this.end = end;
                this.pos = pos;
            }
        }

        public class MeetingConparator : IComparer<Meeting>
        {
            public int Compare(Meeting m1, Meeting m2)
            {
                if (m1.end < m2.end)
                    return -1; // means no need to swap
                else if (m1.end > m2.end)
                    return 1; // means need to swap
                else if (m1.pos < m2.pos)
                    return -1;
                return 1;
            }
        }

        // TC -> O(NLogN) (O(N) + O(NLogN) + O(N))
        // SC -> O(N)
        public static void MaxMeetings(int[] s, int[] f, int n)
        {
            List<Meeting> meetings = new List<Meeting>();

            for (int i = 0; i < n; i++)
            {
                meetings.Add(new Meeting(s[i], f[i], i + 1));
            }
            MeetingConparator mc = new MeetingConparator();

            meetings.Sort(mc);

            List<int> ans = new List<int>();
            ans.Add(meetings[0].pos);
            int endTime = meetings[0].end;

            for (int i = 1; i < n; i++)
            {
                if (meetings[i].start > endTime)
                {
                    ans.Add(meetings[i].pos);
                    endTime = meetings[i].end;
                }
            }

            foreach (int item in ans)
            {
                Console.WriteLine($"{item} ");
            }
        }
    }
}
