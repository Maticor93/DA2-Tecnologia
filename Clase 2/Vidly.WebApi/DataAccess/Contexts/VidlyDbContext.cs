using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Vidly.WebApi.Services.Movies.Entities;
using Vidly.WebApi.Services.Users.Entities;

namespace Vidly.WebApi.DataAccess.Contexts
{
    public sealed class VidlyContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<User> Users { get; set; }

        public VidlyContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigSchema(modelBuilder);
            ConfigSeedData(modelBuilder);
        }

        private void ConfigSchema(ModelBuilder modelBuilder)
        {
            var userBuilder = modelBuilder
                .Entity<User>()
                .HasMany(u => u.FavoriteMovies)
                .WithMany(m => m.Users)
               .UsingEntity<UserMovie>(
               r => r.HasOne(x => x.Movie).WithMany().HasForeignKey(x => x.MovieId),
               l => l.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId));

            var movieBuilder = modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.Platforms)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, JsonSerializerOptions.Default),
                    v => JsonSerializer.Deserialize<List<string>>(v, JsonSerializerOptions.Default) ?? new List<string>()
                    );
            });
        }

        private void ConfigSeedData(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .HasData(
                    new User
                    {
                        FirstName = "Admin",
                        LastName = "Admin",
                        FullName = "Admin Admin",
                        Email = "admin@gmail.com",
                        Password = "123456"
                    }
                );
        }
    }

    public sealed record class UserMovie
    {
        public string UserId { get; init; } = null!;

        public User User { get; init; } = null!;

        public string MovieId { get; init; } = null!;

        public Movie Movie { get; init; } = null!;
    }
}
