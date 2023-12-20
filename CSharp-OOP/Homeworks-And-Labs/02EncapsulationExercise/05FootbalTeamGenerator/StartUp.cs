using _05FootbalTeamGenerator.Models;

namespace _05FootbalTeamGenerator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Team> teams = new();
            
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();

                    if (input == "END")
                    {
                        break;
                    }

                    string[] tokens = input.Split(';').ToArray();
                    string teamName = tokens[1];

                    if (tokens[0].ToLower() == "team")
                    {
                        Team team = new Team(teamName);
                        teams.Add(team);
                    }
                    else if (tokens[0].ToLower() == "add")
                    {
                        string playerName = tokens[2];
                        int endurance = int.Parse(tokens[3]);
                        int sprint = int.Parse(tokens[4]);
                        int dribble = int.Parse(tokens[5]);
                        int passing = int.Parse(tokens[6]);
                        int shooting = int.Parse(tokens[7]);

                        Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

                        Team team = teams.FirstOrDefault(t => t.Name == teamName);

                        if (team == null)
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");

                            return;
                        }

                        team.AddPlayer(teamName, player);
                    }
                    else if (tokens[0].ToLower() == "remove")
                    {
                        Team team = teams.FirstOrDefault(t => t.Name == teamName);
                        string playerName = tokens[2];


                        if (team == null)
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");

                            return;
                        }

                        team.RemovePlayer(teamName, playerName);

                    }
                    else if (tokens[0].ToLower() == "rating")
                    {
                        Team team = teams.FirstOrDefault(t => t.Name == teamName);

                        if (team == null)
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");

                            return;
                        }

                        Console.WriteLine($"{teamName} - {team.GetRating:f0}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}