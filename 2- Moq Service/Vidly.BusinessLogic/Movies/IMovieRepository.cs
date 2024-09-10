using System.Linq.Expressions;
using Vidly.BusinessLogic.Movies.Entities;

namespace Vidly.BusinessLogic.Movies
{
    public interface IMovieRepository
    {
        void Create(Movie movie);

        bool Exists(Expression<Func<Movie, bool>> predicate);

        List<Movie> GetAll(Expression<Func<Movie, bool>> predicate);

        Movie Get(Expression<Func<Movie, bool>> predicate);

        void Delete(Movie movie);
    }
}
