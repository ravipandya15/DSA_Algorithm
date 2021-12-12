using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _51._N_Queens
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("51. N-Queens");
            int n = 4;
            //var result = SolveNQueens1(n);
            var result = SolveNQueens(n);
            Console.ReadLine();
        }

        public static IList<IList<string>> SolveNQueens(int n)
        {
            IList<IList<string>> ans = new List<IList<string>>();
            char[,] boards = new char[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    boards[i, j] = '.';
                }
            }
            int[] leftRow = new int[n];
            int[] lowerDiagonal = new int[2 * n - 1];
            int[] upperDiagonal = new int[2 * n - 1];
            Solve(0, boards, ans, leftRow, lowerDiagonal, upperDiagonal);
            return ans;
        }

        public static void Solve(int col, char[,] boards, IList<IList<string>> ans,
                                int[] leftRow, int[] lowerDiagonal, int[] upperDiagonal)
        {
            // base condition
            if (col == boards.GetLength(0))
            {
                ans.Add(Construct(boards));
                return;
            }

            for (int row = 0; row < boards.GetLength(0); row++)
            {
                if (leftRow[row] == 0 && lowerDiagonal[row + col] == 0
                    && upperDiagonal[boards.GetLength(0) - 1 + col - row] == 0)
                {
                    boards[row, col] = 'Q';
                    leftRow[row] = 1;
                    lowerDiagonal[row + col] = 1;
                    upperDiagonal[boards.GetLength(0) - 1 + col - row] = 1;
                    Solve(col + 1, boards, ans, leftRow, lowerDiagonal, upperDiagonal);
                    boards[row, col] = '.';
                    leftRow[row] = 0;
                    lowerDiagonal[row + col] = 0;
                    upperDiagonal[boards.GetLength(0) - 1 + col - row] = 0;
                }
            }
        }

        private static IList<string> Construct(char[,] boards)
        {
            List<string> res = new List<string>();
            for (int i = 0; i < boards.GetLength(0); i++)
            {
                StringBuilder s = new StringBuilder();
                for (int j = 0; j < boards.GetLength(0); j++)
                {
                    s.Append(boards[i, j]);
                }
                res.Add(new string(s.ToString()));
            }
            return res;
        }

        public static IList<IList<string>> SolveNQueens1(int n)
        {
            IList<IList<string>> ans = new List<IList<string>>();
            char[,] boards = new char[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    boards[i, j] = '.';
                }
            }
            Solve1(0, boards, ans, n);
            return ans;
        }

        public static void Solve1(int col, char[,] boards, IList<IList<string>> ans, int n)
        {
            // base condition
            if (col == n)
            {
                ans.Add(Construct(boards));
                return;
            }

            for (int row = 0; row < n; row++)
            {
                if (IsSafe1(row, col, boards))
                {
                    boards[row, col] = 'Q';
                    Solve1(col + 1, boards, ans, n);
                    boards[row, col] = '.';
                }
            }
        }

        private static bool IsSafe1(int row, int col, char[,] boards)
        {
            int tempRow = row;
            int tempCol = col;

            // check left direction
            while (tempCol >= 0)
            {
                if (boards[tempRow, tempCol] == 'Q') return false;
                tempCol--;
            }

            tempRow = row;
            tempCol = col;
            // check uppper diagonal
            while (tempCol >= 0 && tempRow >= 0)
            {
                if (boards[tempRow, tempCol] == 'Q') return false;
                tempCol--;
                tempRow--;
            }

            tempRow = row;
            tempCol = col;

            // check lower diagonal
            while (tempCol >= 0 && tempRow < boards.GetLength(0))
            {
                if (boards[tempRow, tempCol] == 'Q') return false;
                tempCol--;
                tempRow++;
            }

            return true;
        }
    }
}
