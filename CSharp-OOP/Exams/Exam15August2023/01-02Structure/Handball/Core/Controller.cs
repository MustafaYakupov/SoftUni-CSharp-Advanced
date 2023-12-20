using Handball.Core.Contracts;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories;
using Handball.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Core
{
    public class Controller : IController
    {
        private IRepository<IPlayer> players;
        private IRepository<ITeam> teams;

        public Controller()
        {
            players = new PlayerRepository();
            teams = new TeamRepository();
        }

        public string NewTeam(string name)
        {
            if (teams.ExistsModel(name))
            {
                return $"{name} is already added to the {teams.GetType().Name}.";
            }

            ITeam team = new Team(name);
            teams.AddModel(team);
            return $"{name} is successfully added to the {teams.GetType().Name}.";
        }

        public string NewPlayer(string typeName, string name)
        {
            IPlayer player = players.Models.FirstOrDefault(p => p.Name == name);

            if (player != null)
            {
                return $"{name} is already added to the {players.GetType().Name} as {player.GetType().Name}.";
            }

            if (typeName == "Goalkeeper")
            {
                player = new Goalkeeper(name);
            }
            else if (typeName == "CenterBack")
            {
                player = new CenterBack(name);
            }
            else if (typeName == "ForwardWing")
            {
                player = new ForwardWing(name);
            }
            else
            {
                return $"{typeName} is invalid position for the application.";
            }

            players.AddModel(player);
            return $"{name} is filed for the handball league.";
        }

        public string NewContract(string playerName, string teamName)
        {
            IPlayer player = players.GetModel(playerName);

            if (player == null)
            {
                return $"Player with the name {playerName} does not exist in the {nameof(PlayerRepository)}.";
            }

            ITeam team = teams.GetModel(teamName);

            if (team == null)
            {
                return $"Team with the name {teamName} does not exist in the {nameof(TeamRepository)}.";
            }

            if (player.Team != null)
            {
                return $"Player {playerName} has already signed with {player.Team}.";
            }

            player.JoinTeam(teamName);
            team.SignContract(player);

            return $"Player {playerName} signed a contract with {teamName}.";
        }

        public string NewGame(string firstTeamName, string secondTeamName)
        {
            ITeam firstTeam = teams.GetModel(firstTeamName);
            ITeam secondTeam = teams.GetModel(secondTeamName);

            if (firstTeam.OverallRating > secondTeam.OverallRating)
            {
                firstTeam.Win();
                secondTeam.Lose();

                return $"Team {firstTeam.Name} wins the game over {secondTeam.Name}!";
            }
            else if (firstTeam.OverallRating < secondTeam.OverallRating)
            {
                secondTeam.Win();
                firstTeam.Lose();

                return $"Team {secondTeam.Name} wins the game over {firstTeam.Name}!";
            }
            else  //Draw
            {
                firstTeam.Draw();
                secondTeam.Draw();

                return $"The game between {firstTeam.Name} and {secondTeam.Name} ends in a draw!";
            }
        }

        public string PlayerStatistics(string teamName)
        {
            ITeam team = teams.GetModel(teamName);

            List<IPlayer> orderedPlayers = team.Players.OrderByDescending(p => p.Rating).ThenBy(p => p.Name).ToList();  

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"***{teamName}***");

            foreach (var player in orderedPlayers)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().Trim();
        }

        public string LeagueStandings()
        {
            List<ITeam> orderedTeams = teams.Models
                .OrderByDescending(t => t.PointsEarned)
                .ThenByDescending(t => t.OverallRating)
                .ThenBy(t => t.Name)
                .ToList();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"***League Standings***");

            foreach (var team in orderedTeams)
            {
                sb.AppendLine(team.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
