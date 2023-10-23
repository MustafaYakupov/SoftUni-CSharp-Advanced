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
            this.Name = name;
            this.Capacity = capacity;
            this.roster = new List<Player>();
        }

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
            return this.roster.Remove(this.roster.FirstOrDefault(x => x.Name == name));
        }

        public void PromotePlayer(string name)
        {
            if (this.roster.Where(x => x.Name == name).Where(y => y.Rank == "Trial").First() != null)
            {
                this.roster.Where(x => x.Name == name).First().Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            if (this.roster.Where(x => x.Name == name).Where(y => y.Rank == "Member").First() != null)
            {
                this.roster.Where(x => x.Name == name).First().Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string @class) 
        {
            Player[] kickedPlayers = new Player[this.roster.FindAll(x => x.Class == @class).Count];

            // this.roster.FindAll(x => x.Class == @class);

            int index = 0;

            foreach (var player in this.roster.FindAll(x => x.Class == @class))
            {
                kickedPlayers[index] = player;
                this.roster.Remove(player);
                index++;
            }

            return kickedPlayers;
        }

        public int Count => this.roster.Count;

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {this.Name}");

            foreach (var player in this.roster)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
