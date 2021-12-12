using System;

namespace _37._Sudoku_Solver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("37. Sudoku Solver");
            Console.ReadLine();
        }

        public static void SolveSudoku(char[][] board)
        {
            Solve(board);
        }

        public static bool Solve(char[][] board)
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    if (board[i][j] == '.')
                    {
                        for (char c = '1'; c <= '9'; c++)
                        {
                            if (IsValid(board, i, j, c))
                            {
                                board[i][j] = c;

                                if (Solve(board))
                                    return true;
                                else
                                    board[i][j] = '.';
                            }
                        }

                        return false;
                    }
                }
            }
            return true;
        }

        private static bool IsValid(char[][] board, int row, int col, char c)
        {
            for (int i = 0; i < 9; i++)
            {
                if (board[row][i] != '.' && board[row][i] == c) return false;
                if (board[i][col] != '.' && board[i][col] == c) return false;
                if (board[3 * (row / 3) + i / 3][3 * (col / 3) + i % 3] != '.' 
                    && board[3 * (row / 3) + i / 3][3 * (col / 3) + i % 3] == c) return false;
            }
            return true;
        }
    }
}
