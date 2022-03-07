using System;
using System.Collections.Generic;
using System.Linq;

namespace Partition_Labels_763
{
    public class Pair
    {
        public int startIndex;
        public int endIndex;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Partition_Labels_763");
            IList<int> result = PartitionLabels("caedbdedda");
            IList<int> result2 = PartitionLabels("ababcbacadefegdehijhklij");
            IList<int> result3 = PartitionLabels("eccbbbbdec");
        }






        public static IList<int> PartitionLabels(string s)
        {
            IList<int> list = new List<int>();
            Dictionary<char, Pair> map = new Dictionary<char, Pair>();
            for (int i = 0; i < s.Length; i++)
            {
                if (map.ContainsKey(s[i]))
                {
                    map[s[i]].endIndex = i;
                }
                else
                {
                    Pair pair = new Pair();
                    pair.startIndex = i;
                    pair.endIndex = i;
                    map.Add(s[i], pair);
                }
            }

            int start = map[s[0]].startIndex;
            int maxEnd = map[s[0]].endIndex;
            for (int i = 1; i < map.Count; i++)
            {
                var item = map.ElementAt(i);
                if (item.Value.startIndex < maxEnd)
                {
                    maxEnd = Math.Max(maxEnd, item.Value.endIndex);
                }
                else
                {
                    list.Add(maxEnd - start + 1);
                    start = item.Value.startIndex;
                    maxEnd = item.Value.endIndex;
                }
            }

            list.Add(maxEnd - start + 1);

            return list;
        }
    }
}
