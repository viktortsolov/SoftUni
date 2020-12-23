using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityOfFood = int.Parse(Console.ReadLine());
            int[] quantityOfOrder = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();


            Queue<int> orders = new Queue<int>(quantityOfOrder);

            Console.WriteLine(orders.Max());

            bool isSuccess = true;

            while (orders.Count > 0)
            {
                if (quantityOfFood - orders.Peek() >= 0)
                {
                    quantityOfFood -= orders.Dequeue();
                }
                else
                {
                    isSuccess = false;
                    break;
                }
            }

            if (isSuccess)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
            }
        }
    }
}
