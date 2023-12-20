using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Models.Hotels
{
    public class Hotel : IHotel
    {
        private readonly IRepository<IRoom> rooms;
        private readonly IRepository<IBooking> bookings;
        private string fullName;
        private int category;
        private double turnover;

        public Hotel(string fullName, int category)
        {
            FullName = fullName;
            Category = category;
            rooms = new RoomRepository();
            bookings = new BookingRepository();
        }

        public string FullName
        {
            get => fullName;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.HotelNameNullOrEmpty);
                }
                fullName = value;
            }
        }

        public int Category
        {
            get => category;
            private set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCategory);
                }
                category = value;
            }
        }

        public double Turnover
        {
            get
            {
                double turnover = CalculateTurnover(Bookings);
                return turnover;
            }
        }

        public IRepository<IRoom> Rooms
        {
            get
            {
                return rooms;
            }
        }
        public IRepository<IBooking> Bookings => bookings;

        private double CalculateTurnover(IRepository<IBooking> bookings)
        {
            double sum = 0;
            foreach (var booking in Bookings.All())
            {
                sum += booking.ResidenceDuration * booking.Room.PricePerNight;
            }

            return sum;
        }
    }
}
