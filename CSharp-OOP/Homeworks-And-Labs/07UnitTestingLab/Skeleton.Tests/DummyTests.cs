using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Dummy dummy;
        private int health;
        private int experience;

        [SetUp]
        public void SetUp()
        {
            health = 10;
            experience = 15;
            dummy = new Dummy(health, experience);
        }

        [Test]
        public void Test_DummyConstructorShouldSetDataCorrectly()
        {
            Assert.AreEqual(health, dummy.Health);
        }

        [Test]
        public void Test_DummyShouldLooseHealthIfAttacked()
        {
            dummy.TakeAttack(5);

            Assert.AreEqual(health - 5, dummy.Health);
        }

        [Test]
        public void Test_DeadDummyShouldThrowExceptionIfAttacked()
        {
            dummy = new Dummy(0, 10);

            Assert.Throws<InvalidOperationException>(() => { dummy.TakeAttack(5); });
        }

        [Test]
        public void Test_DeadDummyShouldGiveExperience()
        {
            experience = 15;

            dummy = new Dummy(0, experience);

            Assert.AreEqual(experience, dummy.GiveExperience());
        }

        [Test]
        public void Test_AliveDummyShouldNotGiveExperience()
        {
            Assert.Throws<InvalidOperationException>(() => { dummy.GiveExperience(); });
        }
    }
}