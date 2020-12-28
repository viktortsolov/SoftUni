using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            Dictionary<string, List<string>> likes = new Dictionary<string, List<string>>();

            int unlike = 0;
            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] cmdArg = input.Split("-", StringSplitOptions.RemoveEmptyEntries);

                string command = cmdArg[0];
                string guest = cmdArg[1];
                string meal = cmdArg[2];

                if (command == "Like")
                {
                    if (!likes.ContainsKey(guest))
                    {
                        likes.Add(guest, new List<string>());
                    }

                    if (!likes[guest].Contains(meal))
                    {
                        likes[guest].Add(meal);
                    }
                }
                else
                {
                    if (!likes.ContainsKey(guest))
                    {
                        Console.WriteLine($"{guest} is not at the party.");
                        continue;
                    }

                    if (!likes[guest].Contains(meal))
                    {
                        Console.WriteLine($"{guest} doesn't have the {meal} in his/her collection.");
                    }
                    else
                    {
                        Console.WriteLine($"{guest} doesn't like the {meal}.");
                        likes[guest].Remove(meal);
                        unlike++;
                    }
                }
            }
            foreach (var guest in likes.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{guest.Key}: {string.Join(", ", guest.Value)}");
            }
            Console.WriteLine($"Unliked meals: {unlike}");
        }
    }
}
