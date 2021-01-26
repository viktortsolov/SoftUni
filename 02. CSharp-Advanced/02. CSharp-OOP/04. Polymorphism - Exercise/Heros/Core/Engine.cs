using System;
using System.Collections.Generic;
using Heros.Factories;
using Heros.Models;

namespace Heros.Core
{
    public class Engine
    {
        private readonly HeroFactory heroFactory;
        public Engine()
        {
            this.heroFactory = new HeroFactory();
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());
            List<BaseHero> heros = new List<BaseHero>();

            for (int i = 0; i < n; i++)
            {
                try
                {
                    BaseHero hero = ProcessHero();
                    heros.Add(hero);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                    i--;
                }
            }

            int bosshealth = int.Parse(Console.ReadLine());

            foreach (var hero in heros)
            {
                Console.WriteLine(hero.CastAbility());
                bosshealth -= hero.Power;
            }

            if (bosshealth <= 0)
                Console.WriteLine("Victory!");
            else
                Console.WriteLine("Defeat...");
        }

        private BaseHero ProcessHero()
        {
            string name = Console.ReadLine();
            string type = Console.ReadLine();

            BaseHero hero = this.heroFactory.CreateHero(type, name);

            return hero;
        }
    }
}
