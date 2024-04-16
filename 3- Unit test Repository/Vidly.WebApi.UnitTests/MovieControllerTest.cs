using FluentAssertions;
using Moq;
using Vidly.WebApi.Controllers.Movies;
using Vidly.WebApi.Controllers.Movies.Models;
using Vidly.WebApi.Services.Movies;
using Vidly.WebApi.Services.Movies.Entities;

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
            _movieServiceMock = new Mock<IMovieService>(MockBehavior.Strict);
            _controller = new MovieController(_movieServiceMock.Object);
        }

        #region Create
        
        #region Error
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Create_WhenRequestIsNull_ShouldThrowException()
        {
            _controller.Create(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
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
        [ExpectedException(typeof(ArgumentNullException))]
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
        
        #region Success
        [TestMethod]
        public void Create_WhenRequestHasCorrectInfo_ShouldCreateMovie()
        {
            var request = new CreateMovieRequest
            {
                Title = "title",
                Description = "description",
                PublishedOn = "2024-01-01"
            };
            var expectedMovie = new Movie
            {
                Title = request.Title,
                Description = request.Description,
                PublishedOn = DateTimeOffset.Parse(request.PublishedOn)
            };
            _movieServiceMock.Setup(m => m.Add(It.IsAny<CreateMovieArgs>())).Returns(expectedMovie);
            
            var response = _controller.Create(request);

            _movieServiceMock.VerifyAll();
            response.Should().NotBeNull();
            response.Id.Should().Be(expectedMovie.Id);
        }
        #endregion
        #endregion
    }
}