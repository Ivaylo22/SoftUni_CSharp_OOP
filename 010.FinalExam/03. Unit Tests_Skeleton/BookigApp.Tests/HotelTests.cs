using System;
using System.Collections.Generic;
using System.Text;
using FrontDeskApp;
using NUnit.Framework;

namespace BookigApp.Tests
{
    [TestFixture]
    public class HotelTests
    {
        [Test]
        public void ConstructorWorks()
        {
            Hotel hotel = new Hotel("Hotel", 4);

            Assert.AreEqual("Hotel", hotel.FullName);
            Assert.AreEqual(4, hotel.Category);
            Assert.AreEqual(0, hotel.Turnover);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void NameExc(string name)
        {
            Assert.Throws<ArgumentNullException>(() => new Hotel(name, 4));
        }

        [Test]
        [TestCase(0)]
        [TestCase(6)]
        public void CatExc(int cat)
        {
            Assert.Throws<ArgumentException>(() => new Hotel("Hotel", cat));
        }

        [Test]
        public void AddWork()
        {
            var hotel1 = new Hotel("1", 1);
            Room room = new Room(1, 1);
            Room room2 = new Room(2, 2);


            hotel1.AddRoom(room);
            hotel1.AddRoom(room2);

            Assert.AreEqual(2, hotel1.Rooms.Count);
        }

        [Test]
        [TestCase(0, 2, 2, 100)]
        [TestCase(1, -1, 2, 100)]
        [TestCase(1, 1, 0, 100)]
        public void BookExc(int adults, int children, int residenceDuration, double budget)
        {
            var hotel1 = new Hotel("1", 3);
            Assert.Throws<ArgumentException>(() => hotel1.BookRoom(adults, children, residenceDuration, budget));
        }

        [Test]
        public void BookingWorks()
        {
            var hotel1 = new Hotel("1", 3);

            var room = new Room(5, 10);

            hotel1.AddRoom(room);

            hotel1.BookRoom(1, 1, 3, 1000);

            Assert.AreEqual(1, hotel1.Bookings.Count);
            Assert.AreEqual(30, hotel1.Turnover);

        }




    }
}
