using Microsoft.EntityFrameworkCore;
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
    Books = [new Book("book"), new Book("book2")]
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

    public DbSet<UserBook> UsersBooks { get; set; }

    public TestDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity
            .HasMany(u => u.Books)
            .WithMany(b => b.Readers)
            .UsingEntity<UserBook>();
        });
    }
}

public sealed record class User()
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public string Name { get; set; } = null!;

    public List<Book> Books { get; set; } = [];

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

    public List<User> Readers { get; init; } = [];

    public Book(string name)
        : this()
    {
        Name = name;
    }
}

public sealed record class UserBook()
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public Guid ReaderId { get; init; }

    public User Reader { get; init; } = null!;

    public Guid BookId { get; init; }

    public Book Book { get; init; } = null!;
}
