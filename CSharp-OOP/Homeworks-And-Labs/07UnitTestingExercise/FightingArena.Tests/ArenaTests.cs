namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warrior;

        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
            warrior = new Warrior("Predator", 50, 50);
        }

        [Test]
        public void Test_ArenaConstructorShouldWorkCorrectly()
        {
            Assert.IsNotNull(arena);
            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void Test_ArenaWarriorListGetterShouldWorkCorrectly()
        {
            arena.Enroll(warrior);
            int expectedWarriorCount = 1;

            Assert.AreEqual(expectedWarriorCount, arena.Warriors.Count);
        }

        [Test]
        public void Test_EnrollMethodShouldWorkCorrectly()
        {
            arena.Enroll(warrior);

            Assert.AreEqual(warrior, arena.Warriors.Single());
        }

        [Test]
        public void Test_EnrollMethodShouldThrowExceptionWhenNameExists()
        {
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => 
            {
                arena.Enroll(warrior);
            });
        }

        [Test]
        public void Test_FightlMethodShouldWorkCorrectly()
        {
            Warrior attacker = new Warrior("Attacker", 30, 100);
            Warrior defender = new Warrior("Defender", 100, 60);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight(attacker.Name, defender.Name);

            Assert.AreEqual(30, defender.HP);
        }

        [Test]
        public void Test_FightlMethodShouldThrowExceptionWhenAttackerNameIsNull()
        {
            Warrior attacker = new Warrior("Attacker", 30, 100);
            Warrior defender = new Warrior("Defender", 100, 60);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            string missingName = "Gosho";
            string expectedMessage = $"There is no fighter with name {missingName} enrolled for the fights!";

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight(missingName, "Defender");
            });

            Assert.AreEqual(expectedMessage, ex.Message);
        }

        [Test]
        public void Test_FightlMethodShouldThrowExceptionWhenDefenderNameIsNull()
        {
            Warrior attacker = new Warrior("Attacker", 30, 100);
            Warrior defender = new Warrior("Defender", 100, 60);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            string missingName = "Gosho";
            string expectedMessage = $"There is no fighter with name {missingName} enrolled for the fights!";

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("Attacker", missingName);
            });

            Assert.AreEqual(expectedMessage, ex.Message);
        }
    }
}
