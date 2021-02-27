using System;

using _07.MilitaryElite.Contracts;
using _07.MilitaryElite.Exceptions;
using _07.MilitaryElite.Enumerations;

namespace _07.MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            this.Corps = this.TryParseCorps(corps);
        }

        public Corps Corps { get; private set; }

        private Corps TryParseCorps(string corpsString)
        {
            bool parsed = Enum.TryParse<Corps>(corpsString, out Corps corps);

            if (!parsed)
            {
                throw new InvalidCorpException();
            }
            else
            {
                return corps;
            }
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine
                + $"Corps: {Corps}";
        }
    }
}
