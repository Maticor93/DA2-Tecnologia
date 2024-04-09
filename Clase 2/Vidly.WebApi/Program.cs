using Microsoft.EntityFrameworkCore;
using Vidly.WebApi.DataAccess.Contexts;
using Vidly.WebApi.DataAccess.Repositories;
using Vidly.WebApi.Services.Movies;
using Vidly.WebApi.Services.Movies.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder
    .Services
    .AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });

var services = builder.Services;
var configuration = builder.Configuration;

var vidlyConnectionString = configuration.GetConnectionString("Vidly");

if (string.IsNullOrEmpty(vidlyConnectionString))
{
    throw new Exception("Missing Vidly connection string");
}

services
    .AddDbContext<DbContext, VidlyDbContext>(
    options => options.UseSqlServer(vidlyConnectionString));

services.AddScoped<IRepository<Movie>, Repository<Movie>>();
services.AddScoped<IMovieService, MovieService>();

var app = builder.Build();
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
