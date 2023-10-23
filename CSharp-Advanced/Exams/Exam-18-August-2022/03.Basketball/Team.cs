using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        private List<Player> players;
        public Team(string name, int openPositions, char group)
        {
            this.Name = name;
            this.OpenPositions = openPositions;
            this.Group = group;
            this.players = new List<Player>();
        }

        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }

        public int Count => this.players.Count;

        public string AddPlayer(Player player)
        {
            if (this.OpenPositions > 0)
            {
                if (string.IsNullOrEmpty(player.Name))
                {
                    throw new InvalidOperationException("Invalid player's information.");
                }

                if (player.Rating < 80)
                {
                    return "Invalid player's rating.";
                }

                this.OpenPositions--;
                this.players.Add(player);
                return $"Successfully added {player.Name} to the team. Remaining open positions: {this.OpenPositions}.";

            }
            else
            {
                return "There are no more open positions.";
            }
        }

        public bool RemovePlayer(string name)
        {
            var playerToRemove = this.players.FirstOrDefault(x => x.Name == name);

            if (playerToRemove == null)
            {
                return false;
            }

            this.players.Remove(playerToRemove);
            this.OpenPositions++;
            return true;
        }

        public int RemovePlayerByPosition(string position)
        {
            var playersToRemove = this.players.FindAll(x => x.Position == position);

            if (playersToRemove == null)
            {
                return 0;
            }

            this.players.RemoveAll(x => x.Position == position);
            this.OpenPositions += playersToRemove.Count;
            return playersToRemove.Count;
        }

        public Player RetirePlayer(string name)
        {
            var playerToRetire = this.players.FirstOrDefault(x => x.Name == name);

            if (playerToRetire == null)
            {
                return null;
            }

            this.players.Where(x => x.Name == name).Select(y => y.Retired = true);
            return playerToRetire;
        }

        public List<Player> AwardPlayers(int games)
        {
            var resultList = this.players.FindAll(x => x.Games >= games);
            return resultList;
        }

        public string Report()
        {
            var notRetiredPlayers = this.players.FindAll(x => x.Retired == false);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Active players competing for Team {this.Name} from Group {this.Group}:");

            foreach (var player in notRetiredPlayers)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
