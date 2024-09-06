using BlogDemo;

using BlogDbContext dbContext = new BlogDbContext();

var author = new Author()
{
    AuthorName = "Sasho",
};

dbContext.Authors.Add(author);

dbContext.SaveChanges();
