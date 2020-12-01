using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._List_Manipulation_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string input = string.Empty;
            bool isChanged = false;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] command = input.Split();

                switch (command[0])
                {
                    case "Contains":
                        if (numbers.Contains(int.Parse(command[1])))
                            Console.WriteLine("Yes");
                        else
                            Console.WriteLine("No such number");
                        break;

                    case "PrintEven":
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] % 2 == 0)
                            {

                                Console.Write(numbers[i] + " ");
                            }
                        }
                        Console.WriteLine();
                        break;

                    case "PrintOdd":
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] % 2 != 0)
                            {

                                Console.Write(numbers[i] + " ");
                            }
                        }
                        Console.WriteLine();
                        break;

                    case "GetSum":
                        Console.WriteLine(numbers.Sum());
                        break;

                    case "Filter":
                        switch (command[1])
                        {
                            case ">":
                                for (int i = 0; i < numbers.Count; i++)
                                {
                                    int number = int.Parse(command[2]);
                                    if (numbers[i] > number)
                                    {
                                        Console.Write(numbers[i] + " ");
                                    }
                                }
                                Console.WriteLine();
                                break;

                            case ">=":
                                for (int i = 0; i < numbers.Count; i++)
                                {
                                    int number = int.Parse(command[2]);
                                    if (numbers[i] >= number)
                                    {
                                        Console.Write(numbers[i] + " ");
                                    }
                                }
                                Console.WriteLine();
                                break;

                            case "<":
                                for (int i = 0; i < numbers.Count; i++)
                                {
                                    int number = int.Parse(command[2]);
                                    if (numbers[i] < number)
                                    {
                                        Console.Write(numbers[i] + " ");
                                    }
                                }
                                Console.WriteLine();
                                break;

                            case "<=":
                                for (int i = 0; i < numbers.Count; i++)
                                {
                                    int number = int.Parse(command[2]);
                                    if (numbers[i] <= number)
                                    {
                                        Console.Write(numbers[i] + " ");
                                    }
                                }
                                Console.WriteLine();
                                break;
                        }
                        break;

                    case "Add":
                        numbers.Add(int.Parse(command[1]));
                        isChanged = true;
                        break;

                    case "Remove":
                        numbers.Remove(int.Parse(command[1]));
                        isChanged = true;
                        break;

                    case "RemoveAt":
                        numbers.RemoveAt(int.Parse(command[1]));
                        isChanged = true;
                        break;

                    case "Insert":
                        numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                        isChanged = true;
                        break;
                }
            }

            if (isChanged)
                Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
