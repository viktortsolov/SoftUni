using Heroes.Common;
using Heroes.Models;
using System;

namespace Heroes.Factories
{
    public class HeroFactory
    {
        public HeroFactory()
        {

        }

        public BaseHero CreateHero(string heroName, string heroType)
        {
            BaseHero hero;

            if (heroType == "Druid")
            {
                hero = new Druid(heroName);
            }
            else if (heroType == "Rogue")
            {
                hero = new Rogue(heroName);
            }
            else if (heroType == "Warrior")
            {
                hero = new Warrior(heroName);
            }
            else if (heroType == "Paladin")
            {
                hero = new Paladin(heroName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.INVALID_HERO_EXC_MSG);
            }

            return hero;
        }
    }
}
