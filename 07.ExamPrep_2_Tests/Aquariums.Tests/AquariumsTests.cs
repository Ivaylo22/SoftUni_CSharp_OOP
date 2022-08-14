namespace Aquariums.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class AquariumsTests
    {
        [Test]
        [TestCase("riba1", 10)]
        [TestCase("riba2", 20)]

        public void ConstructorShouldSetCorrectly(string name, int capacity)
        {
            Aquarium aquarium = new Aquarium(name, capacity);

            Assert.AreEqual(name, aquarium.Name);
            Assert.AreEqual(capacity, aquarium.Capacity);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void InvalidNameShouldThrowException(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium aquarium = new Aquarium(name, 1);
            }, "Invalid aquarium name!");

        }

        [Test]
        [TestCase(int.MinValue)]
        [TestCase(-1)]
        public void InvalidCapacityShouldThrowException(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Aquarium aquarium = new Aquarium("riba", capacity);
            }, "Invalid aquarium capacity!");
        }

        [Test]
        [TestCase(1)]
        [TestCase(5)]
        public void ShouldAddFishWhenFree(int capacity)
        {
            Aquarium aquarium = new Aquarium("ime", capacity);
            Fish fish = new Fish("ime");

            aquarium.Add(fish);
            int expCount = 1;
            int actCount = aquarium.Count;

            Assert.AreEqual(expCount, actCount);
        }

        [Test]
        public void ShouldAddManyFishWhenFree()
        {
            Aquarium aquarium = new Aquarium("ime", 5);
            Fish fish1 = new Fish("ime1");
            Fish fish2 = new Fish("im2");


            aquarium.Add(fish1);
            aquarium.Add(fish2);         

            int expCount = 2;
            int actCount = aquarium.Count;

            Assert.AreEqual(expCount, actCount);
        }

        [Test]
        public void ReachMaxCapacityWhenAddingShouldThrowException()
        {
            Aquarium aquarium = new Aquarium("ime", 2);
            Fish fish1 = new Fish("ime1");
            Fish fish2 = new Fish("ime2");
            Fish fish3 = new Fish("ime3");
            aquarium.Add(fish1);
            aquarium.Add(fish2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.Add(fish3);
            }, "Aquarium is full!");
        }

        [Test]
        [TestCase("riba3")]
        public void NotExistingFishToRemoveShouldThrowException(string name)
        {
            Aquarium aquarium = new Aquarium("ime", 5);

            Fish fish1 = new Fish("riba1");
            Fish fish2 = new Fish("riba2");

            aquarium.Add(fish1);
            aquarium.Add(fish2);


            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.RemoveFish("riba3");
            }, $"Fish with the name {name} doesn't exist!");
        }

        [Test]
        [TestCase("riba3")]
        public void ShouldRemoveExistingFish(string name)
        {
            Aquarium aquarium = new Aquarium("ime", 5);
            Fish fish1 = new Fish("riba1");
            Fish fish2 = new Fish("riba2");
            Fish fish3 = new Fish("riba3");

            aquarium.Add(fish1);
            aquarium.Add(fish2);
            aquarium.Add(fish3);

            aquarium.RemoveFish(fish3.Name);

            int expCount = 2;
            int actCount = aquarium.Count;

            Assert.AreEqual(expCount, actCount);
        }

        [Test]
        public void ShouldRemoveMoreExistingFish()
        {
            Aquarium aquarium = new Aquarium("ime", 5);
            Fish fish1 = new Fish("riba1");
            Fish fish2 = new Fish("riba2");
            Fish fish3 = new Fish("riba3");

            aquarium.Add(fish1);
            aquarium.Add(fish2);
            aquarium.Add(fish3);

            aquarium.RemoveFish(fish1.Name);
            aquarium.RemoveFish(fish2.Name);

            Assert.That(aquarium.Count == 1);


        }

        [Test]
        [TestCase("riba3")]
        public void NotExistingFishToSellShouldThrowException(string name)
        {
            var aquarium = new Aquarium("ime", 5);
            Fish fish1 = new Fish("riba1");
            Fish fish2 = new Fish("riba2");

            aquarium.Add(fish1);
            aquarium.Add(fish2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                Fish f = aquarium.SellFish(name);
            }, $"Fish with the name {name} doesn't exist!");
        }

        [Test]
        [TestCase("riba2")]
        public void ShouldSellExistingFish(string name)
        {
            var aquarium = new Aquarium("ime", 5);
            Fish fish1 = new Fish(name);
            Fish fish2 = new Fish("riba2");

            aquarium.Add(fish1);
            aquarium.Add(fish2);

            Fish fish = aquarium.SellFish(name);

            Assert.IsFalse(fish.Available);
        }

        [Test]
        public void ReportWithNoSellsShouldWorkProperly()
        {
            var aquarium = new Aquarium("ime", 5);

            Fish fish1 = new Fish("riba1");
            Fish fish2 = new Fish("riba2");

            aquarium.Add(fish1);
            aquarium.Add(fish2);

            string actRes = aquarium.Report();
            string expRes = $"Fish available at ime: riba1, riba2";

            Assert.AreEqual(expRes, actRes);
        }

        [Test]
        public void ReportWithOneFish()
        {
            var aquarium = new Aquarium("ime", 5);

            Fish fish1 = new Fish("riba1");

            aquarium.Add(fish1);

            string actRes = aquarium.Report();
            string expRes = $"Fish available at ime: riba1";

            Assert.AreEqual(expRes, actRes);
        }

        [Test]
        public void ReportWithNoFish()
        {
            var aquarium = new Aquarium("ime", 5);

            string actRes = aquarium.Report();
            string expRes = $"Fish available at ime: ";

            Assert.AreEqual(expRes, actRes);
        }

    }
}
