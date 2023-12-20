namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database database;
        private Person person;
        private Person[] persons;
        private int expectedCount;

        [SetUp]
        public void SetUp()
        {
            database = new Database();
            persons = new Person[16];
            expectedCount = 0;
        }

        [Test]
        public void TestAddMethodShouldThrowExceptionWhenUsernameExists()
        {
            person = new Person(1, "Ivan");
            database.Add(person);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(person);
            });
        }

        [Test]
        public void TestAddMethodShouldThrowExceptionWhenIdExists()
        {
            person = new Person(1, "Ivan");
            database.Add(person);

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(person);
            });
        }

        [Test]
        public void TestRemoveMethodShouldWorkCorrectly()
        {
            person = new Person(1, "Ivan");
            database.Add(person);

            database.Remove();
            expectedCount = 0;

            Assert.AreEqual(expectedCount, database.Count, "Remove method doesn't work properly!");
        }

        [Test]
        public void TestRemoveMethodShouldThrowExceptionWhenNoUsers()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });
        }

        [Test]
        public void TestFindByUsernameShouldNotWorkWhenNoUserWithThisUsername()
        {
            person = new Person(1, "Ivan");
            database.Add(person);
            string notExistingUsername = "George"; 

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindByUsername(notExistingUsername);
            });
        }

        [Test]
        public void TestFindByUsernameWhenUsernameIsNull()
        {
            person = new Person(1, "Ivan");
            database.Add(person);
            string notExistingUsername = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                database.FindByUsername(notExistingUsername);
            });
        }

        [Test]
        public void TestFindByUsernameShouldBeCaseSensitive()
        {
            person = new Person(1, "Ivan");
            database.Add(person);
            string notExistingUsername = "ivan";

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindByUsername(notExistingUsername);
            });
        }

        [Test]
        public void TestFindByIdWhenNoUSerWithThisIdShouldNotWork()
        {
            person = new Person(1, "Ivan");
            database.Add(person);
            long notExistingId = 2;

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindById(notExistingId);
            });
        }

        [Test]
        public void TestFindByIdWhenIdIsNegatuiveShouldNotWork()
        {
            person = new Person(1, "Ivan");
            database.Add(person);
            long notExistingId = -1;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                database.FindById(notExistingId);
            });
        }

        [Test]
        public void TestConstructorShuldWorkCorrectly()
        {
           Person person1 = new Person(1, "Ivan");
           Person person2 = new Person(2, "George");

            database = new Database(person1, person2);
            expectedCount = 2;

            Assert.AreEqual(expectedCount, database.Count);
        }

        [Test]
        public void TestAddRangeMethodStoringCapacityShouldBe16Ints()
        {
            Person[] persons = new Person[17];

            for (long i = 0; i < 17; i++)
            {
                Person person = new Person(i, $"Ivan{i}");
                persons[i] = person;
            }

            Assert.Throws<ArgumentException>(() =>
            {
                database = new Database(persons);
            });
        }
    }
}