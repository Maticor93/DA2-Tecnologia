var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder
    .Services
    .AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });

var app = builder.Build();

var configuration = app.Configuration;
var key = configuration.GetValue<string>("MyKey");
Console.WriteLine(key);

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
