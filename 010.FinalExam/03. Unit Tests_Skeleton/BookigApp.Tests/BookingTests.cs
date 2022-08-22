using System;
using System.Collections.Generic;
using System.Text;
using FrontDeskApp;
using NUnit.Framework;

namespace BookigApp.Tests
{
    [TestFixture]
    public class BookingTests
    {
        [Test]
        public void ConstrWork()
        {
            Room room = new Room(1, 3);
            Booking booking = new Booking(1, room, 5);

            Assert.AreEqual(1, booking.BookingNumber);
            Assert.AreEqual(room, booking.Room);
            Assert.AreEqual(5, booking.ResidenceDuration);
        }
    }
}
