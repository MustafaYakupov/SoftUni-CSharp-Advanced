namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;
        private int[] input;
        private int expectedCount;

        [SetUp]
        public void SetUp()
        {
            database = new Database();
            input = new int[16];
            expectedCount = 0;
        }

        [Test]
        public void TestDatabaseConstructorShouldWorkCorrectly()
        {
            input = new int[3] { 5, 7, 10 };
            expectedCount = 3;

            database = new Database(input);

            Assert.AreEqual(expectedCount, database.Count);
        }

        [Test]
        public void TestStoringCapacityShouldBe16Ints()
        {
            input = new int[17];

            for (int i = 0; i < 17; i++)
            {
                input[i] = i;
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                Database database = new Database(input);
            }, "Storing array capacity is not 16 integers!");
        }


        [Test]
        public void TestAddMethodShouldWork()
        {
            input = new int[5];

            for (int i = 0; i < 5; i++)
            {
                input[i] = i;
            }

            expectedCount = 6;

            database = new Database(input);
            database.Add(10);

            Assert.AreEqual(expectedCount, database.Count, "Add method not adding properly!");
        }

        [Test]
        public void TestAddMethodWith16ElementsShouldWork()
        {
            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }

            expectedCount = 16;

            Assert.AreEqual(expectedCount, database.Count, "Add method with 16 elements not working properly!");
        }

        [Test]
        public void TestAddMethodWith17ElementsShouldNotWork()
        {
            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(5);
            }, "You must not be able to add more than 16 elements");
        }

        [Test]
        public void TestRemoveMethodShouldWorkCorrectly()
        {
            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }

            database.Remove();
            expectedCount = 15;

            Assert.AreEqual(expectedCount, database.Count, "Remove method doesn't work properly!");
        }

        [Test]
        public void TestRemoveMethodShouldRemoveTheLastElement()
        {
            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }

            int lastElement = database.Fetch()[15];

            database.Remove();

            int newLastElement = database.Fetch()[14];

            Assert.AreEqual(lastElement - 1, newLastElement, "Remove method doesn't remove the last element!");
        }

        [Test]
        public void TestRemoveMethodShouldNotWorkOnEmptyDatabase()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            }, "You must not be able remove an element from empty database!");
        }

        [Test]
        public void TestFetchMethodShouldReturnTheElementsAsArray()
        {
            int[] arrayToCompare = new int[16];

            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
                arrayToCompare[i] = i;
            }

            int[] arrayFromFetchMethod = database.Fetch();

            Assert.AreEqual(arrayToCompare, arrayFromFetchMethod, "Fetch method doesn not work properly!");
        }
    }
}
