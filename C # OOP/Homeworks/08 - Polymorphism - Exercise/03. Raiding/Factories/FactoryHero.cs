using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Factories
{
    public class FactoryHero
    {
        public FactoryHero()
        {

        }

        public BaseHero CreateHero(string heroName, string heroType)
        {
            BaseHero baseHero = null;
            if (heroType == "Druid")
            {
                baseHero = new Druid(heroName);
            }
            else if (heroType == "Paladin")
            {
                baseHero = new Paladin(heroName);
            }
            else if (heroType == "Rogue")
            {
                baseHero = new Rogue(heroName);

            }
            else if (heroType == "Warrior")
            {
                baseHero = new Warrior(heroName);

            }
            else
            {
                Console.WriteLine("Invalid hero!");
            }

            return baseHero;
        }
    }
}
