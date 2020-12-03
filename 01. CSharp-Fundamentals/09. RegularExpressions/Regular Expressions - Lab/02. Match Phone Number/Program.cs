using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Match_Phone_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"(\+359)( ?-?)2\2(\d{3})\2(\d{4})\b");

            var phones = Console.ReadLine();

            var phoneMatches = regex.Matches(phones);

            Console.WriteLine(string.Join(", ", phoneMatches));
        }
    }
}
