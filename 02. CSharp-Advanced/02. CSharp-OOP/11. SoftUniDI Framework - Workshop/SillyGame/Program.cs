using SillyGame.DI;
using SillyGame.IO.Contracts;
using System;

namespace SillyGame
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigureDI module = new ConfigureDI();

            Console.WriteLine(module.GetMapping<IReader>().Name);
        }
    }
}
