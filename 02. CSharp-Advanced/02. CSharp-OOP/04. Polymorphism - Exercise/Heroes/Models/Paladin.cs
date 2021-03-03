using Heroes.Common;

namespace Heroes.Models
{
    public class Paladin : BaseHero
    {
        public Paladin(string name) 
            : base(name)
        {
        }
        public override int Power => 100;

        public override string CastAbility()
        {
            return string.Format(Messages.DRUID_AND_PALADIN_MSG, this.GetType().Name, this.Name, this.Power);
        }
    }
}
