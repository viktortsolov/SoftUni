using System;

namespace _05._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            switch (product)
            {
                case "coffee":
                    Coffee(product, quantity); break;
                case "water":
                    Water(product, quantity); break;
                case "coke":
                    Coke(product, quantity); break;
                case "snacks":
                    Snacks(product, quantity); break;
            }
        }

        private static void Snacks(string product, int quantity)
        {
            Console.WriteLine($"{quantity*2:f2}");
        }

        private static void Coke(string product, int quantity)
        {
            Console.WriteLine($"{quantity*1.4:f2}");
        }

        private static void Water(string product, int quantity)
        {
            Console.WriteLine($"{quantity*1:f2}");
        }

        private static void Coffee(string product, int quantity)
        {
            Console.WriteLine($"{quantity*1.5:f2}");
        }
    }
}
