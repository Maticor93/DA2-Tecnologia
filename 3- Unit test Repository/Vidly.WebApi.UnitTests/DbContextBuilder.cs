using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Vidly.WebApi.UnitTests
{
    internal sealed class DbContextBuilder
    {
        private static SqliteConnection? _connection;

        private static SqliteConnection BuildConnection()
        {
            if( _connection == null )
            {
                _connection = new SqliteConnection("Data Source=:memory:");
            }

            return _connection;
        }

        public static TestDbContext BuildTestDbContext()
        {
            var connection = BuildConnection();
            var options = new DbContextOptionsBuilder<TestDbContext>()
                .UseSqlite(connection)
                .Options;

            connection.Open();

            var context = new TestDbContext(options);

            context.Database.EnsureCreated();

            return context;
        }
    }
}
