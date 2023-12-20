using NUnit.Framework;
using System.Linq;

namespace RobotFactory.Tests
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
            Factory factory = new Factory("HeavyMachinery", 5);
            Robot robot = new Robot("Fighter", 100000, 10);
            Supplement supplement = new Supplement("Sup", 10);

            robot.Supplements.Add(supplement);

            Assert.AreEqual("HeavyMachinery", factory.Name);
            Assert.AreEqual(5, factory.Capacity);

            Assert.AreEqual("Fighter", robot.Model);
            Assert.AreEqual(100000, robot.Price);
            Assert.AreEqual(10, robot.InterfaceStandard);

            Assert.AreEqual(10, supplement.InterfaceStandard);
            Assert.AreEqual("Sup", supplement.Name);

            Assert.AreEqual(true, robot.Supplements.Contains(supplement));
            Assert.AreEqual(1, robot.Supplements.Count);
        }

        [Test]
        public void Test_ProduceRobotMethodShouldWorkCorrectly()
        {
            Factory factory = new Factory("HeavyMachinery", 5);
            Robot robot = new Robot("Fighter", 100000, 10);
            Supplement supplement = new Supplement("Sup", 10);

            string expectedRobotAddedMessage = $"Produced --> {robot}";
            string expectedNoCapacityMessage = "The factory is unable to produce more robots for this production day!";

            Assert.AreEqual(expectedRobotAddedMessage, factory.ProduceRobot("Fighter", 100000, 10));

            factory.ProduceRobot("Fighter", 50, 60);
            factory.ProduceRobot("Fighter", 60, 70);
            factory.ProduceRobot("Fighter", 70, 80);
            factory.ProduceRobot("Fighter", 90, 95);

            Assert.AreEqual(expectedNoCapacityMessage, factory.ProduceRobot("Fighter", 5, 10));
            Assert.AreEqual(5, factory.Robots.Count);

            Assert.True(factory.Robots[0].Model == "Fighter");
            Assert.True(factory.Robots[0].InterfaceStandard == 10);
            Assert.True(factory.Robots[0].Price == 100000);
        }

        [Test]
        public void Test_ProduceSupplementMethodShouldWorkCorrectly()
        {
            Factory factory = new Factory("HeavyMachinery", 5);
            Robot robot = new Robot("Fighter", 100000, 10);
            Supplement supplement = new Supplement("Sup", 10);

            string expectedRobotAddedMessage = $"{supplement}";
            Assert.AreEqual(expectedRobotAddedMessage, factory.ProduceSupplement("Sup", 10));
            Assert.AreEqual(1, factory.Supplements.Count);
            Assert.True(factory.Supplements[0].Name == "Sup");
            Assert.True(factory.Supplements[0].InterfaceStandard == 10);
        }

        [Test]
        public void Test_UpgradeRobotMethodShouldWorkCorrectly()
        {
            Factory factory = new Factory("HeavyMachinery", 5);
            Robot robot = new Robot("Fighter", 100000, 10);
            Supplement supplement = new Supplement("Sup", 10);
            Supplement supplement2 = new Supplement("Sup", 5);

            factory.ProduceRobot("Fighter", 100000, 10);
            factory.ProduceSupplement("Sup", 10);

            Assert.AreEqual(false, factory.UpgradeRobot(factory.Robots[0], supplement2));
            Assert.AreEqual(true, factory.UpgradeRobot(factory.Robots[0], factory.Supplements[0]));
            Assert.AreEqual(false, factory.UpgradeRobot(factory.Robots[0], factory.Supplements[0]));
        }

        [Test]
        public void Test_SellRobotMethodShouldWorkCorrectly()
        {
            Factory factory = new Factory("HeavyMachinery", 5);
            Robot robot = new Robot("Fighter", 50, 60);
            Robot robot2 = new Robot("Fighter", 60, 70);

            factory.ProduceRobot("Fighter", 50, 60);
            factory.ProduceRobot("Fighter", 60, 70);
            factory.ProduceRobot("Fighter", 70, 80);
            factory.ProduceRobot("Fighter", 90, 95);

            var outputRobot = factory.Robots.FirstOrDefault( r => r.Price == 50);
            var robotSold = factory.SellRobot(55);

            Assert.True(outputRobot == robotSold);
        }
    }
}