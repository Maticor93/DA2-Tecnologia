using FluentAssertions;
using Moq;
using System.Linq.Expressions;
using Vidly.WebApi.DataAccess.Repositories;
using Vidly.WebApi.Services.Movies;
using Vidly.WebApi.Services.Movies.Entities;

namespace Vidly.WebApi.UnitTests
{
    [TestClass]
    public sealed class MovieServiceTest
    {
        private Mock<IRepository<Movie>> _repositoryMock;
        private MovieService _service;

        [TestInitialize]
        public void Initialize()
        {
            _repositoryMock = new Mock<IRepository<Movie>>(MockBehavior.Strict);
            this._service = new MovieService(_repositoryMock.Object);
        }

        #region Create
        #region Error
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Create_WhenNameExists_ShouldThrowException()
        {
            try
            {
                var args = new CreateMovieArgs(
                    "duplicated",
                    "valid description",
                    DateTimeOffset.UtcNow.AddMonths(-1));
                _repositoryMock.Setup(r => r.Exist(It.IsAny<Expression<Func<Movie, bool>>>())).Returns(true);
                
                _repositoryMock.VerifyAll();
                _service.Add(args);
            }
            catch (Exception ex)
            {
                ex.Message.Should().Be("Movie duplicated");
                throw;
            }
        }
        #endregion

        #region Success
        [TestMethod]
        public void Create_WhenInfoIsSuccess_ShouldReturnMovieCreated()
        {
            var args = new CreateMovieArgs(
                    "valid",
                    "valid description",
                    DateTimeOffset.UtcNow.AddMonths(-1));
            _repositoryMock.Setup(r => r.Exist(It.IsAny<Expression<Func<Movie, bool>>>())).Returns(false);
            _repositoryMock.Setup(r => r.Add(It.IsAny<Movie>()));

            var movieCreated = _service.Add(args);

            _repositoryMock.VerifyAll();
            movieCreated.Should().NotBeNull();
            movieCreated.Title.Should().Be(args.Title);
            movieCreated.Description.Should().Be(args.Description);
            movieCreated.PublishedOn.Should().Be(args.PublishedOn);
        }
        #endregion
        #endregion
    }
}
