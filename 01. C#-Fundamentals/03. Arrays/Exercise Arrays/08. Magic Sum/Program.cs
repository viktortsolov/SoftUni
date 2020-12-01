using System;
using System.Linq;
using System.Security.Cryptography;

namespace _08._Magic_Sum
{
    class Program
    {
        static void Main(string[] args)

        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < arr.Length; i++)
            {
                int currentNumber = arr[i];

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (currentNumber + arr[j] == n)
                    {
                        Console.Write($"{currentNumber} {arr[j]}");
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
