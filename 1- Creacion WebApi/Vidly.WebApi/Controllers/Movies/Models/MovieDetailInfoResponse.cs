﻿using Vidly.WebApi.Controllers.Movies.Entities;

namespace Vidly.WebApi.Controllers.Movies.Models
{
    public readonly struct MovieDetailInfoResponse(Movie movie)
    {
        public string Id { get; init; } = movie.Id;

        public string Title { get; init; } = movie.Title;

        public string Description { get; init; } = movie.Description;

        public int Stars { get; init; } = movie.Stars;

        public DateTimeOffset PublishedOn { get; init; } = movie.PublishedOn;

        public DateTimeOffset CreatedOn { get; init; } = movie.CreatedOn;
    }
}
