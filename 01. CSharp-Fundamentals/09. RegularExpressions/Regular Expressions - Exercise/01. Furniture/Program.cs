using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01._Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@">>([A-Za-z]+)<<(\d*\.?\d+)!(\d+)");
            string input = string.Empty;

            List<string> furniture = new List<string>();
            double sum = 0;

            while ((input = Console.ReadLine()) != "Purchase")
            {
                Match match = regex.Match(input);

                if (match.Success)
                {
                    furniture.Add(match.Groups[1].Value);
                    sum += double.Parse(match.Groups[2].Value) * double.Parse(match.Groups[3].Value);
                }
            }

            Console.WriteLine("Bought furniture:");
            if (furniture.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, furniture));
            }
            Console.WriteLine($"Total money spend: {sum:f2}");
        }
    }
}
