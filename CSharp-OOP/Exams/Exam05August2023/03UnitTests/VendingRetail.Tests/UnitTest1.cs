using NUnit.Framework;

namespace VendingRetail.Tests
{
    public class Tests
    {
        [Test]
        public void Test_ConstructorShouldWorkCorrectly()
        {
            CoffeeMat coffeMat = new CoffeeMat(15000, 5);

            Assert.True(coffeMat.WaterCapacity == 15000);
            Assert.True(coffeMat.ButtonsCount == 5);
            Assert.True(coffeMat.Income == 0);
            Assert.IsNotNull(coffeMat);
        }

        [Test]
        public void Test_FillWaterTankShouldWorkCorrectly()
        {
            CoffeeMat coffeMat = new CoffeeMat(15000, 5);

            string expectedMessage = "Water tank is filled with 15000ml";

            Assert.AreEqual(expectedMessage, coffeMat.FillWaterTank());
        }

        [Test]
        public void Test_FillWaterTankWhenTankIsFull()
        {
            CoffeeMat coffeMat = new CoffeeMat(15000, 5);

            coffeMat.FillWaterTank();

            string expectedMessage = "Water tank is already full!";

            Assert.AreEqual(expectedMessage, coffeMat.FillWaterTank());

            coffeMat.AddDrink("espresso", 5);
            coffeMat.BuyDrink("espresso");

            expectedMessage = "Water tank is filled with 80ml";
            Assert.AreEqual(expectedMessage, coffeMat.FillWaterTank());


            expectedMessage = "Water tank is already full!";
            Assert.AreEqual(expectedMessage, coffeMat.FillWaterTank());
        }

        [Test]
        public void Test_AddDrinkShouldWorkCorrectly()
        {
            CoffeeMat coffeMat = new CoffeeMat(15000, 5);

            bool expectedResult = true;

            Assert.AreEqual(expectedResult, coffeMat.AddDrink("espresso", 5));
        }

        [Test]
        public void Test_AddDrinkShouldReturnFalseWhenDrinkAlreadyAdded()
        {
            CoffeeMat coffeMat = new CoffeeMat(15000, 5);

            bool expectedResult = false;
            coffeMat.AddDrink("espresso", 5);

            Assert.AreEqual(expectedResult, coffeMat.AddDrink("espresso", 5));
        }

        [Test]
        public void Test_AddDrinkShouldReturnFalseWhenNoMoreRoomForDrinks()
        {
            CoffeeMat coffeMat = new CoffeeMat(15000, 1);

            bool expectedResult = false;
            coffeMat.AddDrink("espresso", 5);

            Assert.AreEqual(expectedResult, coffeMat.AddDrink("latte", 10));
        }

        [Test]
        public void Test_BuyDrinkShouldWorkCorrectly()
        {
            CoffeeMat coffeMat = new CoffeeMat(15000, 5);

            coffeMat.AddDrink("espresso", 2);
            coffeMat.AddDrink("latte", 5);
            coffeMat.AddDrink("cappucino", 3);

            string expectedResult = "Your bill is 2.00$";
            coffeMat.FillWaterTank();

            Assert.AreEqual(expectedResult, coffeMat.BuyDrink("espresso"));
        }

        [Test]
        public void Test_BuyDrinkShouldNotWorkWhenMatOutOfWater()
        {
            CoffeeMat coffeMat = new CoffeeMat(70, 5);

            coffeMat.AddDrink("espresso", 2);

            string expectedResult = "CoffeeMat is out of water!";
            coffeMat.FillWaterTank();

            Assert.AreEqual(expectedResult, coffeMat.BuyDrink("espresso"));

            CoffeeMat coffeMat2 = new CoffeeMat(150, 5);
            coffeMat2.AddDrink("espresso", 2);
            coffeMat2.FillWaterTank();
            coffeMat2.BuyDrink("espresso");

            Assert.AreEqual(expectedResult, coffeMat2.BuyDrink("espresso"));
        }

        [Test]
        public void Test_BuyDrinkShouldNotWorkWhenDrinkUnavailable()
        {
            CoffeeMat coffeMat = new CoffeeMat(100, 5);

            coffeMat.AddDrink("espresso", 2);

            string expectedResult = "Latte is not available!";
            coffeMat.FillWaterTank();

            Assert.AreEqual(expectedResult, coffeMat.BuyDrink("Latte"));
        }

        [Test]
        public void Test_BuyDrinkShouldReduceWaterQuantity()
        {
            CoffeeMat coffeMat2 = new CoffeeMat(150, 5);
            coffeMat2.AddDrink("espresso", 2);
            coffeMat2.FillWaterTank();
            coffeMat2.BuyDrink("espresso");

            Assert.AreEqual(70, coffeMat2.WaterCapacity - 80);

            string expectedResult = "CoffeeMat is out of water!";

            Assert.AreEqual(expectedResult, coffeMat2.BuyDrink("espresso"));
        }



        [Test]
        public void Test_BuyDrinkShouldNotWorkWhenDrinkIsNotAvailable()
        {
            CoffeeMat coffeMat = new CoffeeMat(200, 5);

            coffeMat.AddDrink("espresso", 2);

            string expectedResult = "Latte is not available!";
            coffeMat.FillWaterTank();

            Assert.AreEqual(expectedResult, coffeMat.BuyDrink("Latte"));
        }

        [Test]
        public void Test_CollectIncomeWorkCorrectly()
        {
            CoffeeMat coffeMat = new CoffeeMat(200, 5);

            coffeMat.AddDrink("espresso", 10);

            double expectedResult = 20;
            coffeMat.FillWaterTank();
            coffeMat.BuyDrink("espresso");
            coffeMat.BuyDrink("espresso");

            Assert.AreEqual(20d, coffeMat.Income);
            Assert.AreEqual(expectedResult, coffeMat.CollectIncome());
        }
    }
}