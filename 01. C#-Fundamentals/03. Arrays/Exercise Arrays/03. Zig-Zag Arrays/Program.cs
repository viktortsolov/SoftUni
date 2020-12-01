using System;
using System.Linq;
namespace _03._Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] firstArr = new int[n];
            int[] secondArr = new int[n];

            for (int i = 0; i < n; i++)
            {
                int[] number = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < 1; j++)
                {
                    if (i % 2 == 1)
                    {
                        secondArr[i] = number[j];
                        firstArr[i] = number[j + 1];
                    }
                    else
                    {
                        firstArr[i] = number[j];
                        secondArr[i] = number[j + 1];
                    }
                }
            }

            Console.WriteLine(string.Join(" ", firstArr));
            Console.WriteLine(string.Join(" ", secondArr));
        }
    }
}
