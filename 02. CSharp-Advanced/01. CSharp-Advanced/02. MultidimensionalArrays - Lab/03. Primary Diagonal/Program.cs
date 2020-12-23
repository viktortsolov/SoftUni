using System;
using System.Linq;

namespace _03._Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            int sumOfPrimaryDiagonal = 0;

            for (int row = 0; row < n; row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (row == col)
                    {
                        sumOfPrimaryDiagonal += matrix[row, col];
                    }
                }
            }

            Console.WriteLine(sumOfPrimaryDiagonal);
        }
    }
}
