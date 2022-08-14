using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Aquariums.Tests
{
    [TestFixture]
    public class FishTests
    {
        [Test]
        [TestCase("Nemo")]
        [TestCase("Riba1")]
        [TestCase("Riba2")]
        public void ConstructorShouldSetNameCorrectly(string name)
        {
            Fish fish = new Fish(name);
            Assert.AreEqual(name, fish.Name);
        }

        [Test]
        [TestCase("Nemo")]
        public void ConstructorShouldSetAvailabilityToTrue(string name)
        {
            Fish fish = new Fish(name);
            Assert.AreEqual(name, fish.Name);
            Assert.IsTrue(fish.Available);
        }
    }
}
