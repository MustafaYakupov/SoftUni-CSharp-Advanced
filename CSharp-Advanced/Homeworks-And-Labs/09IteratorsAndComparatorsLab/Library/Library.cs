namespace IteratorsAndComparators
{
    using System.Collections;
    using System.Collections.Generic;

    public class Library : IEnumerable<Book> // We implement the IEnumerable interface 
    {
        private List<Book> books;

        public Library()
        {
            this.books = new List<Book>();
        }

        public void Add(Book book)
        { 
            this.books.Add(book);
        }

        public IEnumerator<Book> GetEnumerator() // The modern method that is using Generics
        {
            //foreach (var book in this.books)   // The quick way to implement IEnumerator with yield
            //{
            //    yield return book;
            //}

            return new LibraryEnumerator(this.books);
        }

        IEnumerator IEnumerable.GetEnumerator()  // Legacy method, we just tell him to use the other method above
            => this.GetEnumerator();

        private class LibraryEnumerator : IEnumerator<Book>
        {
            private List<Book> books;
            private int index;


            public LibraryEnumerator(List<Book> books)
            {
                this.books = books;
                this.index = -1;
            }
            public Book Current
            {
                get
                {
                    return this.books[this.index];
                }
            }
            object IEnumerator.Current
            {
                get 
                { 
                    return this.Current; 
                }
            } 

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                this.index++;

                if (this.index < this.books.Count)
                {
                    return true;
                }

                return false;
            }

            public void Reset()
            {
                this.index = -1;
            }
        }
    }
}
