using DI.WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var services = builder.Services;

services.AddTransient<ITransientService, Service>();

services.AddScoped<IScopeService, Service>();

services.AddSingleton<ISingletonService, Service>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
