namespace Vidly.WebApi.Controllers.Movies
{
    public sealed record class MovieDetailInfoResponse
    {
        public string Id { get; init; }

        public string Title { get; init; }

        public string Description { get; init; }

        public int Stars {  get; init; }

        public DateTimeOffset PublishedOn { get; init; }

        public DateTimeOffset CreatedOn { get; init; }

        public MovieDetailInfoResponse(Movie movie)
        {
            this.Id = movie.Id;
            this.Title = movie.Title;
            this.Description = movie.Description;
            this.Stars = movie.Stars;
            this.PublishedOn = movie.PublishedOn;
            this.CreatedOn = movie.CreatedOn;
        }
    }
}
