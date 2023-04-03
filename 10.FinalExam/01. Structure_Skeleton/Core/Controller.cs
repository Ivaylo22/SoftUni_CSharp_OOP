using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Hotels;
using BookingApp.Models.Rooms;
using BookingApp.Repositories;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private readonly HotelRepository hotels;

        public Controller()
        {
            this.hotels = new HotelRepository();
        }

        public string AddHotel(string hotelName, int category)
        {
            if (hotels.All().Any(h => h.FullName == hotelName))
            {
                return string.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }

            hotels.AddNew(new Hotel(hotelName, category));

            return String.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            Room room = null;
            Hotel hotel = (Hotel)hotels.Select(hotelName);

            if (hotel == null)
            {
                return String.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            if (hotel.Rooms.All().Any(r => r.GetType().Name == roomTypeName))
            {
                return OutputMessages.RoomTypeAlreadyCreated;

            }

            if (!(roomTypeName == "Apartment" || roomTypeName == "DoubleBed" || roomTypeName == "Studio"))
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            if (roomTypeName == "Apartment")
            {
                room = new Apartment();
            }
            else if (roomTypeName == "DoubleBed")
            {
                room = new DoubleBed();
            }
            else
            {
                room = new Studio();
            }
            hotel.Rooms.AddNew(room);
            return String.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            Hotel hotel = (Hotel)hotels.Select(hotelName);

            if (hotel == null)
            {
                return String.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            if (!(roomTypeName == "Apartment" || roomTypeName == "DoubleBed" || roomTypeName == "Studio"))
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            if (!hotel.Rooms.All().Any(r => r.GetType().Name == roomTypeName))
            {
                return OutputMessages.RoomTypeNotCreated;
            }

            Room room = (Room)hotel.Rooms.Select(roomTypeName);

            if (room.PricePerNight > 0)
            {
                throw new InvalidOperationException(ExceptionMessages.CannotResetInitialPrice);
            }

            hotel.Rooms.Select(roomTypeName).SetPrice(price);
            return String.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
           

            List<Room> rooms = new List<Room>();

            foreach (var hotel in hotels.All().OrderBy(h => h.FullName).Where(h => h.Category == category))
            {
                foreach (var room in hotel.Rooms.All())
                {
                    if (room.PricePerNight > 0)
                    {
                        rooms.Add((Room)room);
                    }
                }
            }


            rooms = rooms.OrderBy(r => r.BedCapacity).ToList();

            int totalCount = adults + children;

            if (!hotels.All().Any(h => h.Category == category))
            {
                return String.Format(OutputMessages.CategoryInvalid, category);
            }

            bool isGood = false;
            foreach (var room in rooms)
            {
                if (room.BedCapacity >= totalCount)
                {
                    isGood = true;
                    break;
                }
            }

            if (!isGood)
            {
                return OutputMessages.RoomNotAppropriate;
            }

            Room myRoom = rooms.First(r => r.BedCapacity >= totalCount);

            Hotel myHotel = null;
            foreach (var h in hotels.All())
            {
                if (h.Rooms.All().Contains(myRoom))
                {
                    myHotel = (Hotel)h;
                    break;
                }
            }

            int bookingNumber = hotels.Select(myHotel.FullName).Bookings.All().Count() + 1;
            Booking myBooking = new Booking(myRoom, duration, adults, children, bookingNumber);

            hotels.Select(myHotel.FullName).Bookings.AddNew(myBooking);

            return string.Format(OutputMessages.BookingSuccessful, bookingNumber, myHotel.FullName);
        }

        public string HotelReport(string hotelName)
        {
            Hotel myHotel = (Hotel)hotels.Select(hotelName);

            var sb = new StringBuilder();

            sb
                .AppendLine($"Hotel name: {hotelName}")
                .AppendLine($"--{myHotel.Category} star hotel")
                .AppendLine($"--Turnover: {myHotel.Turnover:F2} $")
                .AppendLine("--Bookings:");
            
            if (myHotel.Bookings.All().Count == 0)
            {
                sb
                    .AppendLine()
                    .AppendLine("none");
            }
            else
            {
                foreach (var book in myHotel.Bookings.All())
                {
                    sb
                        .AppendLine()
                        .AppendLine(book.BookingSummary());
                }

            }

            return sb.ToString().Trim();

        }
     
    }
}
