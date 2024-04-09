using System.Globalization;

namespace Vidly.WebApi.Services.Movies.Entities
{
    public sealed record class CreateMovieArgs
    {
        public readonly string Title;

        public readonly string Description;

        public DateTimeOffset PublishedOn;

        public CreateMovieArgs(
            string title,
            string description,
            DateTimeOffset publishedOn)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException(nameof(Title));
            }
            Title = title;

            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentNullException(nameof(Description));
            }
            Description = description;

            if(publishedOn >= DateTimeOffset.UtcNow)
            {
                throw new ArgumentException("PublishedOn must be lower than today");
            }
            PublishedOn = publishedOn;
        }
    }
}
