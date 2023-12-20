using NUnit.Framework;
using System.Linq;

namespace VehicleGarage.Tests
{
    public class Tests
    {
        private Vehicle vehicle;
        private Garage garage;

        [SetUp]
        public void Setup()
        {
            vehicle = new Vehicle("BMW", "328XI", "E97");
            garage = new Garage(5);
        }

        [Test]
        public void Test_ConstructorShouldWorkCorrectly()
        {
            garage.AddVehicle(vehicle);
            Assert.AreEqual("BMW", vehicle.Brand);
            Assert.AreEqual("328XI", vehicle.Model);
            Assert.AreEqual("E97", vehicle.LicensePlateNumber);
            Assert.AreEqual(false, vehicle.IsDamaged);
            Assert.AreEqual(100, vehicle.BatteryLevel);
            Assert.AreEqual(5, garage.Capacity);
            Assert.AreEqual(1, garage.Vehicles.Count);
        }

        [Test]
        public void Test_VehicleProperty()
        {
            for (int i = 0; i < 5; i++)
            {
                 vehicle = new Vehicle("BMW", "328XI", $"E97{i}");
                garage.AddVehicle(vehicle);
            }

            Assert.AreEqual(5, garage.Vehicles.Count);
            
        }

        [Test]
        public void Test_AddVehicleMethod()
        {
            for (int i = 0; i < 4; i++)
            {
                vehicle = new Vehicle("BMW", "328XI", $"E97{i}");
                garage.AddVehicle(vehicle);
            }

            Vehicle existingVehicle = new Vehicle("BMW", "328XI", $"E970");
            vehicle = new Vehicle("BMW", "328XI", $"E9");

            Assert.AreEqual(false, garage.AddVehicle(existingVehicle));

            Assert.AreEqual(true, garage.AddVehicle(vehicle));

            Vehicle anotherOne = new Vehicle("BMW", "328XI", $"5");

            Assert.AreEqual(false, garage.AddVehicle(anotherOne));
        }

        [Test]
        public void Test_ChargeVehiclesAndDriveVehicleMethods()
        {
            for (int i = 0; i < 4; i++)
            {
                vehicle = new Vehicle("BMW", "328XI", $"E97{i}");
                garage.AddVehicle(vehicle);
            }

            garage.DriveVehicle("E970", 50, false);
            Vehicle currentVehicle = garage.Vehicles.First(x => x.LicensePlateNumber == "E970");

            Assert.AreEqual(50, currentVehicle.BatteryLevel);

            garage.DriveVehicle("E970", 60, false);

            Assert.AreEqual(50, currentVehicle.BatteryLevel);


            currentVehicle = garage.Vehicles.First(x => x.LicensePlateNumber == "E971");
            garage.DriveVehicle("E971", 150, false);
            Assert.AreEqual(100, currentVehicle.BatteryLevel);

            garage.DriveVehicle("E971", 60, true);
            garage.DriveVehicle("E971", 60, true);

            Assert.AreEqual(true, currentVehicle.IsDamaged);
            Assert.AreEqual(40, currentVehicle.BatteryLevel);

            Assert.AreEqual(4, garage.ChargeVehicles(100));

            foreach (var car in garage.Vehicles)
            {
                Assert.AreEqual(100, car.BatteryLevel);
            }
        }

        [Test]
        public void Test_RepairVehiclesMethod()
        {
            Vehicle car1 = new Vehicle("BMW", "328XI", $"E970");
            Vehicle car2 = new Vehicle("BMW", "328XI", $"E971");
            Vehicle car3 = new Vehicle("BMW", "328XI", $"E972");
            Vehicle car4 = new Vehicle("BMW", "328XI", $"E973");

            garage.AddVehicle(car1);
            garage.AddVehicle(car2);
            garage.AddVehicle(car3);
            garage.AddVehicle(car4);

            garage.DriveVehicle("E971", 60, true);
            garage.DriveVehicle("E972", 60, true);

            Assert.IsTrue(car2.IsDamaged);
            Assert.IsTrue(car3.IsDamaged);

            string returnMessage = "Vehicles repaired: 2";

            Assert.True(returnMessage == garage.RepairVehicles());
            Assert.IsFalse(car1.IsDamaged);
            Assert.IsFalse(car2.IsDamaged);
            Assert.IsFalse(car3.IsDamaged);
            Assert.IsFalse(car4.IsDamaged);
        }
    }
}