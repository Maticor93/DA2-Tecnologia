using FluentAssertions;
using Moq;
using Vidly.WebApi.Controllers.Movies;
using Vidly.WebApi.Controllers.Movies.Entities;
using Vidly.WebApi.Controllers.Movies.Models;

namespace Vidly.WebApi.UnitTests
{
    [TestClass]
    public sealed class MovieControllerTest
    {
        private MovieController _controller;

        [TestInitialize]
        public void Initialize()
        {
            _controller = new MovieController();
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
            
            var response = _controller.Create(request);

            response.Should().NotBeNull();
            response.Id.Should().NotBeNull();
            response.Id.Should().NotBeEmpty();
        }
        #endregion
        #endregion
    }
}