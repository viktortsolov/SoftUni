using Heroes.Common;

namespace Heroes.Models
{
    public class Warrior : BaseHero
    {
        public Warrior(string name) 
            : base(name)
        {
        }
        public override int Power => 100;
        public override string CastAbility()
        {
            return string.Format(Messages.ROGUE_AND_WARRIOR_MSG, this.GetType().Name, this.Name, this.Power);
        }
    }
}
