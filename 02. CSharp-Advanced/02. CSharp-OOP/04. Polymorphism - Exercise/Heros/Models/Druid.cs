using Heros.Common;

namespace Heros.Models
{
    public class Druid : BaseHero
    {
        public Druid(string name)
            : base(name)
        {
        }

        public override int Power => Constants.DRUID_AND_ROGUE_POWER;

        public override string CastAbility()
        {
            return base.CastAbility() + string.Format(Constants.DRUID_AND_PALADIN_MSG, Name, Power);
        }
    }
}
