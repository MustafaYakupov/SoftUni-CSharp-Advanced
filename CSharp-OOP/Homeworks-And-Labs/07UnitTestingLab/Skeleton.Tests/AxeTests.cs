using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;
        private int atackPoints;
        private int durabilityPoints;
        private int health;
        private int experience;

        [SetUp]
        public void SetUp()
        {
            atackPoints = 10;
            durabilityPoints = 15;
            axe = new Axe(atackPoints, durabilityPoints);

            health = 100;
            experience = 10;
            dummy = new Dummy(health, experience);
        }

        [Test]
        public void Test_AxeConstructorShouldSetDataProperly()
        {
            Assert.AreEqual(atackPoints, axe.AttackPoints);
            Assert.AreEqual(durabilityPoints, axe.DurabilityPoints);
        }

        [Test]
        public void Test_AxeShouldLooseDurabilityPointsAfterEachAttack()
        {
            for (int i = 0; i < 5; i++)
            {
                axe.Attack(dummy);
            }

            Assert.AreEqual(durabilityPoints - 5, axe.DurabilityPoints, "Axe Durability doesn't change after attack.");
        }

        [Test]
        public void Test_AxeShouldThrowExceptionWhenDurabilityPointsAreZero()
        {
            axe = new Axe(10, 0);

            Assert.Throws<InvalidOperationException>((() =>
            {
                axe.Attack(dummy);
            }
            ));
        }

        [Test]
        public void Test_AxeShouldThrowExceptionWhenDurabilityPointsAreBelowZero()
        {
            axe = new Axe(10, -5);

            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
            }
            );
        }
    }
}