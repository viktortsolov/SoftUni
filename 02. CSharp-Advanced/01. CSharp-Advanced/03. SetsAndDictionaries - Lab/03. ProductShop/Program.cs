using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace _03._ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            SortedDictionary<string, Dictionary<string, decimal>> shops = new SortedDictionary<string, Dictionary<string, decimal>>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Revision")
            {
                var cmdArg = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string shop = cmdArg[0];
                if (!shops.ContainsKey(shop))
                {
                    shops[shop] = new Dictionary<string, decimal>();
                }
                shops[shop].Add(cmdArg[1], decimal.Parse(cmdArg[2]));
            }

            foreach (var shop in shops)
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {(double)product.Value}");
                }
            }
        }
    }
}
