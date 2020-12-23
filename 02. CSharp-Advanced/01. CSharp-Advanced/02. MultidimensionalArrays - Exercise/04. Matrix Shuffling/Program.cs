using System;
using System.Linq;

namespace _04._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            var matrix = new string[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currentRow = Console.ReadLine().Split();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                var cmdArg = input.Split();
                
                if (cmdArg.Length != 5 || cmdArg[0] != "swap")
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                string command = cmdArg[0];
                int rowOne = int.Parse(cmdArg[1]);
                int colOne = int.Parse(cmdArg[2]);
                int rowTwo = int.Parse(cmdArg[3]);
                int colTwo = int.Parse(cmdArg[4]);

                bool areIndexesValid = rowOne >= 0 && rowOne < rows &&
                                       colOne >= 0 && colOne < cols &&
                                       rowTwo >= 0 && rowTwo < rows &&
                                       colTwo >= 0 && colTwo < cols;

                if (!areIndexesValid)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                var temp = matrix[rowTwo, colTwo];
                matrix[rowTwo, colTwo] = matrix[rowOne, colOne];
                matrix[rowOne, colOne] = temp;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        Console.Write($"{matrix[row, col]} ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
