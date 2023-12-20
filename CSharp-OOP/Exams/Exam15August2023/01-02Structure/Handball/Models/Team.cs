using Handball.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public class Team : ITeam
    {
        private string name;
        private int pointsEarned = 0;
        private double overallRating;
        private List<IPlayer> players;

        public Team(string name)
        {
            Name = name;
            players = new List<IPlayer>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Team name cannot be null or empty.");
                }

                name = value;
            }
        }

        public int PointsEarned
        {
            get => pointsEarned;
            private set
            {
                pointsEarned = value;
            }
        }

        public double OverallRating
        {
            get
            {
                if (players.Count == 0)
                {
                    return 0;
                }

                double averageRating = players.Sum(p => p.Rating) / players.Count;
                return averageRating;
            }
        }

        public IReadOnlyCollection<IPlayer> Players => players.AsReadOnly();

        public void SignContract(IPlayer player)
        {
            players.Add(player);
        }

        public void Win()
        {
            PointsEarned += 3;

            foreach (var player in players)
            {
                player.IncreaseRating();
            }
        }
        public void Lose()
        {
            foreach (var player in players)
            {
                player.DecreaseRating();
            }
        }

        public void Draw()
        {
            PointsEarned++;
            IPlayer goalkeeper = players.FirstOrDefault(p => p.GetType().Name == "Goalkeeper");
            goalkeeper.IncreaseRating();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Team: {Name} Points: {PointsEarned}");

            sb.AppendLine($"--Overall rating: {OverallRating}");

            if (players.Count > 0)
            {
                sb.Append("--Players: ");
                foreach (var player in players.SkipLast(1))
                {
                    sb.Append(player.Name + ", ");
                }

                sb.Append(players.Last().Name);
            }
            else
            {
                sb.Append($"--Players: none");
            }

            return sb.ToString().Trim();
        }
    }
}
