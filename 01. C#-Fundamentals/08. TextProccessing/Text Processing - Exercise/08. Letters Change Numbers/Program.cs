using System;
using System.Xml.XPath;

namespace _08._Letters_Change_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                               .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            double sum = 0;

            foreach (string pair in input)
            {
                char firstLetter = pair[0];
                char lastLetter = pair[pair.Length - 1];

                string numAsString = pair.Substring(1, pair.Length - 2);
                double number = double.Parse(numAsString);

                if (Char.IsUpper(firstLetter))
                {
                    int position = firstLetter - 64;
                    number /= position;
                }
                else
                {
                    int position = firstLetter - 96;
                    number *= position;
                }

                if (Char.IsUpper(lastLetter))
                {
                    int position = lastLetter - 64;
                    number -= position;
                }
                else
                {
                    int position = lastLetter - 96;
                    number += position;
                }

                sum += number;
            }

            Console.WriteLine($"{sum:f2}");
        }
    }
}
