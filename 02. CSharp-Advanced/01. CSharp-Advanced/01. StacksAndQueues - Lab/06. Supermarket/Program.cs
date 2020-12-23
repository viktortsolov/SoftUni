using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            Queue<string> people = new Queue<string>();

            while ((input = Console.ReadLine()) != "End") 
            {
                if (input == "Paid")
                {
                    while (people.Count > 0)
                    {
                        Console.WriteLine(people.Dequeue());
                        continue;
                    }
                }

                people.Enqueue(input);
            }
            Console.WriteLine($"{people.Count()} people remaining.");
        }
    }
}
