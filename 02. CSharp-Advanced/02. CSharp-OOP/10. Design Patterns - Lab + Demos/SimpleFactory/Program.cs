using System;

namespace SimpleFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            IAnimal animal = AnimalFactory.CreateAnimal("Tiger");

            Console.WriteLine(animal.Name);
        }
    }
}
