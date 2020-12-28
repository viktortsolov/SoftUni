using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._The_Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine()
                .Split()
                .ToList();

            string input = string.Empty;
            List<string> filters = new List<string>();

            while ((input = Console.ReadLine()) != "Print")
            {
                string[] tokens = input.Split(";");

                string command = tokens[0];
                string filter = tokens[1];
                string argument = tokens[2];

                if (command == "Add filter")
                {
                    filters.Add($"{filter};{argument}");
                }
                else if (command == "Remove filter")
                {
                    filters.Remove($"{filter};{argument}");
                }
            }

            foreach (var filterLine in filters)
            {
                string[] tokens = filterLine.Split(";");

                string filter = tokens[0];
                string argument = tokens[1];

                switch (filter)
                {
                    case "Starts with":
                        people = people.Where(p => !p.StartsWith(argument)).ToList();
                        break;

                    case "Contains":
                        people = people.Where(p => !p.Contains(argument)).ToList();
                        break;

                    case "Length":
                        people = people.Where(p => p.Length != int.Parse(argument)).ToList();
                        break;

                    case "Ends with":
                        people = people.Where(p => !p.EndsWith(argument)).ToList();
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", people));
        }
    }
}
