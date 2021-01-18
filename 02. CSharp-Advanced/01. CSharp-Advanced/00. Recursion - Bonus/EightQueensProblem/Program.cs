using System;

namespace EightQueensProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            int queens = int.Parse(Console.ReadLine());

            int[,] matrix = new int[queens, queens];

            GetQueens(matrix, 0);
        }

        private static void GetQueens(int[,] queens, int row)
        {
            if (row == queens.GetLength(0))
            {
                Console.WriteLine("Queens found!");
                return;
            }

            for (int col = 0; col < queens.GetLength(1); col++)
            {
                if (IsSafe(queens, row, col))
                {
                    queens[row, col] = 1;
                    GetQueens(queens, row + 1);
                    queens[row, col] = 0;
                }
            }
        }

        private static bool IsSafe(int[,] queens, int row, int col)
        {
            for (int i = 1; i < queens.GetLength(0); i++)
            {
                if (row - i >= 0 && queens[row - i, col] == 1)
                {
                    return false;
                }
                if (col - i >= 0 && queens[row, col - i] == 1)
                {
                    return false;
                }
                if (row + i >= 0 && queens[row + i, col] == 1)
                {
                    return false;
                }
                if (col + 1 >= 0 && queens[row, col + 1] == 1)
                {
                    return false;
                }
            }
        }
    }
}