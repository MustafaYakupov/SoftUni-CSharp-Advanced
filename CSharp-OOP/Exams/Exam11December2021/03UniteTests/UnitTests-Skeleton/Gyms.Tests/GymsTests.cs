using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    public class GymsTests
    {
        [Test]
        public void Test_ConstructorShouldWork()
        {
            Gym gym = new Gym("Golden", 500);

            Assert.AreEqual("Golden", gym.Name);
            Assert.AreEqual(500, gym.Capacity);
            Assert.AreEqual(0, gym.Count);
        }

        [Test]
        public void Test_InvalidNameShouldThrow()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym gym = new Gym("", 500);
            });
        }

        [Test]
        public void Test_InvalidCapacityShouldThrow()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Gym gym = new Gym("Name", -5);
            });
        }

        [Test]
        public void Test_AddAthleteShouldWork()
        {
            Gym gym = new Gym("Golden", 500);

            Athlete athlete = new Athlete("Ivan");

            Assert.AreEqual("Ivan", athlete.FullName);

            gym.AddAthlete(athlete);

            Assert.AreEqual(1, gym.Count);
        }

        [Test]
        public void Test_AddAthleteShouldThrowWhenFull()
        {
            Gym gym = new Gym("Golden", 1);

            Athlete athlete = new Athlete("Ivan");
            Athlete athlete2 = new Athlete("Pesho");

            gym.AddAthlete(athlete);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.AddAthlete(athlete2);
            });
        }

        [Test]
        public void Test_RemoveAthleteShouldWork()
        {
            Gym gym = new Gym("Golden", 500);

            Athlete athlete = new Athlete("Ivan");
            Athlete athlete2 = new Athlete("Pesho");

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            gym.RemoveAthlete("Ivan");

            Assert.AreEqual(1, gym.Count);
        }

        [Test]
        public void Test_RemoveAthleteShouldThrow_WhenAthleteDoesNotExist()
        {
            Gym gym = new Gym("Golden", 500);

            Athlete athlete = new Athlete("Ivan");
            Athlete athlete2 = new Athlete("Pesho");

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.RemoveAthlete("Chocho");
            });
        }

        [Test]
        public void Test_InjureAthleteShouldWork()
        {
            Gym gym = new Gym("Golden", 500);

            Athlete athlete = new Athlete("Ivan");
            Athlete athlete2 = new Athlete("Pesho");

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            gym.InjureAthlete("Ivan");

            Assert.AreEqual(true, athlete.IsInjured);

            Assert.AreEqual(athlete2, gym.InjureAthlete("Pesho"));
        }

        [Test]
        public void Test_InjureAthleteShouldThrowWhenAthleteDoesNotExist()
        {
            Gym gym = new Gym("Golden", 500);

            Athlete athlete = new Athlete("Ivan");
            Athlete athlete2 = new Athlete("Pesho");

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.InjureAthlete("Chocho");
            });
        }

        [Test]
        public void Test_ReportShouldWork()
        {
            Gym gym = new Gym("Golden", 500);

            Athlete athlete = new Athlete("Ivan");
            Athlete athlete2 = new Athlete("Pesho");

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            string expectedResult = "Active athletes at Golden: Ivan, Pesho";

            Assert.AreEqual(expectedResult, gym.Report());
        }
    }
}
