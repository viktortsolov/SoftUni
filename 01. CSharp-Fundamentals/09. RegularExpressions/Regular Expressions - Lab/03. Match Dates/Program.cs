using System;
using System.Text.RegularExpressions;

namespace _03._Match_Dates
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"(\d{2})(.)(\w{3})\2([0-9]{4})");
            string input = Console.ReadLine();

            var matches = regex.Matches(input);
            foreach (Match match in matches)
            {
                Console.WriteLine($"Day: {match.Groups[1]}, Month: {match.Groups[3]}, Year: {match.Groups[4]}");
            }
        }
    }
}
