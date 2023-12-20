namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    using System;

    public class Tests
    {
        private UniversityLibrary lib;
        private TextBook textBook;
        private string title = "1984";
        private string author = "Orwell";
        private string category = "Othopy";

        [SetUp]
        public void SetUp()
        {
            textBook = new TextBook(title, author, category);
            lib = new UniversityLibrary();
        }

        [Test]
        public void Test_TextbookConstructorSetsValuesCorrectly()
        {
            Assert.AreEqual(textBook.Title, title);
            Assert.AreEqual(textBook.Author, author);
            Assert.AreEqual(textBook.Category, category);

            Assert.AreEqual($"Book: 1984 - 0{Environment.NewLine}Category: Othopy{Environment.NewLine}Author: Orwell", textBook.ToString());

            Assert.AreEqual(textBook.Holder, null);
        }

        [Test]
        public void Test_UniLibraryIsEmptyWhenNew()
        {
            int expectedCount = 0;
            Assert.AreEqual(expectedCount, lib.Catalogue.Count);
        }

        [Test]
        public void Test_AddManyTextBooksWokrsCorrectly()
        {
            for (int i = 0; i < 10; i++)
            {
                lib.AddTextBookToLibrary(textBook);
            }

            string result = lib.AddTextBookToLibrary(textBook);

            Assert.AreEqual(11, textBook.InventoryNumber);
        }

        [Test]
        public void Test_AddTextBookWorksCorrectly()
        {
            string result = lib.AddTextBookToLibrary(textBook);

            Assert.AreEqual(1, textBook.InventoryNumber);
            Assert.AreEqual(1, lib.Catalogue.Count);
            Assert.AreEqual(lib.Catalogue[0].Title, title);

            Assert.AreEqual($"Book: 1984 - 1{Environment.NewLine}Category: Othopy{Environment.NewLine}Author: Orwell", result);
        }

        [Test]
        public void Test_LoanTextBook()
        {
            lib.AddTextBookToLibrary(textBook);

            Assert.AreEqual(null, textBook.Holder);

            string result = lib.LoanTextBook(1, "Pesho");

            Assert.AreEqual(textBook.Holder, "Pesho");

            Assert.AreEqual(result, $"{title} loaned to Pesho.");

            result = lib.LoanTextBook(1, "Pesho");
            Assert.AreEqual(result, $"Pesho still hasn't returned {title}!");
        }

        [Test]
        public void Test_ReturnTextBook()
        {
            lib.AddTextBookToLibrary(textBook);
            string result = lib.ReturnTextBook(1);

            Assert.AreEqual(string.Empty, textBook.Holder);

            Assert.AreEqual(result, $"{title} is returned to the library.");
        }

        [Test]
        public void Test_ReturnAndLoanThrowErroeWhenTextBookNotFound()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                lib.LoanTextBook(55, "test");
            });

            Assert.Throws<NullReferenceException>(() =>
            {
                lib.ReturnTextBook(55);
            });
        }
    }
}