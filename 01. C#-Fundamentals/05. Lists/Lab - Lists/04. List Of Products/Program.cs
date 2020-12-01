using System;
using System.Collections.Generic;

namespace _04._List_Of_Products
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> products = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string currentProduct = Console.ReadLine();
                products.Add(currentProduct);
            }

            for (int i = 0; i < n; i++)
                Console.WriteLine($"{i + 1}. {products[i]}");
        }
    }
}
