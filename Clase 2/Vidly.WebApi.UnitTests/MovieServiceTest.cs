using FluentAssertions;
using Vidly.WebApi.Services.Movies;
using Vidly.WebApi.Services.Movies.Entities;

namespace Vidly.WebApi.UnitTests
{
    [TestClass]
    public sealed class MovieServiceTest
    {
        private MovieService _service;

        [TestInitialize]
        public void Initialize()
        {
            _service = new MovieService();
        }

        #region Create
        #region Error
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Create_WhenTitleIsDuplicated_ShouldThrowException()
        {
            try
            {
                var args = new CreateMovieArgs(
                    "Duplicated",
                    "valid description",
                    DateTimeOffset.UtcNow.AddMonths(-1));
                _service.Add(args);

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
