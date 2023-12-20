namespace UniversityLibrary
{
    using System.Collections.Generic;
    using System.Linq;
    public class UniversityLibrary
    {
        private readonly List<TextBook> textBooks = new List<TextBook>();

        public UniversityLibrary()
        {
            this.textBooks = new List<TextBook>();
        }

        public List<TextBook> Catalogue => this.textBooks; // 1.Test Catalogue count

        public string AddTextBookToLibrary(TextBook textBook)  
        {
            textBook.InventoryNumber = textBooks.Count + 1;  // 2.Test InventoryNumber
            this.textBooks.Add(textBook);

            return textBook.ToString();  // 3.Test ToString
        }

        public string LoanTextBook(int bookInventoryNumber, string studentName) 
        {
            TextBook textBook = this.textBooks.FirstOrDefault(t => t.InventoryNumber == bookInventoryNumber);

            if (textBook.Holder == studentName)   
            {
                return $"{studentName} still hasn't returned {textBook.Title}!";   // 4.Test book still not returned
            }
            else
            {
                textBook.Holder = studentName;   // 5.Test Holder Name

                return $"{textBook.Title} loaned to {studentName}.";  // 6.Test book loaned
            }

        }

        public string ReturnTextBook(int bookInventoryNumber)     
        {
            TextBook textBook = this.textBooks.FirstOrDefault(t => t.InventoryNumber == bookInventoryNumber);

            textBook.Holder = string.Empty;   //7.Test Holder == empty

            return $"{textBook.Title} is returned to the library.";  //8.Test book is returned
        }
    }
}
