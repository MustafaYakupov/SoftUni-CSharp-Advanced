using FrontDeskApp;
using NUnit.Framework;
using System;
using System.Linq;

namespace BookigApp.Tests
{
    public class Tests
    {
        [Test]
        public void Test_ConstructorShouldWorkCorrectly()
        {
            Room room1 = new Room(2, 100);
            Room room2 = new Room(2, 200);
            Room room3 = new Room(2, 300);
            Booking booking1 = new Booking(1, room1, 5);
            Booking booking2 = new Booking(2, room2, 5);
            Booking booking3 = new Booking(3, room3, 5);

            Hotel hotel = new Hotel("Belagio", 5);

            Assert.True(room1.BedCapacity == 2);
            Assert.True(room1.PricePerNight == 100);
            Assert.True(booking1.ResidenceDuration == 5);
            Assert.True(booking1.BookingNumber == 1);
            Assert.True(booking1.Room == room1);

            Assert.True(hotel.FullName == "Belagio");
            Assert.True(hotel.Category == 5);



            Assert.Throws<ArgumentNullException>(() =>
            {
                Hotel hotel2 = new Hotel(" ", 5);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                Hotel hotel2 = new Hotel("Plaza", 6);
            });
        }

        [Test]
        public void Test_AddRoomShouldWorkCorrectly()
        {
            Room room1 = new Room(2, 100);
            Room room2 = new Room(2, 200);
            Room room3 = new Room(2, 300);
            Booking booking1 = new Booking(1, room1, 5);
            Booking booking2 = new Booking(2, room2, 5);
            Booking booking3 = new Booking(3, room3, 5);

            Hotel hotel = new Hotel("Belagio", 5);

            hotel.AddRoom(room1);
            hotel.AddRoom(room2);

            Assert.True(hotel.Rooms.Count() == 2);
            Assert.True(hotel.Rooms.Contains(room2));
        }

        [Test]
        public void Test_BookRoomShouldWorkCorrectly()
        {
            Room room1 = new Room(2, 100);
            Room room2 = new Room(2, 200);
            Room room3 = new Room(2, 300);
            Booking booking1 = new Booking(1, room1, 5);
            Booking booking2 = new Booking(2, room2, 5);
            Booking booking3 = new Booking(3, room3, 5);

            Hotel hotel = new Hotel("Belagio", 5);

            hotel.AddRoom(room1);
            hotel.AddRoom(room2);
            hotel.AddRoom(room3);

            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(0, 0, 3, 90);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(2, -5, 3, 90);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(2, 0, 0, 90);
            });

            hotel.BookRoom(2, 0, 3, 600);

            Assert.AreEqual(2, hotel.Bookings.Count);
            Assert.AreEqual(900, hotel.Turnover);
        }
    }
}