using Heros.Contracts;

namespace Heros.Models
{
    public abstract class BaseHero : ICastAbility
    {
        public BaseHero(string name)
        {
            Name = name;
        }
        public string Name { get; }
        public virtual int Power { get; }

        public virtual string CastAbility()
        {
            return $"{this.GetType().Name} - ";
        }
    }
}
