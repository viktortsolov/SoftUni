using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace _05._Top_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            bool isBigger = true;

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentInt = numbers[i];

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    int element = numbers[j];
                    if (element >= currentInt)
                    {
                        isBigger = false;
                        break;
                    }
                }
                if (isBigger)
                    Console.Write(currentInt + " ");

                isBigger = true;
            }
        }
    }
}
