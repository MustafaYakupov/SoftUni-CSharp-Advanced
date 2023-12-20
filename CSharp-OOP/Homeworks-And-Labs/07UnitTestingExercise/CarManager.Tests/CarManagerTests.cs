namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;

        [SetUp]
        public void SetUp()
        {
            car = new Car("Mercedes", "Cl", 25.00, 100);
        }

        [Test]
        public void Test_ConstructorShouldNotBeNull()
        {
            Assert.IsNotNull(car);
        }

        [Test]
        public void Test_ConstructorShouldWorkProperly()
        {
            Assert.True(car.Make == "Mercedes" 
                && car.Model == "Cl" 
                && car.FuelConsumption == 25.00 
                && car.FuelCapacity == 100 
                && car.FuelAmount == 0);
        }

        [Test]
        public void Test_MakeGetterShouldWorkCorrectly()
        {
            string make = "Mercedes";

            Assert.AreEqual(make, car.Make);
        }

        [Test]
        public void Test_FuelConsumptionGetterShouldWorkCorrectly()
        {
            double consumption = 25.00;

            Assert.AreEqual(consumption, car.FuelConsumption);
        }

        [Test]
        public void Test_FuelAmountGetterShouldWorkCorrectly()
        {
            double amount = 0;

            Assert.AreEqual(amount, car.FuelAmount);
        }

        [Test]
        public void Test_FuelCapacityGetterShouldWorkCorrectly()
        {
            double capacity = 100.00;

            Assert.AreEqual(capacity, car.FuelCapacity);
        }

        [Test]
        public void Test_MakeSetterShouldNotAcceptNullParameter()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car("", "Cl", 25.00, 100);
            });
        }

        [Test]
        public void Test_ModelSetterShouldNotAcceptNullParameter()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car("Mercedes", "", 25.00, 100);
            });
        }

        [Test]
        public void Test_FuelConsumptionSetterShouldNotAcceptZeroParameter()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car("Mercedes", "Cl", 0, 100);
            });
        }

        [Test]
        public void Test_FuelConsumptionSetterShouldNotAcceptNegativeParameter()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car("Mercedes", "Cl", -1, 100);
            });
        }

        [Test]
        public void Test_FuelAmountSetterShouldNotAcceptNegativeParameter()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car("Mercedes", "Cl", 25.00, -1);
            });
        }

        [Test]
        public void Test_RefuelMethodShouldNotAcceptZeroParameter()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(0);
            });
        }

        [Test]
        public void Test_RefuelMethodShouldNotAcceptNegativeParameter()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(-5);
            });
        }

        [Test]
        public void Test_RefuelMethodAddingFuelCorrectly()
        {
            int refuelingAmount = 20;
            car.Refuel(refuelingAmount);

            Assert.AreEqual(refuelingAmount, car.FuelAmount);
        }

        [Test]
        public void Test_RefuelMethodWhenFuelAmountIsMoreThanFuelCapacity()
        {
            int refuelingAmount = 150;
            car.Refuel(refuelingAmount);

            Assert.AreEqual(car.FuelCapacity, car.FuelAmount);
        }

        [Test]
        public void Test_DriveMethodCalculatingFuelNeededShouldWorkCorrectly()
        {
            int refuelingAmount = 25;
            car.Refuel(refuelingAmount);
            double distance = 50;
            car.Drive(distance);
            double expectedFuelLeft = 12.5;

            Assert.AreEqual(expectedFuelLeft, car.FuelAmount);
        }

        [Test]
        public void Test_DriveMethodWhenFuelIsNotEnoughShouldNotWork()
        {
            int refuelingAmount = 25;
            car.Refuel(refuelingAmount);
            double distance = 150;

            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(distance);
            });
        }
    }
}