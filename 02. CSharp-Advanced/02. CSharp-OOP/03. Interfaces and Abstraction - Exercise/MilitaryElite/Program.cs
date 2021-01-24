using System;
using System.Collections.Generic;
using System.Linq;

using MilitaryElite.Interfaces;
using MilitaryElite.Models;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ICollection<ISoldier> soldiers = new List<ISoldier>();

            string command;
            ISoldier soldier;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArg = command.Split();

                string soldierType = cmdArg[0];

                if (soldierType == typeof(Private).Name)
                {
                    //TODO: Create private
                    //soldier = new Private(id, firstName, lastName, salary)
                }
                else if (soldierType == typeof(Spy).Name)
                {

                }
                else if (soldierType == typeof(LieutenantGeneral).Name)
                {
                    ICollection<Private> lpr = new List<Private>();

                    //TODO: Loop the soldiers and find the privates.
                }
                //TODO: Create the other soldiers.
            }


            PrintResult(soldiers);
        }

        private static void PrintResult(ICollection<ISoldier> soldiers)
        {
            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}
