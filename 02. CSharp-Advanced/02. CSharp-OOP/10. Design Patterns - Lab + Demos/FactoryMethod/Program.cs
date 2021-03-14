using FactoryMethod.Contracts;
using FactoryMethod.Contracts.Factories;
using SimpleFactory;

using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Which continent you wanna play?");
            string continent = Console.ReadLine();

            IAnimalFactory factory = new EuroFactory();
            if (continent == "Africa")
            {
                factory = new AfricaFactory();
            }

            ICarnivore animal = factory.GetCarnivore();
        }
    }
}
