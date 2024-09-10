using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Vidly.DataAccess.Utils;

namespace Vidly.DataAccess.Test
{
    [TestClass]
    public class RepositoryTest
    {
        private readonly DbContext _context = DbContextBuilder.BuildTestDbContext();
        private readonly Repository<EntityTest> _repository;

        public RepositoryTest()
        {
            _repository = new Repository<EntityTest>(_context);
        }

        [TestInitialize]
        public void Setup()
        {
            _context.Database.EnsureCreated();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _context.Database.EnsureDeleted();
        }

        #region Add
        #region Success
        [TestMethod]
        public void Add_WhenInfoIsProvided_ShouldAddedToDatabase()
        {
            var entity = new EntityTest("some name");

            _repository.Add(entity);

            using var otherContext = DbContextBuilder.BuildTestDbContext();

            var entitiesSaved = otherContext.EntitiesTest.ToList();

            entitiesSaved.Count.Should().Be(1);

            var entitySaved = entitiesSaved[0];
            entitySaved.Id.Should().Be(entity.Id);
            entitySaved.Name.Should().Be(entity.Name);
        }
        #endregion
        #endregion

        #region GetAll
        [TestMethod]
        public void GetAll_WhenExistOnlyOne_ShouldReturnOne()
        {
            var expectedEntity = new EntityTest
            {
                Name = "dummy"
            };
            using var context = DbContextBuilder.BuildTestDbContext();
            context.Add(expectedEntity);
            context.SaveChanges();

            var entitiesSaved = _repository.GetAll();

            entitiesSaved.Count.Should().Be(1);

            var entitySaved = entitiesSaved[0];
            entitySaved.Id.Should().Be(expectedEntity.Id);
            entitySaved.Name.Should().Be(expectedEntity.Name);
        }
        #endregion
    }

    internal sealed class TestDbContext(DbContextOptions options)
        : DbContext(options)
    {
        public DbSet<EntityTest> EntitiesTest { get; set; }
    }

    internal sealed record class EntityTest()
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();

        public string Name { get; init; } = null!;

        public EntityTest(string name)
            : this()
        {
            Name = name;
        }
    }
}
