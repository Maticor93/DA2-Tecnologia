using FluentAssertions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using Vidly.WebApi.DataAccess.Repositories;

namespace Vidly.WebApi.UnitTests
{
    [TestClass]
    public class RepositoryTest
    {
        private readonly DbConnection _connection;
        private readonly DbContext _dbContext;
        private readonly Repository<EntityTest> _repository;

        public RepositoryTest()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            var options = new DbContextOptionsBuilder<TestDbContext>()
                .UseSqlite(_connection)
                .Options;
            _dbContext = new TestDbContext(options);
            _repository = new Repository<EntityTest>(_dbContext);
        }

        [TestInitialize]
        public void Initialize()
        {
            _connection.Open();
            _dbContext.Database.EnsureCreated();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _dbContext.Database.EnsureDeleted();
        }

        #region Add
        [TestMethod]
        public void Add_WhenInfoIsProvided_ShouldAddedToDatabase()
        {
            var entity = new EntityTest("some name");

            _repository.Add(entity);

            var entitiesSaved = _dbContext.Set<EntityTest>().ToList();
            entitiesSaved.Count.Should().Be(1);
            var entitySaved = entitiesSaved[0];
            entitySaved.Id.Should().Be(entity.Id);
            entitySaved.Name.Should().Be(entity.Name);
        }
        #endregion
    }

    internal sealed class TestDbContext : DbContext
    {
        public DbSet<EntityTest> EntitiesTest { get; set; }

        public TestDbContext(DbContextOptions options)
            : base(options) 
        {
        }
    }

    internal sealed record class EntityTest
    {
        public string Id { get; init; } = null!;

        public string Name { get; init; } = null!;

        public EntityTest()
        {
            Id = Guid.NewGuid().ToString();
        }

        public EntityTest(string name)
            : this()
        {
            Name = name;
        }
    }
}
