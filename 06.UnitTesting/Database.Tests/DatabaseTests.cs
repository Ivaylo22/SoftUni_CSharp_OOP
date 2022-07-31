namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class DatabaseTests
    {
        private Database db;

        [SetUp]
        public void SetUp()
        {
            Database db = new Database();
            this.db = db;
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void ConstructorShoulsAddLessThan16Elements(int[] startingData)
        {
            Database actualDatabase = new Database(startingData);

            int[] actualData = actualDatabase.Fetch();
            int[] expectedData = startingData;

            int actualCount = actualDatabase.Count;
            int expectedCount = expectedData.Length;

            CollectionAssert.AreEqual(expectedData, actualData, "Data is not the same");
            Assert.AreEqual(expectedCount, actualCount, "Count is not the same");
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 })]
        public void ContsructorShouldNotAddMoreThan16ElementsThrowException(int[] startingData)
        {

            Assert.Throws<InvalidOperationException>(() =>
                {
                    Database database = new Database(startingData);
                }, "Array's capacity must be exactly 16 integers!"
            );
        }

        [Test]
        public void CountShouldReturnCorrectValue()
        {
            int actualCount = this.db.Count;
            int expectedCount = 0;
            Assert.AreEqual(expectedCount, actualCount, "Count doesnt return correct value");
        }

        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void AddShouldAddLessThan16Elements(int[] dataToAdd)
        {
            foreach (int el in dataToAdd)
            {
                this.db.Add(el);
            }

            int[] actualData = this.db.Fetch();
            int[] expectedData = dataToAdd;

            int actualCount = this.db.Count;
            int expectedCount = expectedData.Length;

            CollectionAssert.AreEqual(expectedData, actualData, "Data is not the same");
            Assert.AreEqual(expectedCount, actualCount, "Count is not the same");
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 })]
        public void AddShouldNotAddMoreThan16Elements(int[] dataToAdd)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                foreach (var el in dataToAdd)
                {
                    this.db.Add(el);
                }
            }, "Array's capacity must be exactly 16 integers!"
            );
        }

        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void RemoveShouldRemoveTheLastIndex(int[] startElement)
        {
            foreach(var el in startElement)
            {
                this.db.Add(el);
            }
            List<int> startElementList = new List<int>(startElement) {};

            this.db.Remove();
            startElementList.RemoveAt(startElement.Length - 1);


            int[] actualData = this.db.Fetch();
            int[] expectedData = startElementList.ToArray();

            int actualCount = this.db.Count;
            int expectedCount = expectedData.Length;

            CollectionAssert.AreEqual(expectedData, actualData, "Data is not the same");
            Assert.AreEqual(expectedCount, actualCount, "Count is not the same");
        }

        [Test]
        public void RemoveShouldNotRemoveFromEmptyArrayThrowException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.db.Remove();
            }, "The collection is empty!"
            );
        }

        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2 })]
        public void FetchShouldReturnTheSameData(int[] initData)
        {
            foreach (var el in initData)
            {
                this.db.Add(el);
            }

            int[] actualData = db.Fetch();
            int[] expected = initData;

            CollectionAssert.AreEqual(expected, actualData,
                "Data is not the same");
        }

    }
}
