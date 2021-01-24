using MilitaryElite.Enumerations;
using MilitaryElite.Interfaces;
using System.Collections.Generic;

namespace MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id, string firstName, string lastName, decimal salary, SoldierCorpEnum soldierCorpEnum, ICollection<IMission> missions)
            : base(id, firstName, lastName, salary, soldierCorpEnum)
        {
            Missions = missions;
        }

        public ICollection<IMission> Missions { get; }
    }
}
