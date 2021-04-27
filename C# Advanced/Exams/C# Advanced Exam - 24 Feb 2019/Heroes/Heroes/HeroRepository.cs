using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        private List<Hero> data;


        public HeroRepository()
        {
            this.data = new List<Hero>();
        }

        public int Count => this.data.Count();

        public void Add(Hero hero)
        {
            this.data.Add(hero);
        }
        public void Remove(string name)
        {
            Hero hero = data.FirstOrDefault(i => i.Name == name);
            if (hero != null)
            {
                this.data.Remove(hero);
            }
        }
        public Hero GetHeroWithHighestStrength()
        {
            Hero hero = data.OrderByDescending(h => h.Item.Strength).First();
            return hero;
        }
        public Hero GetHeroWithHighestAbility()
        {
            Hero hero = data.OrderByDescending(h => h.Item.Ability).First();
            return hero;
        }
        public Hero GetHeroWithHighestIntelligence()
        {
            Hero hero = data.OrderByDescending(h => h.Item.Intelligence).First();
            return hero;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var hero in this.data)
            {
                sb.AppendLine(hero.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
