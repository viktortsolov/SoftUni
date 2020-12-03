using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Race
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            var input = string.Empty;

            Regex nameMatch = new Regex(@"[A-Za-z]");
            Regex kmMatch = new Regex(@"\d");

            var places = new Dictionary<string, int>();

            while ((input = Console.ReadLine()) != "end of race")
            {
                var nameChars = nameMatch.Matches(input);
                var kmChars = kmMatch.Matches(input);

                string name = string.Concat(nameChars);
                var km = kmChars.Select(x => int.Parse(x.Value)).Sum();

                if (names.Contains(name))
                {
                    if (places.ContainsKey(name))
                    {
                        places[name] += km;
                    }
                    else
                    {
                        places.Add(name, km);
                    }
                }
            }

            var sorted = places.OrderByDescending(x => x.Value).Select(x => x.Key).ToList();

            Console.WriteLine($"1st place: {sorted[0]}");
            Console.WriteLine($"2nd place: {sorted[1]}");
            Console.WriteLine($"3rd place: {sorted[2]}");
        }
    }
}
