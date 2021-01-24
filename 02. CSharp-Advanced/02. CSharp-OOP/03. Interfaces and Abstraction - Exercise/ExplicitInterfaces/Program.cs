using System;

using ExplicitInterfaces.Interfaces;
using ExplicitInterfaces.Models;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        public static void Main()
        {
            PrintNamesWithTypeCasting();
        }

        private static void PrintNamesWithTypeCasting()
        {
            var name = Console.ReadLine().Split();

            while (name[0] != "End")
            {
                var human = new Citizen(name[0]);
                Console.WriteLine(((IPerson)human).GetName());
                Console.WriteLine(((IResident)human).GetName());

                name = Console.ReadLine().Split();
            }
        }
    }
}
