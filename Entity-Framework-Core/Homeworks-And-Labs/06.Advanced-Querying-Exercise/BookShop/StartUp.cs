namespace BookShop;

using BookShop.Models.Enums;
using Data;
using Initializer;
using System.Text;

public class StartUp
{
    public static void Main()
    {
        // EF 6:
        // AsNoTracking() -> Detach collection/entity from the ChangeTracker
        // Any changes made will not be savec
        // ToArray()/ToList() -> Materializes the query
        // Any code written later will not be executed in the DB as SQL
        // It is executed locally on the machine
        // Not detached from the tracker, SaveChanges() will update the DB with the changes we have made
        using var dbContext = new BookShopContext();
        //DbInitializer.ResetDatabase(dbContext);

        //int input = int.Parse(Console.ReadLine());

        int result = RemoveBooks(dbContext);

        Console.WriteLine(result);
    }

    // Problem 02
    public static string GetBooksByAgeRestriction(BookShopContext context, string command)
    {
        try
        {
            AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            string[] bookTitles = context.Books
           .Where(b => b.AgeRestriction == ageRestriction)
           .OrderBy(b => b.Title)
           .Select(b => b.Title)
           .ToArray();

            return String.Join(Environment.NewLine, bookTitles);
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    // Problem 03
    public static string GetGoldenBooks(BookShopContext context)
    {
        string[] goldenEDtionBooksTitles = context.Books
            .OrderBy(b => b.BookId)
            .Where(b => b.EditionType == EditionType.Gold
                && b.Copies < 5000)
            .Select(b => b.Title)
            .ToArray();

        return String.Join(Environment.NewLine, goldenEDtionBooksTitles);
    }

    // Problem 04
    public static string GetBooksByPrice(BookShopContext context)
    {
        StringBuilder sb = new StringBuilder();

        var bookswithPriceHigherThan40 = context.Books
            .Where(b => b.Price >= 40)
            .OrderByDescending(b => b.Price)
            .Select(b => new
            {
                b.Title,
                b.Price,
            })
            .ToArray();

        foreach (var book in bookswithPriceHigherThan40)
        {
            sb.AppendLine($"{book.Title} - ${book.Price:f2}");
        }

        return sb.ToString().Trim();
    }

    // Problem 05
    public static string GetBooksNotReleasedIn(BookShopContext context, int year)
    {
        string[] bookTitlesNotReleasedInAYear = context.Books
            .Where(b => b.ReleaseDate.Value.Year != year)
            .OrderBy(b => b.BookId)
            .Select(b => b.Title)
            .ToArray();

        return string.Join(Environment.NewLine, bookTitlesNotReleasedInAYear);
    }

    // Problem 06
    public static string GetBooksByCategory(BookShopContext context, string input)
    {
        string[] categories = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(c => c.ToLower())
            .ToArray();

        string[] booksByCategory = context.Books
            .Where(b => b.BookCategories.Any(bc => categories.Contains(bc.Category.Name.ToLower())))
            .OrderBy(b => b.Title)
            .Select(b => b.Title)
            .ToArray();

        return String.Join(Environment.NewLine, booksByCategory);
    }

    // Problem 07
    public static string GetBooksReleasedBefore(BookShopContext context, string date)
    {
        StringBuilder sb = new StringBuilder();

        var dateParts = date.Split("-");

        var day = int.Parse(dateParts[0]);
        var month = int.Parse(dateParts[1]);
        var year = int.Parse(dateParts[2]);

        var givenDate = new DateTime(year, month, day);

        var booksReleasedBeforeDate = context.Books
            .OrderByDescending(b => b.ReleaseDate)
            .Where(b => b.ReleaseDate < givenDate)
            .Select(b => new
            {
                b.Title,
                b.EditionType,
                b.Price,
            })
            .ToArray();

        foreach (var book in booksReleasedBeforeDate)
        {
            sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
        }

        return sb.ToString().Trim();
    }

    // Problem 08
    public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
    {
        StringBuilder sb = new StringBuilder();

        string[] authorNamesEningIn = context.Authors
            .Where(a => a.FirstName.EndsWith(input))
            .Select(a => a.FirstName + " " + a.LastName)
            .OrderBy(a => a)
            .ToArray();


        return string.Join(Environment.NewLine, authorNamesEningIn);
    }

    // Problem 09
    public static string GetBookTitlesContaining(BookShopContext context, string input)
    {
        string[] bookTitleContaining = context.Books
            .Where(b => b.Title.ToLower().Contains(input.ToLower()))
            .Select(b => b.Title)
            .OrderBy(b => b)
            .ToArray();

        return string.Join(Environment.NewLine, bookTitleContaining);
    }

    // Problem 10
    public static string GetBooksByAuthor(BookShopContext context, string input)
    {
        StringBuilder sb = new StringBuilder();

        var bookByAuthor = context.Books
            .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
            .OrderBy(b => b.BookId)
            .Select(b => new
            {
                b.Title,
                AuthorName = b.Author.FirstName + " " + b.Author.LastName,
            })
            .ToArray();

        foreach (var book in bookByAuthor)
        {
            sb.AppendLine($"{book.Title} ({book.AuthorName})");
        }

        return sb.ToString().Trim();
    }

    // Problem 11
    public static int CountBooks(BookShopContext context, int lengthCheck)
    {
        int countBooks = context.Books
            .Where(b => (b.Title.Length > lengthCheck))
            .Count();

        return countBooks;
    }

    // Problem 12
    public static string CountCopiesByAuthor(BookShopContext context)
    {
        StringBuilder sb = new StringBuilder();

        var copiesCount = context.Authors
            .Select(a => new
            {
                CopiesCount =  a.Books.Sum(a => a.Copies),
                AuthorName = a.FirstName + " " + a.LastName
            })
            .OrderByDescending(b => b.CopiesCount)
            .ToArray();

        foreach (var author in copiesCount)
        {
            sb.AppendLine($"{author.AuthorName} - {author.CopiesCount}");
        }

        return sb.ToString().Trim();
    }

    // Problem 13
    public static string GetTotalProfitByCategory(BookShopContext context)
    {
        StringBuilder sb = new StringBuilder();

        var profitByCategory = context.Categories
            .Select(c => new
            {
                Category = c.Name,
                TotalProfit = c.CategoryBooks
                    .Select(cb => cb.Book)
                    .Sum(b => b.Price * b.Copies),
            })
            .OrderByDescending(c => c.TotalProfit)
            .ThenBy(c => c.Category)
            .ToArray();

        foreach (var p in profitByCategory)
        {
            sb.AppendLine($"{p.Category} ${p.TotalProfit:f2}");
        }

        return sb.ToString().Trim();
    }

    // Problem 14
    public static string GetMostRecentBooks(BookShopContext context)
    {
        StringBuilder sb = new StringBuilder();

        var mostRecentBooks = context.Categories
            .OrderBy(c => c.Name)
            .Select(c => new
            {
                CategoryName = c.Name,
                MostRecentBooks = c.CategoryBooks
                    .OrderByDescending(cb => cb.Book.ReleaseDate)
                    .Take(3)
                    .Select(cb => new
                    {
                        cb.Book.Title,
                        ReleaseDate = cb.Book.ReleaseDate.Value.Year,
                    })
                    .ToArray(),
            })
            .ToArray();

        foreach (var category in mostRecentBooks)
        {
            sb.AppendLine($"--{category.CategoryName}");

            foreach (var book in category.MostRecentBooks)
            {
                sb.AppendLine($"{book.Title} ({book.ReleaseDate})");
            }
        }

        return sb.ToString().Trim();
    }

    // Problem 15
    public static void IncreasePrices(BookShopContext context)
    {
        var incereasePriceOfBooksBefore2010 = context.Books
            .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year < 2010)
            .ToArray();

        foreach (var book in incereasePriceOfBooksBefore2010)
        {
            book.Price += 5;
        }

        context.SaveChanges();
    }

    // Problem 16
    public static int RemoveBooks(BookShopContext context)
    {
        var booksToRemove = context.Books
            .Where(b => b.Copies < 4200)
            .ToArray();

        int removedBooks = booksToRemove.Count();

        context.Books.RemoveRange(booksToRemove);

        context.SaveChanges();

        return removedBooks;
    }
}


