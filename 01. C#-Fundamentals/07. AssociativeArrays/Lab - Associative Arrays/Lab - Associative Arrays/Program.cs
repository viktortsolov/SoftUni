using System;
using System.Collections.Generic;

namespace Lab___Associative_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new SortedDictionary<string, int>();

            for (int i = 0; i < 3; i++)
            {
                string name = Console.ReadLine();
                int age = int.Parse(Console.ReadLine());

                dictionary.Add(name, age);
            }

            foreach (var pair in dictionary)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }
    }
}
