using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Magic_Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> deck = Console.ReadLine()
                .Split(":", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> finalDeck = new List<string>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Ready")
            {
                string[] tokens = input.Split();
                string command = tokens[0];

                switch (command)
                {
                    case "Add":
                        if (deck.Contains(tokens[1]))
                        {
                            finalDeck.Add(tokens[1]);
                        }
                        else
                        {
                            Console.WriteLine("Card not found.");
                        }
                        break;

                    case "Insert":
                        int index = int.Parse(tokens[2]);
                        if (deck.Contains(tokens[1]) && (index >= 0 && index < finalDeck.Count))
                        {
                            finalDeck.Insert(index, tokens[1]);
                        }
                        else
                        {
                            Console.WriteLine("Error!");
                        }
                        break;

                    case "Remove":
                        if (finalDeck.Contains(tokens[1]))
                        {
                            finalDeck.Remove(tokens[1]);
                        }
                        else
                        {
                            Console.WriteLine("Card not found.");
                        }
                        break;

                    case "Swap":
                        int indexOne = finalDeck.IndexOf(tokens[1]);
                        int indexTwo = finalDeck.IndexOf(tokens[2]);

                        string temp = finalDeck[indexOne];
                        finalDeck[indexOne] = finalDeck[indexTwo];
                        finalDeck[indexTwo] = temp;
                        break;

                    case "Shuffle":
                        finalDeck.Reverse();
                        break;
                }
            }
            Console.WriteLine(String.Join(" ", finalDeck));
        }
    }
}
