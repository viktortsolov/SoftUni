using Heroes.Common;

namespace Heroes.Models
{
    public class Rogue : BaseHero
    {
        public Rogue(string name) 
            : base(name)
        {
        }
        public override int Power => 80;
        public override string CastAbility()
        {
            return string.Format(Messages.ROGUE_AND_WARRIOR_MSG, this.GetType().Name, this.Name, this.Power);
        }
    }
}
