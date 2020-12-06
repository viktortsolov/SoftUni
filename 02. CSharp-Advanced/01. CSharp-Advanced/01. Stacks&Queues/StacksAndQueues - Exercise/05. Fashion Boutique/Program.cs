using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> numbers = new Stack<int>(array);

            int rackCapacity = int.Parse(Console.ReadLine());

            int racks = 1;
            int sum = 0;

            while (numbers.Count > 0)
            {
                if (sum + numbers.Peek() > rackCapacity)
                {
                    racks++;
                    sum = 0;
                }
                else if (sum + numbers.Peek() == rackCapacity)
                {
                    racks++;
                    sum = 0;
                    numbers.Pop();
                }
                else
                {
                    sum += numbers.Pop();
                }
            }
            Console.WriteLine(racks);
        }
    }
}
