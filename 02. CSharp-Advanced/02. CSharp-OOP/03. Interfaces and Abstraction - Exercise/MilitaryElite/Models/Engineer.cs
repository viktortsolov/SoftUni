using MilitaryElite.Enumerations;
using MilitaryElite.Interfaces;
using System.Collections.Generic;

namespace MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lastName, decimal salary, SoldierCorpEnum soldierCorpEnum, ICollection<IRepair> repairs)
            : base(id, firstName, lastName, salary, soldierCorpEnum)
        {
            Repairs = repairs;
        }

        public ICollection<IRepair> Repairs { get; }
    }
}
