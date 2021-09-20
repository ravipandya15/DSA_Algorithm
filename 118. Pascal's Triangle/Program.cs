using System;
using System.Collections.Generic;

namespace _118._Pascal_s_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("118._Pascal_s_Triangle");
            int numRows = Convert.ToInt32(Console.ReadLine());
            if (numRows > 0)
            {
                Generate(numRows);
            }
            Console.ReadLine();
        }

        public static IList<IList<int>> Generate(int rowNums)
        {
            IList<IList<int>> resultList = new List<IList<int>>();
            for (int i = 0; i < rowNums; i++)
            {
                int[] innerArray = new int[i+1];
                innerArray[0] = 1;
                innerArray[i] = 1;
                for (int j = 1; j < i; j++)
                {
                    innerArray[j] = resultList[i - 1][j - 1] + resultList[i - 1][j];
                }
                resultList.Add(new List<int>(innerArray));
            }
            return resultList;

        }
    }
}
