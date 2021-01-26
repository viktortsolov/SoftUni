using Heros.Common;

namespace Heros.Models
{
    public class Rogue : BaseHero
    {
        public Rogue(string name) 
            : base(name)
        {
        }

        public override int Power => Constants.DRUID_AND_ROGUE_POWER;

        public override string CastAbility()
        {
            return base.CastAbility() + string.Format(Constants.ROGUE_AND_WARRIOR_MSG, Name, Power);
        }
    }
}
