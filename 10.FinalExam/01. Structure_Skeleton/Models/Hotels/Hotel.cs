using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Hotels
{
    public class Hotel : IHotel
    {
        private string fullName;
        private int category;
        private double turnover;
        private RoomRepository rooms;
        private BookingRepository bookings;

        public Hotel()
        {
            rooms = new RoomRepository();
            bookings = new BookingRepository();
        }
        public Hotel(string fullName, int category)
            :this()
        {
            this.FullName = fullName;
            this.Category = category;
        }
        public string FullName
        {
            get { return this.fullName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.HotelNameNullOrEmpty);
                }
                this.fullName = value;
            }
        }

        public int Category
        {
            get { return this.category; }
            private set 
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCategory);
                }
                this.category = value; 
            }
        }

        public double Turnover => findTurnover();

        private double findTurnover()
        {
            double total = 0 ;
            foreach (var booking in Bookings.All())
            {
                total += booking.ResidenceDuration * booking.Room.PricePerNight;
            }
            return total;
        }

        public IRepository<IRoom> Rooms 
        {
            get { return this.rooms; }
            set { this.rooms = (RoomRepository)value; }
        }

        public IRepository<IBooking> Bookings 
        {
            get { return this.bookings; }
            set { this.bookings = (BookingRepository)value; } 
        }

    }
}
