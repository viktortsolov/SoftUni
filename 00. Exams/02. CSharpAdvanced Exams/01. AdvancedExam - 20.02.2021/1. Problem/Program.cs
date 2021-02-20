using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine());
            Queue<int> plates = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            for (int i = 1; i <= waves; i++)
            {
                Stack<int> orcs = new Stack<int>(Console.ReadLine()
                                                               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                                               .Select(int.Parse));
                if (i % 3 == 0)
                {
                    int number = int.Parse(Console.ReadLine());
                    plates.Enqueue(number);
                }

                while (orcs.Count != 0 && plates.Count != 0)
                {
                    if (plates.Peek() == orcs.Peek())
                    {
                        plates.Dequeue();
                        orcs.Pop();
                    }
                    else if (orcs.Peek() > plates.Peek())
                    {
                        int plateValue = plates.Dequeue();
                        int orcValue = orcs.Pop() - plateValue;
                        orcs.Push(orcValue);
                    }
                    else
                    {
                        int orcValue = orcs.Pop();
                        int plateValue = plates.Dequeue() - orcValue;

                        var newPlates = new Queue<int>();
                        newPlates.Enqueue(plateValue);
                        while (plates.Count != 0)
                        {
                            newPlates.Enqueue(plates.Dequeue());
                        }
                        plates = newPlates;
                    }

                    if (plates.Count == 0)
                    {
                        Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                        Console.WriteLine($"Orcs left: {string.Join(", ", orcs)}");
                        return;
                    }
                }
            }
            Console.WriteLine("The people successfully repulsed the orc's attack.");
            Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
        }
    }
}
