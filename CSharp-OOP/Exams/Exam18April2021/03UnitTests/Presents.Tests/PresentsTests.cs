namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class PresentsTests
    {
        [Test]
        public void Test_ConstructorShouldWork()
        {
            Present present = new Present("toy", 5);

            Assert.AreEqual("toy", present.Name);
            Assert.AreEqual(5, present.Magic);

            Bag bag = new Bag();

            Assert.AreEqual(0, bag.GetPresents().Count);
        }

        [Test]
        public void Test_CreateShouldWork()
        {
            Present present = new Present("toy", 5);

            Bag bag = new Bag();

            string expectedResult = "Successfully added present toy.";

            Assert.AreEqual(expectedResult, bag.Create(present));
        }

        [Test]
        public void Test_CreateShouldThrow_WhenPresentIsNull()
        {
            Present present = null;

            Bag bag = new Bag();

            Assert.Throws<ArgumentNullException>(() =>
            {
                bag.Create(present);
            });
        }

        [Test]
        public void Test_CreateShouldThrow_WhenPresentExists()
        {
            Present present = new Present("toy", 5);

            Bag bag = new Bag();

            bag.Create(present);

            Assert.Throws<InvalidOperationException>(() =>
            {
                bag.Create(present);
            });
        }

        [Test]
        public void Test_RemoveShouldWork()
        {
            Present present = new Present("toy", 5);

            Bag bag = new Bag();
            bag.Create(present);


            Assert.AreEqual(true, bag.Remove(present));
            Assert.AreEqual(false, bag.Remove(present));
        }

        [Test]
        public void Test_GetPresentWithLeastMagicShouldWork()
        {
            Present present = new Present("toy", 5);
            Present present2 = new Present("toyLeastMagic", 3);

            Bag bag = new Bag();
            bag.Create(present);
            bag.Create(present2);


            Assert.AreEqual(present2, bag.GetPresentWithLeastMagic());
        }

        [Test]
        public void Test_GetPresentShouldWork()
        {
            Present present = new Present("toy", 5);
            Present present2 = new Present("toyLeastMagic", 3);

            Bag bag = new Bag();
            bag.Create(present);
            bag.Create(present2);


            Assert.AreEqual(present, bag.GetPresent("toy"));
            Assert.AreEqual(null, bag.GetPresent("NonExistant"));
        }

        [Test]
        public void Test_GetPresentsShouldWork()
        {
            Present present = new Present("toy", 5);
            Present present2 = new Present("toyLeastMagic", 3);

            Bag bag = new Bag();
            bag.Create(present);
            bag.Create(present2);

            List<Present> expectedListOfPresents = new List<Present>();

            expectedListOfPresents.Add(present);
            expectedListOfPresents.Add(present2);

            Assert.AreEqual(expectedListOfPresents, bag.GetPresents());
            Assert.AreEqual(2, bag.GetPresents().Count);
        }
    }
}
