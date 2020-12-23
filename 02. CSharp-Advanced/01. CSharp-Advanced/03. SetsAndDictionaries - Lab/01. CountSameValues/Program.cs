using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._CountSameValues
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                                 .Split()
                                 .Select(double.Parse)
                                 .ToArray();

            Dictionary<double, int> numbers = new Dictionary<double, int>();

            foreach (var item in input)
            {
                numbers.TryAdd(item, 0);
                numbers[item]++;
            }

            foreach (var item in numbers)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        } 
    }
}
