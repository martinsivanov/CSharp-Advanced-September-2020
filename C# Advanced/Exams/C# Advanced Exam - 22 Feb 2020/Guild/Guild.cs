using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            this.roster = new List<Player>();
        }
        public int Count => this.roster.Count();
        public string Name { get; set; }
        public int Capacity { get; set; }


        public void AddPlayer(Player player)
        {
            if (this.roster.Count < this.Capacity)
            {
                this.roster.Add(player);
            }
        }
        public bool RemovePlayer(string name) 
        {
            Player player = roster.FirstOrDefault(p => p.Name == name);
            if (player != null)
            {
                roster.Remove(player);
                return true;
            }
            return false;
        }
        public void PromotePlayer(string name)
        {
            foreach (var player in roster)
            {
                if (player.Name == name)
                {
                    player.Rank = "Member";
                }
            }
        }
        public void DemotePlayer(string name)
        {
            foreach (var player in roster)
            {
                if (player.Name == name)
                {
                    player.Rank = "Trial";
                }
            }
        }
        public Player[] KickPlayersByClass(string @class) 
        {
            Player[] player = roster.FindAll(p => p.Class == @class).ToArray();
            roster.RemoveAll(p => p.Class == @class);
            return player;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {this.Name}");
            foreach (var player in this.roster)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
