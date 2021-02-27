using _07.MilitaryElite.Enumerations;

namespace _07.MilitaryElite.Contracts
{
    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corps { get; }

    }
}
