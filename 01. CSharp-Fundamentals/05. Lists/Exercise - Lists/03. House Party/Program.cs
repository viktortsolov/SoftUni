using System;
using System.Collections.Generic;

namespace _03._House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            List<string> people = new List<string>();

            for (int i = 0; i < numberOfCommands; i++)
            {
                string input = Console.ReadLine();
                string[] command = input.Split();

                if (command.Length == 3)
                {
                    if (people.Contains(command[0]))
                    {
                        Console.WriteLine($"{command[0]} is already in the list!");
                    }
                    else
                    {
                        people.Add(command[0]);
                    }
                }
                else
                {
                    if (!people.Contains(command[0]))
                    {
                        Console.WriteLine($"{command[0]} is not in the list!");
                    }
                    else
                    {
                        people.Remove(command[0]);
                    }
                }
            }
            foreach (var name in people)
            {
                Console.WriteLine(name);
            }
        }
    }
}
