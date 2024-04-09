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
            _repositoryMock = new Mock<IRepository<Movie>>();
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
        #endregion
        #endregion
    }
}
