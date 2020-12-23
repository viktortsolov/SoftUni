using System;
using System.Linq;

namespace _06._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double[][] matrix = new double[n][];

            for (int row = 0; row < matrix.Length; row++)
            {
                double[] currentRow = Console.ReadLine()
                    .Split()
                    .Select(double.Parse)
                    .ToArray();

                matrix[row] = new double[currentRow.Length];

                matrix[row] = currentRow;
            }

            for (int row = 0; row < matrix.Length - 1; row++)
            {
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    matrix[row] = matrix[row].Select(x => x * 2).ToArray();
                    matrix[row + 1] = matrix[row + 1].Select(x => x * 2).ToArray();
                }
                else
                {
                    matrix[row] = matrix[row].Select(x => x / 2).ToArray();
                    matrix[row + 1] = matrix[row + 1].Select(x => x / 2).ToArray();
                }
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                var cmdArg = input.Split();

                string command = cmdArg[0];
                int row = int.Parse(cmdArg[1]);
                int col = int.Parse(cmdArg[2]);
                double value = int.Parse(cmdArg[3]);

                bool areIndexesValid = row >= 0 && row < n &&
                                       col >= 0 && col < matrix[row].Length;

                if (!areIndexesValid)
                {
                    continue;
                }

                switch (command)
                {
                    case "Add":
                        matrix[row][col] += value;
                        break;

                    case "Subtract":
                        matrix[row][col] -= value;
                        break;

                    default:
                        throw new ArgumentException("error");
                }
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine(string.Join(" ", matrix[row]));
            }
        }
    }
}
