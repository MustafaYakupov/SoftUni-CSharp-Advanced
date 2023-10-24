using IteratorsAndComparators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparators
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var library = new Library();

            library.Add(new Book("Amazon", 2016,"Pesho" ));
            library.Add(new Book("Amazon 2", 2016,"Pesho" ));

            foreach (var book in library)
            {
                Console.WriteLine(book.Title);
            }
        }
    }
}
