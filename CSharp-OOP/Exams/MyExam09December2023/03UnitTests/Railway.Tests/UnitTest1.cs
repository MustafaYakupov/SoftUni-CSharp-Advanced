namespace Railway.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Tests
    {
        

        [Test]
        public void Test_ConstructorShouldWork()
        {
            RailwayStation station = new RailwayStation("Station");

            Assert.AreEqual("Station", station.Name);
            Assert.AreEqual(0, station.ArrivalTrains.Count);
            Assert.AreEqual(0, station.DepartureTrains.Count);
        }

        [Test]
        public void Test_ConstructorShouldShouldThrow_WhenNameNullOrEmpty()
        {
            string nameNull = null;

            Assert.Throws<ArgumentException>(() =>
            {
                RailwayStation station = new RailwayStation("");
            });

            Assert.Throws<ArgumentException>(() =>
            {
                RailwayStation station = new RailwayStation(nameNull);
            });
        }

        [Test]
        public void Test_NewArrivalOnBoardShouldWork()
        {
            RailwayStation station = new RailwayStation("Station");

            station.NewArrivalOnBoard("Arriving train1");
            station.NewArrivalOnBoard("Arriving train2");

            Queue<string> expectedResult = new Queue<string>();
            expectedResult.Enqueue("Arriving train1");
            expectedResult.Enqueue("Arriving train2");

            Assert.AreEqual(expectedResult, station.ArrivalTrains);
        }

        [Test]
        public void Test_TrainHasArrivedShouldWork()
        {
            RailwayStation station = new RailwayStation("Station");

            station.NewArrivalOnBoard("Arriving train1");
            station.NewArrivalOnBoard("Arriving train2");

            Queue<string> expectedResult = new Queue<string>();
            expectedResult.Enqueue("Arriving train1");

            string expectedOutput = "Arriving train1 is on the platform and will leave in 5 minutes.";

            Assert.AreEqual(expectedOutput, station.TrainHasArrived("Arriving train1"));
            Assert.AreEqual(expectedResult, station.DepartureTrains);
            Assert.AreEqual(1, station.DepartureTrains.Count);
        }

        [Test]
        public void Test_TrainHasArrivedShouldThrow_WhenTrainIsNotOnTurn()
        {
            RailwayStation station = new RailwayStation("Station");

            station.NewArrivalOnBoard("Arriving train1");
            station.NewArrivalOnBoard("Arriving train2");

            Queue<string> expectedResult = new Queue<string>();
            expectedResult.Enqueue("Arriving train1");
            expectedResult.Enqueue("Arriving train2");

            string expectedOutput = "There are other trains to arrive before Arriving train2.";

            Assert.AreEqual(expectedOutput, station.TrainHasArrived("Arriving train2"));
        }

        [Test]
        public void Test_TrainHasLeftShouldWork()
        {
            RailwayStation station = new RailwayStation("Station");

            station.NewArrivalOnBoard("Arriving train1");
            station.NewArrivalOnBoard("Arriving train2");

            Queue<string> expectedResult = new Queue<string>();
            expectedResult.Enqueue("Arriving train1");

            station.TrainHasArrived("Arriving train1");
            station.TrainHasArrived("Arriving train2");

            Assert.AreEqual(true, station.TrainHasLeft("Arriving train1"));
            Assert.AreEqual(false, station.TrainHasLeft("Arriving train1"));
            Assert.AreEqual(1, station.DepartureTrains.Count);
        }
    }
}