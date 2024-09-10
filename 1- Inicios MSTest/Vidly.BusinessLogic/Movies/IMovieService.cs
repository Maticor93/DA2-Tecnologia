namespace Vidly.BusinessLogic.Movies
{
    public interface IMovieService
    {
        Movie Create(CreateMovieArgs args);
    }
}
