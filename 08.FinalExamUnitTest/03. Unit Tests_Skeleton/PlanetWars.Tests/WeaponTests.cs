using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace PlanetWars.Tests
{
    [TestFixture]
    public class WeaponTests
    {
        [Test]
        [TestCase("weapon1", 10.5, 5)]
        [TestCase("weapon2", 20.5, 10)]
        public void ConstructorShouldSetCorectly(string name, double price, int destructionLevel)
        {
            Weapon weapon = new Weapon(name, price, destructionLevel);

            Assert.AreEqual(name, weapon.Name);
            Assert.AreEqual(price, weapon.Price);
            Assert.AreEqual(destructionLevel, weapon.DestructionLevel);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-100)]
        [TestCase(int.MinValue)]
        public void PriceBelow0ShouldThrowException(double price)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Weapon weapon = new Weapon("gosho", price, 5);

            }, "Price cannot be negative.");
        }

        [Test]
        public void IncreaseDestructionShouldWork()
        {
            Weapon weapon = new Weapon("gosho", 10.5, 5);
            weapon.IncreaseDestructionLevel();

            int expDestructionLevel = 6;
            int actualDestructionLevel = weapon.DestructionLevel;

            Assert.AreEqual(expDestructionLevel, actualDestructionLevel);
        }

        [Test]
        [TestCase(10)]
        [TestCase(20)]
        public void BoolIsNuclearShouldReturnTrue(int destLevel)
        {
            Weapon weapon = new Weapon("gosho", 10.5, destLevel);

            Assert.IsTrue(weapon.IsNuclear);
        }

        [Test]
        [TestCase(1)]
        [TestCase(9)]
        public void BoolIsNuclearShouldReturnFalse(int destLevel)
        {
            Weapon weapon = new Weapon("gosho", 10.5, destLevel);

            Assert.IsFalse(weapon.IsNuclear);
        }
    }
}
