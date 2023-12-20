using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05FootbalTeamGenerator.Models
{
    public class Team
    {
        private string name;
        private readonly List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public void AddPlayer(string teamName, Player player)
        {
            if (this.Name != teamName)
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }

            this.players.Add(player);
        }

        public void RemovePlayer(string teamName, string playerName)
        {
            if (this.players.FirstOrDefault(x => x.Name == playerName) == null)
            {
                throw new ArgumentException($"Player {playerName} is not in {teamName} team.");
            }

            this.players.Remove(this.players.FirstOrDefault(x => x.Name == playerName));
        }

        public double GetRating
        {
            get
            {
                if (players.Any())
                {
                    return players.Average(p => p.PlayerSkillLevel());
                }

                return 0;
            }
        }
    }
}
