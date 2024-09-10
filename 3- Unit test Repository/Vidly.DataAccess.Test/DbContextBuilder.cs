using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Vidly.DataAccess.Test
{
    internal sealed class DbContextBuilder
    {
        private static SqliteConnection _connection = new("Data Source=:memory:");

        public static TestDbContext BuildTestDbContext()
        {
            var options = new DbContextOptionsBuilder<TestDbContext>()
                .UseSqlite(_connection)
                .Options;

            _connection.Open();

            var context = new TestDbContext(options);

            return context;
        }
    }
}
