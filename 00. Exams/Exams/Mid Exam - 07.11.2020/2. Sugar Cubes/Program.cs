using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _2._Sugar_Cubes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sugarCubes = Console.ReadLine()
                                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                            .Select(int.Parse)
                                            .ToList();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Mort")
            {
                string[] tokens = input.Split();
                string command = tokens[0];
                int value = int.Parse(tokens[1]);
                switch (command)
                {
                    case "Add":
                        sugarCubes.Add(value);
                        break;

                    case "Remove":
                        sugarCubes.Remove(value);
                        break;

                    case "Replace":
                        int index = sugarCubes.IndexOf(value);
                        sugarCubes.Remove(value);
                        sugarCubes.Insert(index, int.Parse(tokens[2]));
                        break;

                    case "Collapse":
                        sugarCubes = sugarCubes.Where(x => x >= value).ToList();
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", sugarCubes));
        }
    }
}
