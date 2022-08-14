using NUnit.Framework;
using System;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [Test]
            [TestCase("name", 10)]
            public void ConstructorShouldSetCorrectly(string name, int budget)
            {
                var planet = new Planet(name, budget);

                Assert.AreEqual(name, planet.Name);
                Assert.AreEqual(budget, planet.Budget);
            }

            [Test]
            [TestCase(null)]
            [TestCase("")]
            public void InvalidNameThrowException(string name)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    var planet = new Planet(name, 10);

                }, "Invalid planet Name");

            }

            [Test]
            [TestCase(-10)]
            [TestCase(-1)]
            public void InvalidNameThrowException(double budget)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    var planet = new Planet("gosho", budget);

                }, "Budget cannot drop below Zero!");
            }

            [Test]
            public void SpendFundShouldThrowException()
            {
                var planet = new Planet("gosho", 1);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.SpendFunds(2);
                }, "Not enough funds to finalize the deal.");
            }

            [Test]
            public void AddWeaponShouldAddWeapon()
            {
                var planet = new Planet("gosho", 1);
                var weapon1 = new Weapon("weap", 5, 5);
                var weapon2 = new Weapon("weap2", 4, 4);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);

                int expCount = 2;
                int actCount = planet.Weapons.Count;

                Assert.AreEqual(expCount, actCount);

            }

            [Test]
            public void AddWeaponShouldThrowException()
            {
                var planet = new Planet("gosho", 1);

                var weapon1 = new Weapon("weap", 5, 5);
                var weapon2 = new Weapon("weap", 4, 4);

                planet.AddWeapon(weapon1);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.AddWeapon(weapon2);
                }, $"There is already a {weapon2.Name} weapon.");

            }

            [Test]
            public void RemoveWeaponSHouldRemoveWeapon()
            {
                var planet = new Planet("gosho", 1);

                var weapon1 = new Weapon("weap", 5, 5);
                var weapon2 = new Weapon("weap2", 4, 4);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);

                planet.RemoveWeapon("weap2");

                int expCount = 1;
                int actCount = planet.Weapons.Count;

                Assert.AreEqual(expCount, actCount);
            }

            [Test]
            public void UpgradeWeaponShouldTHrowException()
            {
                string upgradeWeapon = "asd";

                var planet = new Planet("gosho", 1);

                var weapon1 = new Weapon("weap", 5, 5);
                planet.AddWeapon(weapon1);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.UpgradeWeapon(upgradeWeapon);
                }, $"{upgradeWeapon} does not exist in the weapon repository of {planet.Name}");
            }

            [Test]
            public void UpgradeWeaponSHouldUpgradeWeapon()
            {
                var planet = new Planet("gosho", 1);

                var weapon1 = new Weapon("weap", 5, 5);
                planet.AddWeapon(weapon1);

                planet.UpgradeWeapon("weap");

                int expWDL = 6;
                int actWDL = weapon1.DestructionLevel;

                Assert.AreEqual(expWDL, actWDL);
            }

            [Test]
            public void DestructOpponentShouldThrowException()
            {
                var planet = new Planet("gosho", 1);

                var weapon1 = new Weapon("weap", 5, 5);
                var weapon2 = new Weapon("weap2", 5, 10);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);

                var planet2 = new Planet("gosho", 1);

                var weapon3 = new Weapon("weap3", 5, 100);
                var weapon4 = new Weapon("weap4", 5, 20);

                planet2.AddWeapon(weapon3);
                planet2.AddWeapon(weapon4);


                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.DestructOpponent(planet2);

                }, $"{planet2.Name} is too strong to declare war to!");
            }

            public void DestructOpponentShouldThrowExceptionV2()
            {
                var planet = new Planet("gosho", 1);

                var weapon1 = new Weapon("weap", 5, 5);
                var weapon2 = new Weapon("weap2", 5, 10);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);

                var planet2 = new Planet("gosho", 1);

                var weapon3 = new Weapon("weap3", 5, 5);
                var weapon4 = new Weapon("weap4", 5, 10);

                planet2.AddWeapon(weapon3);
                planet2.AddWeapon(weapon4);


                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.DestructOpponent(planet2);

                }, $"{planet2.Name} is too strong to declare war to!");
            }

            [Test]
            public void DestructOponentShouldWork()
            {
                var planet = new Planet("gosho", 1);

                var weapon1 = new Weapon("weap", 5, 100);
                var weapon2 = new Weapon("weap2", 5, 2000);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);

                var planet2 = new Planet("gosho", 1);

                var weapon3 = new Weapon("weap3", 5, 5);
                var weapon4 = new Weapon("weap4", 5, 10);

                planet2.AddWeapon(weapon3);
                planet2.AddWeapon(weapon4);

                Assert.AreEqual(planet.DestructOpponent(planet2), $"{planet2.Name} is destructed!");
            }


            [Test]
            public void SpendFUndShouldRemoveBudget()
            {
                var planet = new Planet("gosho", 100);
                planet.SpendFunds(50);

                double expBudget = 50;
                double actBudget = planet.Budget;

                Assert.AreEqual(expBudget, actBudget);
            }


            [Test]
            public void ProfitShouldAddBudget()
            {
                var planet = new Planet("gosho", 1);
                planet.Profit(100);

                double expBudget = 101;
                double actBudget = planet.Budget;

                Assert.AreEqual(expBudget, actBudget);
            }

            [Test]
            public void MilitaryPowerRatioShouldReturnValidInfo()
            {
                var planet = new Planet("gosho", 1);

                var weapon1 = new Weapon("weap", 5, 5);
                var weapon2 = new Weapon("weap2", 4, 4);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);

                double expDestLevel = 9;
                double actDestLevel = planet.MilitaryPowerRatio;

                Assert.AreEqual(expDestLevel, actDestLevel);
            }

            [Test]
            public void ReadonlyCollectionShouldFill()
            {
                var planet = new Planet("gosho", 1);
                var weapon1 = new Weapon("weap", 5, 5);
                var weapon2 = new Weapon("weap2", 4, 4);

                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);

                int expCount = 2;
                int actCount = planet.Weapons.Count;

                Assert.AreEqual(expCount, actCount);

            }

        }
    }
}
