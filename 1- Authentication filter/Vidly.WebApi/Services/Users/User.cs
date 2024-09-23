namespace Vidly.WebApi.Services.Users
{
    public sealed record class User
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();

        public string Email { get; init; } = null!;

        public string Password { get; init; } = null!;
    }
}
