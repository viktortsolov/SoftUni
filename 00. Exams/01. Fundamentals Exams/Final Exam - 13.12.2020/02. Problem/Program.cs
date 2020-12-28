using System;
using System.Text.RegularExpressions;

namespace _02._Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Regex regex = new Regex(@"^(.+)>(?<digits>\d{3})\|(?<lower>[a-z]{3})\|(?<upper>[A-Z]{3})\|(?<symbols>.+)<\1$");
            for (int i = 0; i < n; i++)
            {
                string password = Console.ReadLine();
                var match = regex.Match(password);

                if (!match.Success)
                {
                    Console.WriteLine("Try another password!");
                }
                else
                {
                    Console.WriteLine($"Password: {match.Groups["digits"]}{match.Groups["lower"]}{match.Groups["upper"]}{match.Groups["symbols"]}");
                }
            }
        }
    }
}
