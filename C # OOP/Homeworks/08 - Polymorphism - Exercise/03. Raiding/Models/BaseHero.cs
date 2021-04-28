using Raiding.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public abstract class BaseHero : ICastAbility
    {

        //	Druid – power = 80
        //	Paladin – power = 100
        //	Rogue – power = 80
        //	Warrior – power = 100

        private const int DRUID_POWER = 80;
        private const int PALADIN_POWER = 100;
        private const int ROGUE_POWER = 80;
        private const int WORRIOR_POWER = 100;

        private int power;

        protected BaseHero(string name)
        {
            Name = name;
            Power = power;
        }

        public string Name { get; private set; }
        public  int Power
        {
            get
            {
                return this.power;
            }
            private set
            {
                if (this.GetType().Name == "Druid")
                {
                    this.power = DRUID_POWER;
                }
                else if (this.GetType().Name == "Paladin")
                {
                    this.power = PALADIN_POWER;
                }
                else if (this.GetType().Name == "Rogue")
                {
                    this.power = ROGUE_POWER;
                }
                else if (this.GetType().Name == "Warrior")
                {
                    this.power = WORRIOR_POWER;
                }
            }
        }



        public virtual string CastAbility()
        {
            if (this.GetType().Name == "Druid" || this.GetType().Name == "Paladin")
            {
                  return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
            }
            else
            {
                return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
            }
        }
    }
}
