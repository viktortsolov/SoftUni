using Heroes.Core.Contracts;
using Heroes.Factories;
using Heroes.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Heroes.Core
{
    public class Engine : IEngine
    {
        private readonly HeroFactory heroFactory;
        private readonly List<BaseHero> heros;
        public Engine()
        {
            this.heroFactory = new HeroFactory();
            this.heros = new List<BaseHero>();
        }
        public void Run()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                try
                {
                    BaseHero hero = ProcessHeroInfo();
                    heros.Add(hero);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    i--;
                }

            }
            int bossPower = int.Parse(Console.ReadLine());
            foreach (var hero in heros)
            {
                Console.WriteLine(hero.CastAbility());
            }
            int powerOfThem = heros.Sum(x => x.Power);
            if (powerOfThem>=bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }

        private BaseHero ProcessHeroInfo()
        {
            string name = Console.ReadLine();
            string type = Console.ReadLine();

            BaseHero currHero = this.heroFactory.CreateHero(name, type);

            return currHero;
        }
    }
}
