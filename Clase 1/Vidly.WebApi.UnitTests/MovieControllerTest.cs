using Moq;
using Vidly.WebApi.Controllers.Movies;
using Vidly.WebApi.Services.Movies;

namespace Vidly.WebApi.UnitTests
{
    [TestClass]
    public sealed class MovieControllerTest
    {
        private Mock<IMovieService> _movieServiceMock;
        private MovieController _controller;

        [TestInitialize]
        public void Initialize()
        {
            _movieServiceMock = new Mock<IMovieService>();
            _controller = new MovieController(_movieServiceMock.Object);
        }

        #region Create
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Create_WhenRequestIsNull_ShouldThrowException()
        {
            _controller.Create(null);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Create_WhenRequestHasTitleNull_ShouldThrowException()
        {
            var request = new CreateMovieRequest 
            { 
                Title = null,
                Description = "some description",
                PublishedOn = "2024-01-01"
            };

            _controller.Create(request);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Create_WhenRequestHasTitleEmpty_ShouldThrowException()
        {
            var request = new CreateMovieRequest
            {
                Title = string.Empty,
                Description = "some description",
                PublishedOn = "2024-01-01"
            };

            _controller.Create(request);
        }
        #endregion
    }
}