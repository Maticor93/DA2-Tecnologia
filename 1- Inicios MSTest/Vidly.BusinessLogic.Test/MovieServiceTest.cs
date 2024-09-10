using FluentAssertions;
using Vidly.BusinessLogic.Movies;

namespace Vidly.BusinessLogic.Test
{
    [TestClass]
    public class MovieServiceTest
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
        [ExpectedException(typeof(ArgumentNullException))]
        public void Create_WhenTitleIsNull_ShouldThrowException()
        {
            var args = new CreateMovieArgs(
                null,
                "some description",
                DateTimeOffset.UtcNow);

            _service.Create(args);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Create_WhenTitleEmpty_ShouldThrowException()
        {
            var args = new CreateMovieArgs(
                string.Empty,
                "some description",
                DateTimeOffset.UtcNow);

            _service.Create(args);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow(null)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Create_WhenTitleIsEmptyOrNull_ShouldThrowException(string name)
        {
            var args = new CreateMovieArgs(
                name,
                "some description",
                DateTimeOffset.UtcNow);

            _service.Create(args);
        }

        [TestMethod]
        public void Create_WhenTitleIsDuplicated_ShouldThrowException()
        {
            var args = new CreateMovieArgs(
                "duplicated",
                "some description",
                DateTimeOffset.UtcNow);
            _service.Create(args);

            var act = () => _service.Create(args);

            act.Should().Throw<Exception>().WithMessage("Movie duplicated");
        }
        #endregion

        #region Success
        [TestMethod]
        public void Create_WhenCorrectInfo_ShouldCreateMovie()
        {
            var args = new CreateMovieArgs(
                "some name",
                "some description",
                DateTimeOffset.UtcNow);

            var response = _service.Create(args);

            response.Should().NotBeNull();
            response.Id.Should().NotBeNull();
            response.Id.Should().NotBeEmpty();
        }
        #endregion
        #endregion
    }
}