namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    public class Tests
    {
        [Test]
        public void Test_ConstructorShouldWork()
        {
            Book book = new Book("Harry Potter", "J.K.Rowlings");

            Assert.AreEqual("Harry Potter", book.BookName);
            Assert.AreEqual("J.K.Rowlings", book.Author);
            Assert.AreEqual(0, book.FootnoteCount);
        }

        [Test]
        public void Test_ConstructorShouldThrow()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book("", "J.K.Rowlings");
            });

            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book("Harry Potter", "");
            });
        }

        [Test]
        public void Test_AddFootnoteShouldWork()
        {
            Book book = new Book("Harry Potter", "J.K.Rowlings");

            book.AddFootnote(1, "note1");
            book.AddFootnote(2, "note2");

            Assert.AreEqual(2, book.FootnoteCount);
            Assert.AreEqual("Footnote #1: note1", book.FindFootnote(1));
            Assert.AreEqual("Footnote #2: note2", book.FindFootnote(2));
        }

        [Test]
        public void Test_AddFootnoteShouldThrow()
        {
            Book book = new Book("Harry Potter", "J.K.Rowlings");

            book.AddFootnote(1, "note1");

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AddFootnote(1, "note1");
            });
        }

        [Test]
        public void Test_FindFootnoteShouldWork()
        {
            Book book = new Book("Harry Potter", "J.K.Rowlings");

            book.AddFootnote(1, "note1");
            book.AddFootnote(2, "note2");

            Assert.AreEqual(2, book.FootnoteCount);
            Assert.AreEqual("Footnote #1: note1", book.FindFootnote(1));
            Assert.AreEqual("Footnote #2: note2", book.FindFootnote(2));
        }

        [Test]
        public void Test_FindFootnoteShouldThrow()
        {
            Book book = new Book("Harry Potter", "J.K.Rowlings");

            book.AddFootnote(1, "note1");
            book.AddFootnote(2, "note2");

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.FindFootnote(3);
            });
        }

        [Test]
        public void Test_AlterFootnoteShouldWork()
        {
            Book book = new Book("Harry Potter", "J.K.Rowlings");

            book.AddFootnote(1, "note1");

            book.AlterFootnote(1, "New note1 text");

            Assert.AreEqual("Footnote #1: New note1 text", book.FindFootnote(1));
        }

        [Test]
        public void Test_AlterFootnoteShouldThrow()
        {
            Book book = new Book("Harry Potter", "J.K.Rowlings");

            book.AddFootnote(1, "note1");

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AlterFootnote(3, "text");
            });
        }
    }
}