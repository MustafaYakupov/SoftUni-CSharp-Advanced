using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private IRepository<IHotel> hotels;

        public Controller()
        {
            hotels = new HotelRepository();
        }

        public string AddHotel(string hotelName, int category)
        {
            if (hotels.All().Any(x => x.FullName == hotelName))
            {
                return String.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }

            IHotel hotel = new Hotel(hotelName, category);
            hotels.AddNew(hotel);

            return String.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
        }
        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            if (hotels.All().FirstOrDefault(x => x.FullName == hotelName) == null)
            {
                return String.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            if (hotels.All().Any(x => x.FullName == hotelName && x.Rooms.All().Any(x => x.GetType().Name == roomTypeName)))
            {
                return String.Format(OutputMessages.RoomTypeAlreadyCreated);
            }

            IRoom room = null;

            if (nameof(Apartment) == roomTypeName)
            {
                room = new Apartment();
            }
            else if (nameof(DoubleBed) == roomTypeName)
            {
                room = new DoubleBed();

            }
            else if (nameof(Studio) == roomTypeName)
            {
                room = new Studio();

            }
            else
            {
                return String.Format("Incorrect room type!");
            }

            IHotel hotel = hotels.All().FirstOrDefault(x => x.FullName == hotelName);

            hotel.Rooms.AddNew(room);

            return String.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
        }
        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            IHotel hotel = null;

            hotel = hotels.All().FirstOrDefault(x => x.FullName == hotelName);

            if (hotel == null)
            {
                return String.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            if (nameof(Apartment) != roomTypeName
                && nameof(DoubleBed) != roomTypeName
                && nameof(Studio) != roomTypeName)
            {
                return String.Format("Incorrect room type!");
            }

            if (hotel.Rooms.All().Any(x => x.GetType().Name == roomTypeName) == false)
            {
                return String.Format(OutputMessages.RoomTypeNotCreated);
            }

            if (hotel.Rooms.All().FirstOrDefault(x => x.GetType().Name == roomTypeName && x.PricePerNight != 0) != null)
            {
                return String.Format("Price is already set!");
            }

            IRoom room = hotel.Rooms.All().FirstOrDefault(x => x.GetType().Name == roomTypeName);
            room.SetPrice(price);

            return String.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            if (hotels.All().Any(x => x.Category == category) == false)
            {
                return String.Format(OutputMessages.CategoryInvalid, category);
            }

            List<IRoom> rooms = new();
            IHotel bookedHotel = null;

            foreach (var hotel in hotels.All().OrderBy(x => x.FullName))
            {
                foreach (var room in hotel.Rooms.All())
                {
                    if (room.PricePerNight != 0)
                    {
                        rooms.Add(room);
                        bookedHotel = hotels.Select(hotel.FullName);
                        break;
                    }
                }
            }

            int guests = adults + children;

            IRoom availableRoom = bookedHotel.Rooms.All().OrderBy(x => x.BedCapacity).FirstOrDefault(r => r.BedCapacity >= guests);

            if (availableRoom == null)
            {
                return String.Format(OutputMessages.RoomNotAppropriate, category);
            }


            IBooking booking = new Booking(availableRoom, duration, adults, children, bookedHotel.Bookings.All().Count + 1);

            bookedHotel.Bookings.AddNew(booking);

            return String.Format(OutputMessages.BookingSuccessful, bookedHotel.Bookings.All().Count, bookedHotel.FullName);
        }

        public string HotelReport(string hotelName)
        {
            var hotel = hotels.All().FirstOrDefault(x => x.FullName == hotelName);

            if (hotel == null)
            {
                return String.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            StringBuilder sb = new();

            sb.AppendLine($"Hotel name: {hotelName}");
            sb.AppendLine($"--{hotel.Category} star hotel");
            sb.AppendLine($"--Turnover: {hotel.Turnover:F2}$ ");
            sb.AppendLine($"--Bookings:");
            sb.AppendLine();

            if (hotel.Bookings.All().Count == 0)
            {
                sb.AppendLine("none");
            }
            else
            {
                foreach (var booking in hotel.Bookings.All())
                {
                    sb.AppendLine(booking.BookingSummary());
                }
            }

            return sb.ToString().Trim();
        }
    }
}
