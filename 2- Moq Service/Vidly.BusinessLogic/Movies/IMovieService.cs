using Vidly.BusinessLogic.Movies.Entities;

namespace Vidly.BusinessLogic.Movies
{
    public interface IMovieService
    {
        Movie Add(CreateMovieArgs movie);

        Movie GetById(string id);

        List<Movie> GetAll(string? title = null, int? minStars = null, string? publishedOn = null);

        void UpdateById(string id, string? description = null);

        void DeleteById(string id);
    }
}
