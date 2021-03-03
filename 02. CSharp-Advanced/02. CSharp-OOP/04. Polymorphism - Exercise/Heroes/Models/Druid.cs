using Heroes.Common;

namespace Heroes.Models
{
    public class Druid : BaseHero
    {
        public Druid(string name) 
            : base(name)
        {
        }
        public override int Power => 80;
        public override string CastAbility()
        {
            return string.Format(Messages.DRUID_AND_PALADIN_MSG, this.GetType().Name, this.Name, this.Power);
        }
    }
}
