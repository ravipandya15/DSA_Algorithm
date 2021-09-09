using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq1
{
    class Program
    {
        // program to move all zeros to end of list.
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] myarr = new int[10] { 0, 5, 0, 1, 9 ,0 , 5, 0, 3, 4};
            List<int> list1 = myarr.ToList();
            List<int> list2 = list1.Where(x => x == 0).ToList();
            //list1.RemoveAll(x => x == 0);
            List<int> result = list1.Except(list2).ToList();
            list1.AddRange(list2);

            Console.ReadLine();
        }
    }
}
