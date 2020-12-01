using System;
using System.Collections.Generic;

namespace _4._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> output = new Dictionary<string, List<double>>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "buy")
            {
                string[] currentProduct = command.Split();

                string productName = currentProduct[0];
                double productPrice = double.Parse(currentProduct[1]);
                double quantity = double.Parse(currentProduct[2]);

                if (!output.ContainsKey(productName))
                {
                    output.Add(productName, new List<double> { productPrice, quantity });
                }
                else
                {
                    output[productName][0] = productPrice;
                    output[productName][1] += quantity;
                }
            }

            foreach (var pair in output)
            {
                double totalPrice = pair.Value[0] * pair.Value[1];
                Console.WriteLine($"{pair.Key} -> {totalPrice:F2}");
            }
        }
    }
}
