using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Bookings
{
    public class Booking : IBooking
    {
        private IRoom room;
        private int residenceDuration;
        private int adultsCount;
        private int childrenCount;
        private int bookingNumber;

        public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount, int bookingNumber)
        {
            this.Room = room;
            this.ResidenceDuration = residenceDuration;
            this.AdultsCount = adultsCount;
            this.ChildrenCount = childrenCount;
            this.BookingNumber = bookingNumber;
        }
        public IRoom Room { get; private set; }

        public int ResidenceDuration
        {
            get { return this.residenceDuration; }
            private set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.DurationZeroOrLess);
                }
                this.residenceDuration = value;
            }
        }

        public int AdultsCount
        {
            get { return this.adultsCount; }
            private set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.AdultsZeroOrLess);
                }
                this.adultsCount = value; 
            }
        }

        public int ChildrenCount
        {
            get { return this.childrenCount; }
            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.ChildrenNegative);
                }
                this.childrenCount = value; 
            }
        }

        public int BookingNumber { get; private set; }

        private double TotalPaid() => Math.Round(this.ResidenceDuration * this.Room.PricePerNight, 2);

        public string BookingSummary()
        {
            var sb = new StringBuilder();
            sb
                .AppendLine($"Booking number: {BookingNumber}")
                .AppendLine($"Room type: {this.Room.GetType().Name}")
                .AppendLine($"Adults: {AdultsCount} Children: {ChildrenCount}")
                .AppendLine($"Total amount paid: {TotalPaid():F2} $");

            return sb.ToString().Trim();

        }
    }
}
