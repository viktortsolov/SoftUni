namespace Heroes.Models
{
    public abstract class BaseHero
    {
        protected BaseHero(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public virtual int Power { get; }

        public abstract string CastAbility();
    }
}
