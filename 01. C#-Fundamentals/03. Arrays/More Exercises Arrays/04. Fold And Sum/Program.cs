using System;
using System.Linq;

namespace _04._Fold_And_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] firstRow = new int[numbers.Length / 2];
            int[] secondRow = new int[numbers.Length / 2];
            int[] finalRow = new int[numbers.Length / 2];

            int leftFoldIndex = numbers.Length / 4 - 1;
            int rightFoldIndex = 3 * numbers.Length / 4;

            int[] reversedNumbers = new int[numbers.Length / 4];

            int numbersSoFar = 0;

            for (int i = leftFoldIndex; i >= 0; i--)
            {
                numbersSoFar++;
                firstRow[leftFoldIndex - i] = numbers[i];
            }

            for (int i = numbers.Length - 1; i >= rightFoldIndex; i--)
            {
                firstRow[numbers.Length - 1 - i + numbersSoFar] = numbers[i];
            }

            for (int i = leftFoldIndex + 1; i < rightFoldIndex; i++)
                secondRow[i - numbersSoFar] = numbers[i];

            for (int i = 0; i < firstRow.Length; i++)
                Console.Write(firstRow[i] + secondRow[i] + " ");
        }
    }
}
