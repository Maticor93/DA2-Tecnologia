using Vidly.WebApi.Services.Users;

namespace Vidly.WebApi.Services.Sessions
{
    public sealed record class Session
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();

        public string Token { get; init; } = null!;

        public User User { get; init; } = null!;
    }
}
