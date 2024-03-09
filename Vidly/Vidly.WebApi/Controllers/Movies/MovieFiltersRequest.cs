﻿namespace Vidly.WebApi.Controllers.Movies
{
    public sealed record class MovieFiltersRequest
    {
        public string? Title { get; init; }

        public int? MinStars { get; init; }

        public DateTimeOffset? PublishedOn { get; init; }
    }
}
