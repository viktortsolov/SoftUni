using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firstBox = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)); 

            Stack<int> secondBox = new Stack<int>(Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse));

            List<int> numbers = new List<int>();

            while (firstBox.Count > 0 && secondBox.Count > 0)
            {
                int firstItem = firstBox.Peek();
                int secondItem = secondBox.Pop();

                int sum = firstItem + secondItem;

                if (sum % 2 == 0)
                {
                    numbers.Add(sum);
                    firstBox.Dequeue();
                }
                else
                {
                    firstBox.Enqueue(secondItem);
                }
            }

            if (firstBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (numbers.Sum() >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {numbers.Sum()}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {numbers.Sum()}");
            }
        }
    }
}
