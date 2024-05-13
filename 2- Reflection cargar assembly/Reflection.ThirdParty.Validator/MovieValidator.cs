namespace Reflection.ThirdParty.Validator
{
    public sealed class MovieValidator : IMovieValidator
    {
        public bool IsValid(Movie movie)
        {
            Console.WriteLine("Third party implementation");

            return true;
        }
    }
}
