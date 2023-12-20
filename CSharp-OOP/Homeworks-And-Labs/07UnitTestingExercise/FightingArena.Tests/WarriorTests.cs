namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior warrior;

        [SetUp]
        public void SetUp()
        {
            warrior = new Warrior("Killer", 100, 50);
        }

        [Test]
        public void Test_WarriorConstructorShouldSetValuesCorrectly() // Testing getters here too
        {
            Assert.True(warrior.Name == "Killer" && warrior.Damage == 100 && warrior.HP == 50);
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase("    ")]
        public void Test_WarriorNameSetterShouldThrowExceptionWhenValueIsNull(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior(name, 100, 100);
            });
        }

        [TestCase(0)]
        [TestCase(-5)]
        public void Test_WarriorDamageSetterShouldThrowExceptionWhenValueIsZero(int damage)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior("Killer", damage, 100);
            });
        }

        [Test]
        public void Test_WarriorHPSetterShouldThrowExceptionWhenValueIsNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior("", 100, -5);
            });
        }

        [TestCase(30)]
        [TestCase(10)]
        public void Test_WarriorAttackMethodShouldThrowExceptionWhenAttackerHPIsEqualToMinAttack(int hp)
        {
            Warrior attacker = new Warrior("Killer", 100, hp);
            Warrior defender = new Warrior("Defender", 100, 90);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });

            Assert.AreEqual("Your HP is too low in order to attack other warriors!", ex.Message);
        }

        [TestCase(30)]
        [TestCase(10)]
        public void Test_WarriorAttackMethodShouldThrowExceptionWhenEnemyHPIsEqualToOrLessThanMinAttack(int hp)
        {
            Warrior attacker = new Warrior("Killer", 100, 100);
            Warrior defender = new Warrior("Defender", 100, hp);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });

            Assert.AreEqual($"Enemy HP must be greater than {30} in order to attack him!", ex.Message);
        }

        [Test]
        public void Test_WarriorAttackMethodShouldThrowExceptionWhenAttackerHPIsLessThanEnemyHP()
        {
            Warrior attacker = new Warrior("Killer", 100, 50);
            Warrior defender = new Warrior("Defender", 100, 100);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });

            Assert.AreEqual("You are trying to attack too strong enemy", ex.Message);
        }

        [Test]
        public void Test_WarriorAttackMethodShouldDeductDamageFromHPCorrectly()
        {
            int expectedAtackerHp = 95;
            int expectedDefendererHp = 80;

            Warrior attacker = new Warrior("Killer", 10, 100);
            Warrior defender = new Warrior("Defender", 5, 90);

            attacker.Attack(defender);

            Assert.AreEqual(expectedAtackerHp, attacker.HP);
            Assert.AreEqual(expectedDefendererHp, defender.HP);
        }

        [Test]
        public void Test_WarriorAttackMethodShouldSetEnemyHPToZeroWhenAttackerDamageIsBigger()
        {
            Warrior attacker = new Warrior("Killer", 100, 50);
            Warrior defender = new Warrior("Defender", 30, 60);

            attacker.Attack(defender);

            Assert.AreEqual(0, defender.HP);
            Assert.AreEqual(20, attacker.HP);
        }

        [Test]
        public void Test_WarriorAttackMethodShouldDeductEnemyHPWithAttackerDamage()
        {
            Warrior attacker = new Warrior("Killer", 30, 100);
            Warrior defender = new Warrior("Defender", 100, 60);

            attacker.Attack(defender);

            Assert.AreEqual(30, defender.HP);
        }
    }
}