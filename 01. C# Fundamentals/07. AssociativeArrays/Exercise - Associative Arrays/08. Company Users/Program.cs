using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            var companies = new Dictionary<string, List<string>>();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArg = command.Split(" -> ");

                string companyName = cmdArg[0];
                string id = cmdArg[1];

                if (!companies.ContainsKey(companyName))
                {
                    companies.Add(companyName, new List<string>());
                }
                if (!companies[companyName].Contains(id))
                {
                    companies[companyName].Add(id);
                }
            }

            foreach (var pair in companies.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{pair.Key}");
                foreach (var item in pair.Value)
                {
                    Console.WriteLine($"-- {item}");
                }
            }
        }
    }
}
