using Vidly.WebApi.Services.Users;

namespace Vidly.WebApi.Services.Sessions
{
    public sealed record class Session
    {
        public string Id { get; init; }

        public string Token { get; init; }

        public User User { get; init; }
    }
}
