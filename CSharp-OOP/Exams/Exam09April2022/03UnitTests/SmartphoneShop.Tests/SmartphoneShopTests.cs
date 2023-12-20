using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [Test]
        public void Test_CapacityShouldWorkCorrectly()
        {
            Shop shop = new Shop(5);
            Assert.AreEqual(5, shop.Capacity);
            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void Test_NegativeCapacityShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Shop shop = new Shop(-5);
            }, "Invalid capacity.");
        }

        [Test]
        public void Test_AddMethodShouldWorkCorrectly()
        {
            Shop shop = new Shop(5);
            Smartphone phone = new Smartphone("Samsung", 5000);
            Smartphone phone2 = new Smartphone("Huawei", 4500);
            Smartphone phone3 = new Smartphone("IPhone", 4000);

            shop.Add(phone);
            shop.Add(phone2);
            Assert.True(shop.Count == 2);
        }

        [Test]
        public void Test_AddMethodShouldThrowExceptionWhenShopIsFull()
        {
            Shop shop = new Shop(2);
            Smartphone phone = new Smartphone("Samsung", 5000);
            Smartphone phone2 = new Smartphone("Huawei", 4500);
            Smartphone phone3 = new Smartphone("IPhone", 4000);

            shop.Add(phone);
            shop.Add(phone2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(phone3);
            }, "The shop is full.");
        }

        [Test]
        public void Test_AddMethodShouldThrowExceptionWhenPhoneExists()
        {
            Shop shop = new Shop(2);
            Smartphone phone = new Smartphone("Samsung", 5000);
            Smartphone phone2 = new Smartphone("Huawei", 4500);
            Smartphone phone3 = new Smartphone("IPhone", 4000);

            shop.Add(phone);
            shop.Add(phone2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(phone2);
            }, "The phone model Huawei already exist.");

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(new Smartphone("Samsung", 4000));
            }, "The phone model Huawei already exist.");
        }

        [Test]
        public void Test_RemoveMethodShouldThrowExceptionWhenPhoneDoesNotExist()
        {
            Shop shop = new Shop(2);
            Smartphone phone = new Smartphone("Samsung", 5000);
            Smartphone phone2 = new Smartphone("Huawei", 4500);
            Smartphone phone3 = new Smartphone("IPhone", 4000);

            shop.Add(phone);
            shop.Add(phone2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Remove("IPhone");
            }, "The phone model IPhone doesn't exist.");
        }

        [Test]
        public void Test_RemoveMethodShouldWorkCorrectly()
        {
            Shop shop = new Shop(5);
            Smartphone phone = new Smartphone("Samsung", 5000);
            Smartphone phone2 = new Smartphone("Huawei", 4500);
            Smartphone phone3 = new Smartphone("IPhone", 4000);

            shop.Add(phone);
            shop.Add(phone2);
            shop.Add(phone3);

            shop.Remove("IPhone");
            Assert.True(shop.Count == 2);
        }

        [Test]
        public void Test_TestPhoneMethodShouldThrowExceptionWhenPhoneDoesNotExist()
        {
            Shop shop = new Shop(2);
            Smartphone phone = new Smartphone("Samsung", 5000);
            Smartphone phone2 = new Smartphone("Huawei", 4500);
            Smartphone phone3 = new Smartphone("IPhone", 4000);

            shop.Add(phone);
            shop.Add(phone2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("IPhone", 5000);
            }, "The phone model IPhone doesn't exist.");
        }

        [Test]
        public void Test_TestPhoneMethodShouldThrowExceptionWhenPhoneIsLowOnBattery()
        {
            Shop shop = new Shop(3);
            Smartphone phone = new Smartphone("Samsung", 5000);
            Smartphone phone2 = new Smartphone("Huawei", 4500);
            Smartphone phone3 = new Smartphone("IPhone", 4000);

            shop.Add(phone);
            shop.Add(phone2);
            shop.Add(phone3);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("IPhone", 5000);
            }, "The phone model IPhone is low on batery.");
        }

        [Test]
        public void Test_TestPhoneMethodShouldWorkCorrectly()
        {
            Shop shop = new Shop(3);
            Smartphone phone = new Smartphone("Samsung", 5000);
            Smartphone phone2 = new Smartphone("Huawei", 4500);
            Smartphone phone3 = new Smartphone("IPhone", 4000);

            shop.Add(phone);
            shop.Add(phone2);
            shop.Add(phone3);

            shop.TestPhone("Samsung", 3000);
            Assert.True(phone.CurrentBateryCharge == 2000);
        }

        [Test]
        public void Test_ChargePhoneMethodShouldWorkCorrectly()
        {
            Shop shop = new Shop(3);
            Smartphone phone = new Smartphone("Samsung", 5000);
            Smartphone phone2 = new Smartphone("Huawei", 4500);
            Smartphone phone3 = new Smartphone("IPhone", 4000);

            shop.Add(phone);
            shop.Add(phone2);
            shop.Add(phone3);

            shop.TestPhone("Samsung", 3000);
            shop.ChargePhone("Samsung");
            Assert.True(phone.CurrentBateryCharge == 5000);
        }

        [Test]
        public void Test_ChargePhoneMethodShouldThrowExceptionWhenPhoeDoesNotExist()
        {
            Shop shop = new Shop(3);
            Smartphone phone = new Smartphone("Samsung", 5000);
            Smartphone phone2 = new Smartphone("Huawei", 4500);
            Smartphone phone3 = new Smartphone("IPhone", 4000);

            shop.Add(phone);
            shop.Add(phone2);
            shop.Add(phone3);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.ChargePhone("Nokia");
            }, "The phone model Nokia doesn't exist.");
        }
    }
}