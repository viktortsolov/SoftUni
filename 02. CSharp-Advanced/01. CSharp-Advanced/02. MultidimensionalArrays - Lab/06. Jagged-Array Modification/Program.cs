using System;
using System.Linq;

namespace _06._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedMatrix = new int[rows][];

            for (int row = 0; row < jaggedMatrix.Length; row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                jaggedMatrix[row] = new int[currentRow.Length];

                for (int col = 0; col < jaggedMatrix[row].Length; col++)
                {
                    jaggedMatrix[row][col] = currentRow[col];
                }
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] cmdArg = input.Split();

                string command = cmdArg[0];
                int row = int.Parse(cmdArg[1]);
                int col = int.Parse(cmdArg[2]);
                int value = int.Parse(cmdArg[3]);

                
                if (row < 0 || row >= jaggedMatrix.Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }
                if (col < 0 || col >= jaggedMatrix[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                if (command == "Add")
                {
                    jaggedMatrix[row][col] += value;
                }
                else
                {
                    jaggedMatrix[row][col] -= value;
                }
            }

            for (int row = 0; row < jaggedMatrix.Length; row++)
            {
                Console.WriteLine(string.Join(" ", jaggedMatrix[row]));
            }
        }
    }
}
