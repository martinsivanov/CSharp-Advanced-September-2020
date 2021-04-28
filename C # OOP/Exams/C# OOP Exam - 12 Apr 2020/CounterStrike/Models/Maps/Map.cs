using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        private List<IPlayer> terrorists;
        private List<IPlayer> counterTerrorists;
        public Map()
        {
            this.terrorists = new List<IPlayer>();
            this.counterTerrorists = new List<IPlayer>();
        }
        public string Start(ICollection<IPlayer> players)
        {

            //TERRORIST ATTACK
            foreach (var player in players)
            {
                if (player.GetType().Name == "Terrorist")
                {
                    terrorists.Add(player);
                }
                else
                {
                    counterTerrorists.Add(player);
                }
            }
            while (terrorists.Any(t => t.IsAlive) && counterTerrorists.Any(ct => ct.IsAlive))
            {
                foreach (var terrorist in terrorists)
                {
                    //if (!terrorist.IsAlive)
                    //{
                    //    continue;
                    //}
                    if (terrorist.IsAlive)
                    {
                        int fire = terrorist.Gun.Fire();
                        foreach (var counterTerrorist in counterTerrorists)
                        {
                            if (counterTerrorist.IsAlive)
                            {
                                counterTerrorist.TakeDamage(fire);
                            }
                        }
                    }
                }
                foreach (var counterTerrorist in counterTerrorists)
                {
                    //if (!counterTerrorist.IsAlive)
                    //{
                    //    continue;
                    //}


                    int fire = counterTerrorist.Gun.Fire();
                    foreach (var terrorist in terrorists)
                    {
                        if (terrorist.IsAlive)
                        {
                            terrorist.TakeDamage(fire);

                        }
                    }
                }
            }
            //COUNTER_TERRORIST ATTACK


            if (terrorists.Any(t => t.IsAlive))
            {
                return "Terrorist wins!";
            }
            else
            {
                return "Counter Terrorist wins!";
            }

        }
    }
}
