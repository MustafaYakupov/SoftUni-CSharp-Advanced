
namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    using System;
    using System.Text;

    public class UniversityLibrearyTests
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
        public void Test_CatalogueCount()
        {
            lib.AddTextBookToLibrary(textBook);
            lib.AddTextBookToLibrary(textBook);
            lib.AddTextBookToLibrary(textBook);

            Assert.AreEqual(3, lib.Catalogue.Count);
        }

        [Test]
        public void Test_InventoryNumberAndToString()
        {
            lib.AddTextBookToLibrary(textBook);
            lib.AddTextBookToLibrary(textBook);
            string actualResult = lib.AddTextBookToLibrary(textBook);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Book: {title} - {textBook.InventoryNumber}");
            sb.AppendLine($"Category: {textBook.Category}");
            sb.AppendLine($"Author: {textBook.Author}");
            string expectedResult = sb.ToString().Trim();

            Assert.AreEqual(3, textBook.InventoryNumber);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Test_LoanBook_Loaned()
        {
            lib.AddTextBookToLibrary(textBook);

            string actualResult = lib.LoanTextBook(1, "Gosho");

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{title} loaned to Gosho.");
            string expectedResult = sb.ToString().Trim();

            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual("Gosho", textBook.Holder);
        }

        [Test]
        public void Test_LoanBook_StillNotReturned()
        {
            lib.AddTextBookToLibrary(textBook);

            lib.LoanTextBook(1, "Gosho");
            string actualResult = lib.LoanTextBook(1, "Gosho");

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Gosho still hasn't returned {title}!");
            string expectedResult = sb.ToString().Trim();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Test_ReturnTextBook()
        {
            lib.AddTextBookToLibrary(textBook);

            lib.LoanTextBook(1, "Gosho");

           string actualResult = lib.ReturnTextBook(1);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{title} is returned to the library.");
            string expectedResult = sb.ToString().Trim();

            Assert.AreEqual(string.Empty, textBook.Holder);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
