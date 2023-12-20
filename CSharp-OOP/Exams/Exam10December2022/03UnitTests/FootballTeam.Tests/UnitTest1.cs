using NUnit.Framework;
using System;
using System.Linq;

namespace FootballTeam.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_ConstructorShouldWorkCorrectly()
        {
            FootballPlayer player1 = new FootballPlayer("Pesho", 5, "Goalkeeper");
            player1.Score();
            FootballPlayer player2 = new FootballPlayer("Gosho", 6, "Midfielder");
            FootballPlayer player3 = new FootballPlayer("Tosho", 11, "Forward");

            Assert.True(player1.Name == "Pesho" && player1.Position == "Goalkeeper" && player1.PlayerNumber == 5 && player1.ScoredGoals == 1);

            FootballTeam team = new FootballTeam("Spartak", 15);

            Assert.True(team.Name == "Spartak" && team.Capacity == 15);

            team.AddNewPlayer(player1);
            team.AddNewPlayer(player2);
            team.AddNewPlayer(player3);

            Assert.AreEqual(3, team.Players.Count);

           var exceptionInvalidName =  Assert.Throws<ArgumentException>(() =>
            {
                FootballTeam team2 = new FootballTeam("", 15);
            });

            Assert.AreEqual("Name cannot be null or empty!", exceptionInvalidName.Message);

            var exceptionInvalidCapacity = Assert.Throws<ArgumentException>(() =>
            {
                FootballTeam team2 = new FootballTeam("name", 10);
            });

            Assert.AreEqual("Capacity min value = 15", exceptionInvalidCapacity.Message);

            Assert.AreEqual(3, team.Players.Count);

            var players = team.Players;

            Assert.AreEqual("Pesho", team.Players[0].Name);
            Assert.AreEqual(5, team.Players[0].PlayerNumber);
            Assert.AreEqual("Goalkeeper", team.Players[0].Position);

        }

        [Test]
        public void Test_AddNewPlayerShouldWorkCorrectly()
        {
            FootballPlayer player1 = new FootballPlayer("Pesho", 5, "Goalkeeper");
            player1.Score();
            FootballPlayer player2 = new FootballPlayer("Gosho", 6, "Midfielder");
            FootballPlayer player3 = new FootballPlayer("Tosho", 11, "Forward");

            FootballTeam team = new FootballTeam("Spartak", 15);

            string resultForAddingPlayer = $"Added player Pesho in position Goalkeeper with number 5";

            Assert.AreEqual(resultForAddingPlayer, team.AddNewPlayer(player1));

            for (int i = 0; i < 14; i++)
            {
                team.AddNewPlayer(player1);

            }

            Assert.AreEqual("No more positions available!", team.AddNewPlayer(player3));
        }

        [Test]
        public void Test_PickPlayerShouldWorkCorrectly()
        {
            FootballPlayer player1 = new FootballPlayer("Pesho", 5, "Goalkeeper");
            player1.Score();
            FootballPlayer player2 = new FootballPlayer("Gosho", 6, "Midfielder");
            FootballPlayer player3 = new FootballPlayer("Tosho", 11, "Forward");

            FootballTeam team = new FootballTeam("Spartak", 15);

            team.AddNewPlayer(player1);
            team.AddNewPlayer(player2);
            team.AddNewPlayer(player3);

            FootballPlayer resultPlayer = team.Players.FirstOrDefault(p => p.Name == "Gosho");

            Assert.AreEqual(resultPlayer, team.PickPlayer("Gosho"));
        }

        [Test]
        public void Test_PlayerScoreShouldWorkCorrectly()
        {
            FootballPlayer player1 = new FootballPlayer("Pesho", 5, "Goalkeeper");
            player1.Score();
            FootballPlayer player2 = new FootballPlayer("Gosho", 6, "Midfielder");
            FootballPlayer player3 = new FootballPlayer("Tosho", 11, "Forward");

            FootballTeam team = new FootballTeam("Spartak", 15);

            team.AddNewPlayer(player1);
            team.AddNewPlayer(player2);
            team.AddNewPlayer(player3);

            string expectedResultScored = "Pesho scored and now has 2 for this season!";

            Assert.AreEqual(expectedResultScored, team.PlayerScore(5));
        }
    }
}