using Raiding.Factories;
using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raiding.Core
{
    public class Engine : IEngine
    {
        private readonly FactoryHero factoryHero;
        private ICollection<BaseHero> heroes;
        public Engine()
        {
            this.factoryHero = new FactoryHero();
            this.heroes = new List<BaseHero>();
        }
        public void Run()
        {
            int needValidHeroes = int.Parse(Console.ReadLine());
            int counterValidHeroes = 0;
            while (counterValidHeroes != needValidHeroes)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                BaseHero baseHero = this.factoryHero.CreateHero(heroName, heroType);
                if (baseHero != null)
                {
                    this.heroes.Add(baseHero);
                    counterValidHeroes++;
                }

            }

            int BossHp = int.Parse(Console.ReadLine());

            double heroesPower = this.heroes.Sum(h => h.Power);

            foreach (BaseHero hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }

            if (heroesPower >= BossHp && BossHp > 0)
            {
                Console.WriteLine("Victory!");
            }
            else if (heroesPower < BossHp)
            {
                Console.WriteLine("Defeat...");
            }

        }
    }
}
