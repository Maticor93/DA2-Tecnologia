using FluentAssertions;
using Moq;
using Vidly.WebApi.Services.Movies;
using Vidly.WebApi.Services.Movies.Entities;

namespace Vidly.WebApi.UnitTests
{
    [TestClass]
    public sealed class MovieServiceTest
    {
        private Mock<IMovieRepository> _movieRepositoryMock;
        private MovieService _service;

        [TestInitialize]
        public void Initialize()
        {
            _movieRepositoryMock = new Mock<IMovieRepository>(MockBehavior.Strict);
            _service = new MovieService(_movieRepositoryMock.Object);
        }

        #region Create
        #region Error
        [TestMethod]
        public void Create_WhenTitleIsDuplicated_ShouldThrowException()
        {
            var args = new CreateMovieArgs(
                "Duplicated",
                "valid description",
                DateTimeOffset.UtcNow.AddMonths(-1));

            _movieRepositoryMock
                .Setup(i => i.Exists(i => i.Title == args.Title))
                .Returns(true);

            var act = () => _service.Add(args);

            act.Should().Throw<Exception>().WithMessage("Movie duplicated");
            _movieRepositoryMock.VerifyAll();
        }
        #endregion

        #region Success
        #endregion
        #endregion
    }
}
