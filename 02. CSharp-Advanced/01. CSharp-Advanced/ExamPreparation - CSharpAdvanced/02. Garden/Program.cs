using System;
using System.Linq;
using System.Text;

namespace _02._Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                                    .Split()
                                    .Select(int.Parse)
                                    .ToArray();

            int[,] matrix = new int[dimensions[0], dimensions[1]];

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                var rowAndCol = input.Split()
                                      .Select(int.Parse)
                                      .ToArray();

                int plantRow = rowAndCol[0];
                int plantCol = rowAndCol[1];

                if (plantRow < 0 && plantRow >= dimensions[0] ||
                    plantCol < 0 && plantCol >= dimensions[1])
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }

                //row
                for (int row = 0; row < dimensions[1]; row++)
                {
                    matrix[row, plantCol] += 1;
                }

                //col
                for (int col = 0; col < dimensions[1]; col++)
                {
                    if (col == plantCol)
                    {
                        continue;
                    }
                    matrix[plantRow, col] += 1;
                }
            }

            StringBuilder sb = new StringBuilder();
            for (int row = 0; row < dimensions[0]; row++)
            {
                for (int col = 0; col < dimensions[1]; col++)
                {
                    sb.Append($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
