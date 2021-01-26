using Heros.Common;

namespace Heros.Models
{
    public class Warrior : BaseHero
    {
        public Warrior(string name) 
            : base(name)
        {
        }

        public override int Power => Constants.PALADIN_AND_WARRIOR_POWER;

        public override string CastAbility()
        {
            return base.CastAbility() + string.Format(Constants.ROGUE_AND_WARRIOR_MSG, Name, Power);
        }
    }
}
