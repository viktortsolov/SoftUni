using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> waggons = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int maxCapacity = int.Parse(Console.ReadLine());

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] command = input.Split();

                if (command[0] == "Add")
                {
                    waggons.Add(int.Parse(command[1]));
                }
                else
                {
                    for (int i = 0; i < waggons.Count; i++)
                    {
                        int number = int.Parse(command[0]);

                        if (waggons[i] + number > maxCapacity)
                            continue;
                        else
                        {
                            waggons[i] += number;
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ", waggons));
        }
    }
}
