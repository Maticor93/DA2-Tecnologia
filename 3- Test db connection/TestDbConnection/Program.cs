﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

var connectionString = $"Server=localhost;Database=Test; Integrated Security=True;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True";
var builder = new DbContextOptionsBuilder<TestDbContext>();
builder
    .UseSqlServer(connectionString)
    .LogTo(Console.WriteLine, LogLevel.Information);

var context = new TestDbContext(builder.Options);
context.Database.EnsureCreated();

var newUser = new User("something")
{
    Book = new("book")
};
context.Users.Add(newUser);
context.SaveChanges();

var users = context
    .Users
    .ToList();

Console.WriteLine(users);
context.Dispose();

public sealed class TestDbContext
    : DbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<Book> Books { get; set; }

    public TestDbContext(DbContextOptions options)
        : base(options)
    {
    }
}

public sealed record class User()
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public string Name { get; set; } = null!;

    public Guid BookId { get; set; }

    public Book Book { get; set; } = null!;

    public User(string name)
        : this()
        {
            Name = name;
        }
}

public sealed record class Book()
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public string Name { get; set; } = null!;

    public Book(string name)
        : this()
        {
            Name = name;
        }
}
