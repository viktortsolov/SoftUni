using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceOfBullet = int.Parse(Console.ReadLine());
            int sizeOfGunBarrel = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>();
            var bulletsAsArray = Console.ReadLine()
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToArray();
            foreach (var item in bulletsAsArray)
            {
                bullets.Push(item);
            }

            Queue<int> locks = new Queue<int>();
            var locksAsArray = Console.ReadLine()
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToArray();
            foreach (var item in locksAsArray)
            {
                locks.Enqueue(item);
            }

            int value = int.Parse(Console.ReadLine());

            int reloadedBullets = 0;
            int bulletsPrice = 0;
            while (bullets.Count != 0 && locks.Count != 0)
            {
                bool isBigger = bullets.Pop() > locks.Peek();
                reloadedBullets++;
                bulletsPrice += priceOfBullet;
                if (isBigger)
                {
                    Console.WriteLine("Ping!");
                }
                else
                {
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                }

                if (reloadedBullets == sizeOfGunBarrel && bullets.Count != 0)
                {
                    Console.WriteLine("Reloading!");
                    reloadedBullets = 0;
                }
            }

            if (bullets.Count == 0 && locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${value - bulletsPrice}");
            }
        }
    }
}
