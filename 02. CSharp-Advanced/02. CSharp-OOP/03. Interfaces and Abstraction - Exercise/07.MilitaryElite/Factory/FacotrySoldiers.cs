using System.Linq;
using System.Collections.Generic;

using _07.MilitaryElite.Models;
using _07.MilitaryElite.Contracts;
using _07.MilitaryElite.Exceptions;

namespace _07.MilitaryElite.Factory
{
    public class FacotrySoldiers
    {
        public ICollection<ISoldier> soldiers;

        public FacotrySoldiers()
        {
            soldiers = new List<ISoldier>();
        }

        public Soldier CreateSoldier(string soldierType, int id, string firstName, string lastName, string[] arg)
        {
            ISoldier soldier = null;

            if (soldierType == "Private")
            {
                decimal salary = decimal.Parse(arg[0]);
                soldier = new Private(id, firstName, lastName, salary);
            }
            else if (soldierType == "LieutenantGeneral")
            {
                decimal salary = decimal.Parse(arg[0]);
                ILieutenantGeneral general = new LieutenantGeneral(id, firstName, lastName, salary);

                string[] privateID = arg.Skip(1)
                    .ToArray();

                foreach (var prvID in privateID)
                {
                    ISoldier privateToAdd = soldiers
                        .First(s => s.Id == int.Parse(prvID));

                    general.AddPrivate(privateToAdd);
                }

                soldier = general;
            }
            else if (soldierType == "Engineer")
            {
                decimal salary = decimal.Parse(arg[0]);
                string corps = arg[1];

                IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);
                string[] repairsArg = arg.Skip(2)
                   .ToArray();

                for (int i = 0; i < repairsArg.Length; i += 2)
                {
                    string partName = repairsArg[i];
                    int hoursWoked = int.Parse(repairsArg[i + 1]);

                    IRepair repair = new Repair(partName, hoursWoked);

                    engineer.AddRepair(repair);
                }

                soldier = engineer;
            }
            else if (soldierType == "Commando")
            {
                decimal salary = decimal.Parse(arg[0]);
                string corps = arg[1];

                ICommando commando = new Commando(id, firstName, lastName, salary, corps);

                string[] missionArg = arg.Skip(2)
                   .ToArray();

                for (int i = 0; i < missionArg.Length; i += 2)
                {
                    try
                    {
                        string missionName = missionArg[i];
                        string missionState = missionArg[i + 1];
                        Mission mission = new Mission(missionName, missionState);
                        commando.AddMisions(mission);
                    }
                    catch (InvalidMissionException ime)
                    {
                        continue;
                    }
                }
                soldier = commando;
            }
            else if (soldierType == "Spy")
            {
                int codeNumber = int.Parse(arg[0]);

                soldier = new Spy(id, firstName, lastName, codeNumber);
            }

            if (soldier != null)
            {
                soldiers.Add(soldier);

            }
            return (Soldier)soldier;
        }
    }
}
