namespace Vidly.WebApi.Services.Sessions.Entities
{
    public sealed record class Session
    {
        public string Id { get; init; }

        public string Token { get; init; }

        public User User { get; init; }
    }
}
