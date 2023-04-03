using System;
using System.Collections.Generic;
using System.Text;
using FrontDeskApp;
using NUnit.Framework;

namespace BookigApp.Tests
{
    [TestFixture]
    public class RoomTests
    {
        [Test]
        public void ConstrWork()
        {
            Room room = new Room(1, 5);
            Assert.AreEqual(1, room.BedCapacity);
            Assert.AreEqual(5, room.PricePerNight);
        }

        [Test]
        public void BCEXC()
        {
            Assert.Throws<ArgumentException>(() => new Room(0, 3));
        }

        [Test]
        public void PPNEXC()
        {
            Assert.Throws<ArgumentException>(() => new Room(3, 0));
        }
    }
}
