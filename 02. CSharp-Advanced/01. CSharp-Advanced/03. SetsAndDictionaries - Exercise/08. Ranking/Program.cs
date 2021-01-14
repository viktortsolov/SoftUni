using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> contestant = new Dictionary<string, Dictionary<string, int>>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end of contests")
            {
                var parameters = input.Split(':', StringSplitOptions.RemoveEmptyEntries);
                var contestName = parameters[0];
                var contestPassword = parameters[1];
                contests.Add(contestName, contestPassword);
            }

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                var parameters = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                var contestName = parameters[0];
                var contestPassword = parameters[1];
                var candidate = parameters[2];
                var points = int.Parse(parameters[3]);
                if (contests.ContainsKey(contestName))
                {
                    if (contests[contestName] == contestPassword)
                    {
                        if (!contestant.ContainsKey(candidate))
                        {
                            contestant.Add(candidate, new Dictionary<string, int>());
                        }

                        if (!contestant[candidate].ContainsKey(contestName))
                        {
                            contestant[candidate].Add(contestName, points);
                        }

                        else if (contestant[candidate][contestName] < points)
                        {
                            contestant[candidate][contestName] = points;
                        }
                    }
                }
            }

            foreach (var candidate in contestant.OrderByDescending(x => x.Value.Values.Sum()))
            {
                Console.WriteLine($"Best candidate is {candidate.Key} with total {candidate.Value.Values.Sum()} points.");
                break;
            }
            Console.WriteLine("Ranking:");
            foreach (var candidate in contestant.OrderBy(x => x.Key))
            {
                var name = candidate.Key;
                Console.WriteLine(name);
                foreach (var course in candidate.Value.OrderByDescending(x => x.Value))
                {
                    var courseName = course.Key;
                    var points = course.Value;
                    Console.WriteLine($"#  {courseName} -> {points}");
                }
            }
        }
    }
}
