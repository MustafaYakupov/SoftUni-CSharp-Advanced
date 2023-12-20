using Chainblock.Contracts;
using Chainblock.Enumerations;
using Chainblock.Models;
using NUnit.Framework;

namespace Chainblock.Tests;

[TestFixture]
public class Tests
{
    [Test]
    public void ConstructorSHouldInitializeTransactionProperly()
    {
        ITransaction transaction = new Transaction(1, TransactionStatus.Successfull, "MY", "SY", 5);

        Assert.IsNotNull(transaction);
    }

    [Test]
    public void ConstructorSHouldInitializeIdProperly()
    {
        //Arrange
        int expectedId = 1;

        //Act
        ITransaction transaction = new Transaction(expectedId, TransactionStatus.Successfull, "MY", "SY", 5);

        //Assert
        Assert.AreEqual(expectedId, transaction.Id);
    }

    [Test]
    public void ConstructorSHouldInitializeStatusProperly()
    {
        TransactionStatus expectedStatus = TransactionStatus.Successfull; 

        ITransaction transaction = new Transaction(1, expectedStatus, "MY", "SY", 5);

        Assert.AreEqual(expectedStatus, transaction.Status);
    }

    [Test]
    public void ConstructorSHouldInitializeFromProperly()
    {
        string expectedFrom = "MY";

        ITransaction transaction = new Transaction(1, TransactionStatus.Successfull, expectedFrom, "SY", 5);

        Assert.AreEqual(expectedFrom, transaction.From);
    }

    [Test]
    public void ConstructorSHouldInitializeToProperly()
    {
        string expectedTo = "SY";

        ITransaction transaction = new Transaction(1, TransactionStatus.Successfull, "MY", expectedTo, 5);

        Assert.AreEqual(expectedTo, transaction.To);
    }

    [Test]
    public void ConstructorSHouldInitializeAmountProperly()
    {
        double expectedAmount = 5;

        ITransaction transaction = new Transaction(1, TransactionStatus.Successfull, "MY", "SY", expectedAmount);

        Assert.AreEqual(expectedAmount, transaction.Amount);
    }
}