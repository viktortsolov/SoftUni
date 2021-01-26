using Heros.Common;

namespace Heros.Models
{
    public class Paladin : BaseHero
    {
        public Paladin(string name) 
            : base(name)
        {
        }

        public override int Power => Constants.PALADIN_AND_WARRIOR_POWER;

        public override string CastAbility()
        {
            return base.CastAbility() + string.Format(Constants.DRUID_AND_PALADIN_MSG, Name, Power);
        }
    }
}
