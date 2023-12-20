namespace SmartDevice.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Text;

    public class Tests
    {
        [Test]
        public void Test_ConstructorShouldWork()
        {
            Device device = new Device(256);

            Assert.AreEqual(256, device.MemoryCapacity);
            Assert.AreEqual(256, device.AvailableMemory);
            Assert.AreEqual(0, device.Applications.Count);
            Assert.AreEqual(0, device.Photos);
        }

        [Test]
        public void Test_TakePhotoShouldWork()
        {
            Device device = new Device(256);

            Assert.AreEqual(true, device.TakePhoto(1));
            Assert.AreEqual(1, device.Photos);
            Assert.AreEqual(255, device.AvailableMemory);
        }

        [Test]
        public void Test_TakePhotoShouldNotWorkNoMemory()
        {
            Device device = new Device(256);

            Assert.AreEqual(false, device.TakePhoto(300));
        }

        [Test]
        public void Test_InstallAppShouldWork()
        {
            Device device = new Device(256);

            string expectedResult = "ChessApp is installed successfully. Run application?";

            Assert.AreEqual(expectedResult, device.InstallApp("ChessApp", 56));
            Assert.AreEqual(200, device.AvailableMemory);
            Assert.AreEqual(1, device.Applications.Count);
            Assert.True(device.Applications.Contains("ChessApp"));
        }

        [Test]
        public void Test_InstallAppShouldNotWorkNoMemory()
        {
            Device device = new Device(256);

            Assert.Throws<InvalidOperationException>(() =>
            {
                device.InstallApp("ChessApp", 300);
            });
        }

        [Test]
        public void Test_FormatDeviceShouldWork()
        {
            Device device = new Device(256);

            device.TakePhoto(50);
            device.InstallApp("Chess", 50);

            Assert.AreEqual(156, device.AvailableMemory);
            Assert.AreEqual(1, device.Photos);
            Assert.AreEqual(256, device.MemoryCapacity);
            Assert.AreEqual(1, device.Applications.Count);

            device.FormatDevice();

            Assert.AreEqual(256, device.AvailableMemory);
            Assert.AreEqual(0, device.Applications.Count);
            Assert.AreEqual(0, device.Photos);
        }

        [Test]
        public void Test_GetDeviceStatusShouldWork()
        {
            Device device = new Device(256);

            device.TakePhoto(50);
            device.InstallApp("Chess", 50);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Memory Capacity: 256 MB, Available Memory: 156 MB");
            sb.AppendLine("Photos Count: 1");
            sb.AppendLine("Applications Installed: Chess");

            string expectedResult = sb.ToString().Trim();

            Assert.AreEqual(expectedResult, device.GetDeviceStatus());
        }
    }
}