﻿
using BlogDemo.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BlogDemo;

public class BlogDbContext : DbContext
{
    public BlogDbContext()
    {
    }

    public BlogDbContext(DbContextOptions<BlogDbContext> options)
        :base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BlogConfiguration());
        modelBuilder.ApplyConfiguration(new PostTagConfiguration());

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=BlogDb;Integrated Security=True;");
        }
    }

    public DbSet<Blog> Blogs { get; set; }

    public DbSet<Author> Authors { get; set; }

    public DbSet<Post> Posts { get; set; }
     
    public DbSet<Tag> Tags { get; set; }
}
