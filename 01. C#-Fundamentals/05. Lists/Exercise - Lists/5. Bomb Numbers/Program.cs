using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace _5._Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int[] bombAndPower = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int bomb = bombAndPower[0];
            int power = bombAndPower[1];

            while (numbers.Contains(bomb))
            {
                int index = numbers.IndexOf(bomb);

                if (index < power)
                {
                    numbers.RemoveRange(0, index);
                }
                else
                {
                    numbers.RemoveRange(index - power, power);
                }
                index = numbers.IndexOf(bomb);

                if (index + power + 1 < numbers.Count)
                {
                    numbers.RemoveRange(index, power + 1);
                }
                else
                {
                    numbers.RemoveRange(index, numbers.Count - index);
                }

            }

            Console.WriteLine(numbers.Sum());
        }
    }
}
