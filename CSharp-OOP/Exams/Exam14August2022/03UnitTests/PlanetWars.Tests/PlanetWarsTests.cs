using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [Test]
            public void Test_ConstructorsShouldWorkCorrectly()
            {
                Weapon weapon = new Weapon("AK-47", 1500, 500);

                Assert.True(weapon.Name == "AK-47" && weapon.Price == 1500 && weapon.DestructionLevel == 500);
                Assert.Throws<ArgumentException>(() =>
                {
                    weapon = new Weapon("AK-47", -5, 500);
                });
                weapon.IncreaseDestructionLevel();
                Assert.True(weapon.DestructionLevel == 501);
                Assert.True(weapon.IsNuclear == true);

                Planet planet = new Planet("Mars", 50000);

                Assert.True(planet.Name == "Mars" && planet.Budget == 50000);
                Assert.Throws<ArgumentException>(() =>
                {
                    planet = new Planet("", 50000);
                });

                Assert.Throws<ArgumentException>(() =>
                {
                    planet = new Planet("M", -5);
                });
            }

            [Test]
            public void Test_AddWeaponShouldWorkCorrectly()
            {
                Weapon weapon1 = new Weapon("AK-47", 1500, 500);
                Weapon weapon2 = new Weapon("Makarov", 1000, 5);
                Weapon weapon3 = new Weapon("Knife", 200, 3);

                Planet planet = new Planet("Mars", 50000);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);
                planet.AddWeapon(weapon3);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.AddWeapon(weapon1);
                });

                IReadOnlyCollection<Weapon> expectedWeaponList = new List<Weapon>() { weapon1, weapon2, weapon3 };

                Assert.AreEqual(expectedWeaponList, planet.Weapons);
            }

            [Test]
            public void Test_RemoveWeaponShouldWorkCorrectly()
            {
                Weapon weapon1 = new Weapon("AK-47", 1500, 500);
                Weapon weapon2 = new Weapon("Makarov", 1000, 5);
                Weapon weapon3 = new Weapon("Knife", 200, 3);

                Planet planet = new Planet("Mars", 50000);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);
                planet.AddWeapon(weapon3);

                planet.RemoveWeapon(weapon1.Name);
                Assert.AreEqual(2, planet.Weapons.Count);
                Assert.True(planet.Weapons.FirstOrDefault(x => x.Name == weapon2.Name) != null);
                Assert.True(planet.Weapons.FirstOrDefault(x => x.Name == weapon3.Name) != null);
            }

            [Test]
            public void Test_MilitaryPowerRatioShouldWorkCorrectly()
            {
                Weapon weapon1 = new Weapon("AK-47", 1500, 500);
                Weapon weapon2 = new Weapon("Makarov", 1000, 5);
                Weapon weapon3 = new Weapon("Knife", 200, 3);

                Planet planet = new Planet("Mars", 50000);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);
                planet.AddWeapon(weapon3);

                Assert.True(planet.MilitaryPowerRatio == 508);
            }

            [Test]
            public void Test_ProfitShouldWorkCorrectly()
            {
                Weapon weapon1 = new Weapon("AK-47", 1500, 500);
                Weapon weapon2 = new Weapon("Makarov", 1000, 5);
                Weapon weapon3 = new Weapon("Knife", 200, 3);

                Planet planet = new Planet("Mars", 50000);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);
                planet.AddWeapon(weapon3);

                planet.Profit(500);
                Assert.True(planet.Budget == 50500);
                planet.SpendFunds(500);
                Assert.True(planet.Budget == 50000);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.SpendFunds(60000);
                });
            }

            [Test]
            public void Test_UpgradeWeaponShouldWorkCorrectly()
            {
                Weapon weapon1 = new Weapon("AK-47", 1500, 500);
                Weapon weapon2 = new Weapon("Makarov", 1000, 5);
                Weapon weapon3 = new Weapon("Knife", 200, 3);

                Planet planet = new Planet("Mars", 50000);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);
                planet.AddWeapon(weapon3);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.UpgradeWeapon("notExistingWeapon");
                });

                planet.UpgradeWeapon(weapon3.Name);
                Assert.True(planet.Weapons.FirstOrDefault(x => x.Name == weapon3.Name).DestructionLevel == 4);
            }

            [Test]
            public void Test_DestructOpponentShouldWorkCorrectly()
            {
                Weapon weapon1 = new Weapon("AK-47", 1500, 500);
                Weapon weapon2 = new Weapon("Makarov", 1000, 5);
                Weapon weapon3 = new Weapon("Knife", 200, 3);
                Weapon weapon4 = new Weapon("TopDestroyer", 200, 600);

                Planet planet = new Planet("Mars", 50000);

                Planet planeOpponent = new Planet("Enemy", 20000);

                Planet strongPlanet = new Planet("Unbeatable", 50000);

                planeOpponent.AddWeapon(weapon2);
                planeOpponent.AddWeapon(weapon3);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);
                planet.AddWeapon(weapon3);

                string expectedResult = $"Enemy is destructed!";

                Assert.AreEqual(expectedResult, planet.DestructOpponent(planeOpponent));

                strongPlanet.AddWeapon(weapon1);
                strongPlanet.AddWeapon(weapon2);
                strongPlanet.AddWeapon(weapon3);
                strongPlanet.AddWeapon(weapon4);

                string tooStrongExpectedResult = $"Unbeatable is too strong to declare war to!";

                var exception = Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.DestructOpponent(strongPlanet);
                });

                Assert.AreEqual(tooStrongExpectedResult, exception.Message);
            }
        }
    }
}
