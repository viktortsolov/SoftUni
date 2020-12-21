using System;

namespace _07._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int currentLength = 1;
            long[][] pascal = new long[n][];

            for (int row = 0; row < pascal.Length; row++)
            {
                pascal[row] = new long[currentLength];

                pascal[row][0] = 1;
                pascal[row][currentLength - 1] = 1;

                if (currentLength > 2)
                {
                    for (int col = 1; col < currentLength - 1; col++)
                    {
                        pascal[row][col] = pascal[row - 1][col - 1] + pascal[row - 1][col];
                    }
                }

                currentLength++;
            }

            foreach (long[] row in pascal)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
