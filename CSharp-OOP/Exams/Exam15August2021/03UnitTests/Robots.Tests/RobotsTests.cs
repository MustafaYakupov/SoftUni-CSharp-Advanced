namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    public class RobotsTests
    {
        [Test]
        public void Test_ConstructorShouldWork()
        {
            Robot robot = new Robot("Jo", 5000);

            Assert.AreEqual("Jo", robot.Name);
            Assert.AreEqual(5000, robot.MaximumBattery);
            Assert.AreEqual(5000, robot.Battery);

            RobotManager manager = new RobotManager(3);

            Assert.AreEqual(3, manager.Capacity);
            Assert.AreEqual(0, manager.Count);
        }

        [Test]
        public void Test_ConstructorShouldThrowWhenCapacityNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                RobotManager manager = new RobotManager(-5);
            });
        }

        [Test]
        public void Test_AddShouldWork()
        {
            Robot robot = new Robot("Jo", 5000);

            RobotManager manager = new RobotManager(3);

            manager.Add(robot);

            Assert.AreEqual(1, manager.Count);
        }

        [Test]
        public void Test_AddShouldThrowWhenRobotExists()
        {
            Robot robot = new Robot("Jo", 5000);

            RobotManager manager = new RobotManager(3);

            manager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Add(robot);
            });
        }

        [Test]
        public void Test_AddShouldThrowWhenNoCapacity()
        {
            Robot robot = new Robot("Jo", 5000);
            Robot robot2 = new Robot("Jo2", 5000);

            RobotManager manager = new RobotManager(1);

            manager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Add(robot2);
            });
        }

        [Test]
        public void Test_RemoveShouldWork()
        {
            Robot robot = new Robot("Jo", 5000);

            RobotManager manager = new RobotManager(3);

            manager.Add(robot);
            manager.Remove(robot.Name);

            Assert.AreEqual(0, manager.Count);
        }

        [Test]
        public void Test_RemoveShouldThrowWhenRobotIsNull()
        {
            Robot robot = new Robot("Jo", 5000);

            RobotManager manager = new RobotManager(3);

            manager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Remove("Non existing robot");
            });
        }

        [Test]
        public void Test_WorkShouldWork()
        {
            Robot robot = new Robot("Jo", 5000);

            RobotManager manager = new RobotManager(3);

            manager.Add(robot);

            manager.Work(robot.Name, "run", 3000);

            Assert.AreEqual(2000, robot.Battery);
        }

        [Test]
        public void Test_WorkShouldThrowWhenRobotDoesNotExist()
        {
            Robot robot = new Robot("Jo", 5000);

            RobotManager manager = new RobotManager(3);

            manager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Work("Nonexistant", "run", 3000);
            });
        }

        [Test]
        public void Test_WorkShouldThrowWhenNoBattery()
        {
            Robot robot = new Robot("Jo", 5000);

            RobotManager manager = new RobotManager(3);

            manager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Work(robot.Name, "run", 6000);
            });
        }

        [Test]
        public void Test_ChargeShouldWork()
        {
            Robot robot = new Robot("Jo", 5000);

            RobotManager manager = new RobotManager(3);

            manager.Add(robot);

            manager.Work(robot.Name, "run", 3000);
            manager.Charge(robot.Name);

            Assert.AreEqual(5000, robot.Battery);
        }

        [Test]
        public void Test_ChargeShouldThrowWhenRobotDoesNotExist()
        {
            Robot robot = new Robot("Jo", 5000);

            RobotManager manager = new RobotManager(3);

            manager.Add(robot);

            manager.Work(robot.Name, "run", 3000);

            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Charge("Nonexistant");
            });
        }
    }
}
